using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;

namespace CEHQuestions {
    public partial class Form1 : Form {
        private string exhibit_path = @"./exhibits/";
        private string question_path = @"./questions/";

        private List<string> questionSets;
        private List<string> exhibits;

        private List<Question> questions;

        private int questionCount = 0;

        private Session session;

        [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        public Form1() {
            InitializeComponent();
            btnExplain.Tag = false;
        }

        private void Form1_Load(object sender, EventArgs e) {
            questionSets = new List<string>();
            exhibits = new List<string>();

            foreach (var f in Directory.EnumerateFiles(question_path))
                questionSets.Add(f);

            //cmbSet.DataSource = questionSets;

            foreach (string s in questionSets)
                cmbSet.Items.Add(s.Split('/').Last<string>());
        }

        private void cmbSet_SelectedIndexChanged(object sender, EventArgs e) {
            questions = LoadQuestions(questionSets[cmbSet.SelectedIndex]);
            if (session == null)
                session = new Session { Set = cmbSet.Text, Answers = new List<Response>() };

            cmbQuestion.Items.Clear();

            foreach (Question q in questions) {
                cmbQuestion.Items.Add(q.ID);
                session.Answers.Add(new Response { Question = q.ID, Answer = "" });
            }            

            cmbQuestion.SelectedIndex = 0;
        }

        private void btnAnswer_Click(object sender, EventArgs e) {
            //txtAnswer.Text = questions[cmbQuestion.SelectedIndex].Answer;

            if (btnAnswer.Text.Contains("Show")) {
                btnAnswer.Text = "Hide Answer";
                foreach (RadioButton r in fpnlAnswers.Controls.OfType<RadioButton>().ToList())
                    r.ForeColor = Color.Red;
                fpnlAnswers.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Tag.ToString() == questions[cmbQuestion.SelectedIndex].Answer).ForeColor = Color.Green;
            }
            else {
                btnAnswer.Text = "Show Answer";
                foreach (RadioButton r in fpnlAnswers.Controls.OfType<RadioButton>().ToList())
                    r.ForeColor = Color.Black;
            }
        }

        private void SaveResponse(int index) {
            if (fpnlAnswers.Controls.Count > 0) {
                Response sr = session.Answers.Find(i => i.Question == cmbQuestion.Items[index].ToString());
                RadioButton rb = fpnlAnswers.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                if (rb != null)
                    sr.Answer = rb.Tag.ToString();
            }
        }

        private void LoadResponse(int index) {
            Response lr = session.Answers.Find(i => i.Question == cmbQuestion.Items[index].ToString());
            if (lr != null && lr.Answer != "") {
                fpnlAnswers.Controls.OfType<RadioButton>().FirstOrDefault(rb => (string)rb.Tag == lr.Answer).Checked = true;
            }
        }

        private void cmbQuestion_SelectedIndexChanged(object sender, EventArgs e) {
            // new question logic
            fpnlAnswers.Controls.Clear();
            DisplayQuestion(questions[cmbQuestion.SelectedIndex]);
            lblNumber.Text = "(" + (cmbQuestion.SelectedIndex + 1).ToString() + " of " + questionCount.ToString() + ")";

            // load existing response
            LoadResponse(cmbQuestion.SelectedIndex);
        }

        private void btnPrevious_Click(object sender, EventArgs e) {
            if (cmbQuestion.SelectedIndex > 0)
                cmbQuestion.SelectedIndex -= 1;
        }

        private void btnNext_Click(object sender, EventArgs e) {
            if (cmbQuestion.SelectedIndex < cmbQuestion.Items.Count - 1)
                cmbQuestion.SelectedIndex += 1;
        }

        private void btnExplain_Click(object sender, EventArgs e) {
            if (!(bool)btnExplain.Tag && questions != null) {
                btnExplain.Tag = true;
                txtQuestion.Text += "\r\n\r\nExplanation:\r\n" + questions[cmbQuestion.SelectedIndex].Explanation;
            }
        }

        private void showExhibit() {
            if (questions[cmbQuestion.SelectedIndex].Exhibit == null) {
                imgExhibit.Visible = false;
            }
            else {
                imgExhibit.Image = Image.FromFile(questions[cmbQuestion.SelectedIndex].Exhibit);
                imgExhibit.Visible = true;
            }
        }

