namespace CEHQuestions {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblTopic = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.cmbSet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExplain = new System.Windows.Forms.Button();
            this.cmbQuestion = new System.Windows.Forms.ComboBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgExhibit = new System.Windows.Forms.PictureBox();
            this.fpnlAnswers = new System.Windows.Forms.FlowLayoutPanel();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btbLoad = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgExhibit)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTopic
            // 
            this.lblTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopic.Location = new System.Drawing.Point(12, 50);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(136, 23);
            this.lblTopic.TabIndex = 2;
            this.lblTopic.Text = "Topic";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(12, 948);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 81);
            this.btnPrevious.TabIndex = 6;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(1817, 948);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 81);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnAnswer
            // 
            this.btnAnswer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswer.Location = new System.Drawing.Point(837, 999);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(120, 30);
            this.btnAnswer.TabIndex = 7;
            this.btnAnswer.Text = "Show Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // lblQuestion
            // 
            this.lblQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(1702, 50);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(125, 23);
            this.lblQuestion.TabIndex = 3;
            this.lblQuestion.Text = "Exam Question:";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbSet
            // 
            this.cmbSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSet.FormattingEnabled = true;
            this.cmbSet.Location = new System.Drawing.Point(125, 9);
            this.cmbSet.Name = "cmbSet";
            this.cmbSet.Size = new System.Drawing.Size(207, 28);
            this.cmbSet.TabIndex = 1;
            this.cmbSet.SelectedIndexChanged += new System.EventHandler(this.cmbSet_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Question Set";
            // 
            // btnExplain
            // 
            this.btnExplain.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExplain.Location = new System.Drawing.Point(963, 999);
            this.btnExplain.Name = "btnExplain";
            this.btnExplain.Size = new System.Drawing.Size(120, 30);
            this.btnExplain.TabIndex = 9;
            this.btnExplain.Text = "Explanation";
            this.btnExplain.UseVisualStyleBackColor = true;
            this.btnExplain.Click += new System.EventHandler(this.btnExplain_Click);
            // 
            // cmbQuestion
            // 
            this.cmbQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbQuestion.FormattingEnabled = true;
            this.cmbQuestion.Location = new System.Drawing.Point(1833, 47);
            this.cmbQuestion.Name = "cmbQuestion";
            this.cmbQuestion.Size = new System.Drawing.Size(59, 28);
            this.cmbQuestion.TabIndex = 11;
            this.cmbQuestion.SelectedIndexChanged += new System.EventHandler(this.cmbQuestion_SelectedIndexChanged);
            // 
            // lblNumber
            // 
            this.lblNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(1579, 50);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(117, 23);
            this.lblNumber.TabIndex = 12;
            this.lblNumber.Text = "( 0 of 0)";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.imgExhibit);
            this.panel1.Controls.Add(this.fpnlAnswers);
            this.panel1.Controls.Add(this.txtQuestion);
            this.panel1.Location = new System.Drawing.Point(12, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1880, 866);
            this.panel1.TabIndex = 14;
            // 
            // imgExhibit
            // 
            this.imgExhibit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgExhibit.BackColor = System.Drawing.Color.White;
            this.imgExhibit.Location = new System.Drawing.Point(3, 84);
            this.imgExhibit.Name = "imgExhibit";
            this.imgExhibit.Size = new System.Drawing.Size(1870, 554);
            this.imgExhibit.TabIndex = 11;
            this.imgExhibit.TabStop = false;
            // 
            // fpnlAnswers
            // 
            this.fpnlAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpnlAnswers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpnlAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.fpnlAnswers.Location = new System.Drawing.Point(2, 644);
            this.fpnlAnswers.Name = "fpnlAnswers";
            this.fpnlAnswers.Size = new System.Drawing.Size(1871, 215);
            this.fpnlAnswers.TabIndex = 14;
            // 
            // txtQuestion
            // 
            this.txtQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuestion.BackColor = System.Drawing.Color.White;
            this.txtQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuestion.Location = new System.Drawing.Point(3, 3);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.ReadOnly = true;
            this.txtQuestion.Size = new System.Drawing.Size(1870, 635);
            this.txtQuestion.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(464, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save Session";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btbLoad
            // 
            this.btbLoad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btbLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbLoad.Location = new System.Drawing.Point(590, 7);
            this.btbLoad.Name = "btbLoad";
            this.btbLoad.Size = new System.Drawing.Size(120, 30);
            this.btbLoad.TabIndex = 16;
            this.btbLoad.Text = "Load Session";
            this.btbLoad.UseVisualStyleBackColor = true;
            this.btbLoad.Click += new System.EventHandler(this.btbLoad_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(338, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(120, 30);
            this.btnNew.TabIndex = 17;
            this.btnNew.Text = "New Session";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btbLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.cmbQuestion);
            this.Controls.Add(this.btnExplain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSet);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblTopic);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(860, 640);
            this.Name = "Form1";
            this.Text = "CEH Questions";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgExhibit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.ComboBox cmbSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExplain;
        private System.Windows.Forms.ComboBox cmbQuestion;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgExhibit;
        private System.Windows.Forms.FlowLayoutPanel fpnlAnswers;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btbLoad;
        private System.Windows.Forms.Button btnNew;
    }
}

