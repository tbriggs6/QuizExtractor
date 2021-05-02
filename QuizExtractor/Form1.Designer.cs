namespace QuizExtractor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private QuizModel model = QuizModelFactory.getModel();
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProjectFile = new System.Windows.Forms.TextBox();
            this.btnPrjFile = new System.Windows.Forms.Button();
            this.btnQuizFile = new System.Windows.Forms.Button();
            this.txtQuizFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quiz Extractor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Camtasia Project File:";
            // 
            // txtProjectFile
            // 
            this.txtProjectFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProjectFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtProjectFile.Location = new System.Drawing.Point(166, 94);
            this.txtProjectFile.Name = "txtProjectFile";
            this.txtProjectFile.Size = new System.Drawing.Size(216, 20);
            this.txtProjectFile.TabIndex = 2;
            this.txtProjectFile.TextChanged += new System.EventHandler(this.txtProjectFile_TextChanged);
            // 
            // btnPrjFile
            // 
            this.btnPrjFile.Location = new System.Drawing.Point(388, 92);
            this.btnPrjFile.Name = "btnPrjFile";
            this.btnPrjFile.Size = new System.Drawing.Size(75, 23);
            this.btnPrjFile.TabIndex = 3;
            this.btnPrjFile.Text = "Browse";
            this.btnPrjFile.UseVisualStyleBackColor = true;
            this.btnPrjFile.Click += new System.EventHandler(this.btnPrjFile_Click);
            // 
            // btnQuizFile
            // 
            this.btnQuizFile.Location = new System.Drawing.Point(388, 121);
            this.btnQuizFile.Name = "btnQuizFile";
            this.btnQuizFile.Size = new System.Drawing.Size(75, 23);
            this.btnQuizFile.TabIndex = 6;
            this.btnQuizFile.Text = "Browse";
            this.btnQuizFile.UseVisualStyleBackColor = true;
            this.btnQuizFile.Click += new System.EventHandler(this.btnQuizFile_Click);
            // 
            // txtQuizFile
            // 
            this.txtQuizFile.Location = new System.Drawing.Point(166, 123);
            this.txtQuizFile.Name = "txtQuizFile";
            this.txtQuizFile.Size = new System.Drawing.Size(216, 20);
            this.txtQuizFile.TabIndex = 5;
            this.txtQuizFile.TextChanged += new System.EventHandler(this.txtQuizFile_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output File:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(388, 169);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 7;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Convert Camtasia video quiz to D2L Quiz Format";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(57, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 43);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Format";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "D2L";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(59, 20);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(88, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Grade Scope";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 219);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnQuizFile);
            this.Controls.Add(this.txtQuizFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrjFile);
            this.Controls.Add(this.txtProjectFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Quiz Extractor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProjectFile;
        private System.Windows.Forms.Button btnPrjFile;
        private System.Windows.Forms.Button btnQuizFile;
        private System.Windows.Forms.TextBox txtQuizFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