        // Loads the questions from the xml file
        private List<Question> LoadQuestions(string questionSet) {
            List<Question> list = new List<Question>();
            
            // Load question set from XML
            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.XmlResolver = new XmlUrlResolver();
            try {
                using (XmlReader reader = XmlReader.Create(questionSet, settings)) {
                    xmlDoc.Load(reader);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            // get the root of the document
            XmlElement root = xmlDoc.DocumentElement;

            // get the question nodes
            XmlNodeList questionList = root.GetElementsByTagName("question");

            // Process all questions
            foreach (XmlNode question in questionList) {
                // create a new question object
                Question item = new Question();
                item.Answers = new List<Answer>();

                XmlElement q = (XmlElement)question;

                //get question element attribute values
                item.ID = question.Attributes.GetNamedItem("id").Value;
                item.Topic = question.Attributes.GetNamedItem("topic").Value;
                item.Answer = question.Attributes.GetNamedItem("answer").Value;

                // get question children element values
                //item.Text = q.GetElementsByTagName("text").Item(0).FirstChild.Value;
                //item.Explanation = q.GetElementsByTagName("explanation").Item(0).FirstChild.Value;
                foreach (XmlNode n in q.ChildNodes) {
                    switch (n.LocalName) {
                        case "text":
                            item.Text = n.InnerText;
                            break;
                        case "explanation":
                            item.Explanation = n.InnerText;
                            break;
                        default:
                            item.Answers.Add(new Answer { ID = n.LocalName, Text = n.InnerText });
                            break;
                    }
                }

                // add the question to the list
                list.Add(item);
            }

            // load exhibits
            exhibits = new List<string>();
            var p = questionSet.Split('/').Last<string>();
            p = p.Remove(p.LastIndexOf('.'));
            try {
                // get images in folder
                var path = exhibit_path + p + @"/";
                foreach (var f in Directory.EnumerateFiles(path))
                    exhibits.Add(f);

                // for each image, find the question with the same id number
                foreach (string s in exhibits) {
                    var q = s.Split('/')[3].Split('.')[0];
                    list.Find(i => i.ID == q).Exhibit = s;
                }
            }
            catch (Exception) { // some error, just move on
            }

            questionCount = list.Count;

            return list;
        }

        private void DisplayQuestion(Question question) {
            imgExhibit.Visible = false;
            lblTopic.Text = "Exam Topic: " + question.Topic;

            txtQuestion.Text = question.Text + "\r\n\r\n";

            btnExplain.Tag = false;

            int textHeight = (txtQuestion.Font.Height + 2) * SendMessage(txtQuestion.Handle.ToInt32(), 0xba, 0, 0);
            var s = txtQuestion.Size;
            imgExhibit.Size = new Size(s.Width, s.Height - textHeight);
            imgExhibit.Location = new Point(imgExhibit.Location.X, txtQuestion.Location.Y + textHeight);

            showExhibit();

            foreach (Answer a in question.Answers) {
                RadioButton rb = new RadioButton() {
                    Text = a.ID + ". " + a.Text,
                    AutoSize = true,
                    Tag = a.ID
                };
                rb.CheckedChanged += Rb_CheckedChanged;

                fpnlAnswers.Controls.Add(rb);
            }
        }

        private void Rb_CheckedChanged(object sender, EventArgs e) {
            SaveResponse(cmbQuestion.SelectedIndex);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Session s = session;
            s.Question = cmbQuestion.SelectedIndex;

            try {
                using (Stream stream = File.Open(@"./session", FileMode.Create)) {
                    var binaryF = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryF.Serialize(stream, s);
                }
            } catch (Exception ex) {
                MessageBox.Show("Failed to save session. \r\n\r\n" + ex.Message,"Failed to Save Session");
            }
        }

        private void btbLoad_Click(object sender, EventArgs e) {
            try {
                using (Stream stream = File.Open(@"./session", FileMode.Open)) {
                    var binaryF = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    session = (Session)binaryF.Deserialize(stream);
                }
            }
            catch (FileNotFoundException) {
                MessageBox.Show("No saved session found.","Failed to Load Session");
            }
            catch (Exception ex) {
                MessageBox.Show("Failed to load session. \r\n\r\n" + ex.Message,"Failed to Load Session");
            }

            if (session != null) {
                string set = session.Set;
                int question = session.Question;
                cmbSet.SelectedItem = set;
                cmbQuestion.SelectedIndex = question;
            }
        }

        private void btnNew_Click(object sender, EventArgs e) {
            session = new Session { Set = cmbSet.Text, Answers = new List<Response>() };
        }
    }

    [Serializable]
    public class Session { 
        public int Question { get; set; }
        public string Set { get; set; }
        public List<Response> Answers { get; set; }
    }

    [Serializable]
    public class Response {
        public string Question { get; set; }
        public string Answer { get; set; }
    }

    // an exam question
    public class Question { 
        public string ID { get; set; }
        public string Topic { get; set; }
        public string Answer { get; set; }
        public string Text { get; set; }
        public string Explanation { get; set; }
        public string Exhibit { get; set; }
        public List<Answer> Answers { get; set; }
    }

    // a question answer
    public class Answer {
        public string ID { get; set; }
        public string Text { get; set; }
    }
}
