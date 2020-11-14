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

namespace CEHQuestions {
    public partial class Form1 : Form {
        private string exhibit_path = @"./exhibits/";
        private string question_path = @"./questions/";

        private List<string> questionSets;
        private List<string> exhibits;

        private List<Question> questions;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            questionSets = new List<string>();
            exhibits = new List<string>();

            foreach (var f in Directory.EnumerateFiles(question_path))
                questionSets.Add(f);

            foreach (string s in questionSets)
                cmbSet.Items.Add(s.Split('/').Last<string>());
        }

        private void cmbSet_SelectedIndexChanged(object sender, EventArgs e) {
            questions = LoadQuestions(questionSets[cmbSet.SelectedIndex]);

            cmbQuestion.Items.Clear();

            foreach (Question q in questions) {
                cmbQuestion.Items.Add(q.ID);
            }

            cmbQuestion.SelectedIndex = 0;
        }

        private void btnAnswer_Click(object sender, EventArgs e) {
            txtAnswer.Text = questions[cmbQuestion.SelectedIndex].Answer;
        }

        private void cmbQuestion_SelectedIndexChanged(object sender, EventArgs e) {
            DisplayQuestion(questions[cmbQuestion.SelectedIndex]);
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
            txtQuestion.Text += "\r\n\r\nExplanation:\r\n" + questions[cmbQuestion.SelectedIndex].Explanation;
        }

        private void btnExhibit_Click(object sender, EventArgs e) {
            imgExhibit.Image = Image.FromFile(questions[cmbQuestion.SelectedIndex].Exhibit);
            
            if (btnExhibit.Text == "Show Exhibit") {
                imgExhibit.Visible = true;
                btnExhibit.Text = "Hide Exhibit";
            }
            else {
                imgExhibit.Visible = false;
                btnExhibit.Text = "Show Exhibit";
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
                item.Answers = new List<string>();

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
                            item.Answers.Add(n.LocalName + ": " + n.InnerText);
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
            catch (Exception ex) { // some error, just move on
            }

            return list;
        }

        private void DisplayQuestion(Question question) {
            imgExhibit.Visible = false;
            lblTopic.Text = "Exam Topic: " + question.Topic;
            txtAnswer.Text = "";

            txtQuestion.Text = question.Text + "\r\n\r\n";
            foreach (string s in question.Answers) {
                txtQuestion.Text += s + "\r\n";
            }

            if (question.Exhibit == null)
                btnExhibit.Enabled = false;
            else
                btnExhibit.Enabled = true;

            if (question.Explanation == "")
                btnExplain.Enabled = false;
            else
                btnExplain.Enabled = true;
        }
    }

    // an exam question
    public class Question { 
        public string ID { get; set; }
        public string Topic { get; set; }
        public string Answer { get; set; }
        public string Text { get; set; }
        public string Explanation { get; set; }
        public string Exhibit { get; set; }
        public List<string> Answers { get; set; }
    }
}
