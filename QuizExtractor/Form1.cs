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
using System.Diagnostics;

namespace QuizExtractor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

        private void btnPrjFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Camtasia File (*.tscproj)|*.tscproj";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                model.CamtasiaFileName = ofd.FileName;
                txtProjectFile.Text = ofd.FileName;
            }

        }

        private void txtProjectFile_TextChanged(object sender, EventArgs e)
        {
            model.CamtasiaFileName = txtProjectFile.Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnQuizFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv files (*.csv)|*.csv";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                model.QuizFile = sfd.FileName;
                txtQuizFile.Text = sfd.FileName;
            }

        }

        private void txtQuizFile_TextChanged(object sender, EventArgs e)
        {
            model.QuizFile = txtQuizFile.Text;
        }

        private DialogResult confirmOverwrite( )
        {
            string message = "Quiz file already exists, overwrite?";
            string title = "Confirm Overwrite";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            return MessageBox.Show(message, title, buttons);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!File.Exists(model.CamtasiaFileName))
            {
                MessageBox.Show("Quiz file does not ext!");
                return;
            }

            if ((File.Exists(model.QuizFile) && confirmOverwrite() != DialogResult.Yes))
            {
                return;
            }

            if (radioButton1.Checked == true)
            {
                // start conversion
                QuizConverter converter = new QuizConverter();
                string contents = converter.readProjectFile();
                converter.convertQuiz(contents);
            }
            else
            {
                // start conversion
                QuizConverter converter = new QuizConverter();
                string contents = converter.readProjectFile();
                converter.convertGS(contents);

                Process.Start(model.QuizFile);                
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
