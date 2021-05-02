using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace QuizExtractor
{

    abstract class QuizQuestion
    {
        public string baseName { get; set; }
        public int id { get; set; }
        private string _text;
        public string text
        {
            get { return _text; }
            set
            {
                _text = value.Replace('"', '\'');
            }
        }
        public int feedback { get; set; }
        public string feedback_ok { get; set; }
        public string feedback_nok { get; set; }


        public QuizQuestion(string baseName)
        {
            this.baseName = baseName;
        }

        public abstract string toD2LString();
        public abstract string toGSString();


    }

    class Answer
    {
        public int id { get; set; }
        private string _text;

        public string text
        {
            get { return _text;  }
            set
            {
                _text = value.Replace('"', '\'');
            }
        }

        public int correct { get; set;  }
    }


    class QuizMultipleChoice : QuizQuestion
    {

        public List<Answer> answers { get; set; } = new List<Answer>();

        public QuizMultipleChoice(string baseName) : base(baseName)
        {
            ;
        }

        public string getTitle()
        {
            int len = text.Length < 35 ? text.Length : 35;
            return text.Substring(0, len);
        }

        public override string toD2LString()
        {
            StringBuilder sb = new StringBuilder("// Multiple Choice\n");
            sb.Append("NewQuestion,MC\n");
            sb.AppendFormat("ID,{0}-{1}\n", base.baseName, id);
            sb.AppendFormat("Title,MC-\"{0}\"\n", getTitle());
            sb.AppendFormat("QuestionText,\"{0}\"\n", text);
            sb.Append("Points,5\n");

            foreach (Answer ans in answers)
            {
                sb.AppendFormat("Option,{0},\"{1}\"\n",
                    ((ans.correct == 1) ? 100 : 0), ans.text);
            }

            sb.Append("\n");

            return sb.ToString();
        }

        public override string toGSString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("############  Multiple Choice #################\n");
            sb.Append(text);
            sb.Append("\n\n");
            foreach (Answer ans in answers)
            {
                sb.AppendFormat("({0}) {1}\n",
                    ((ans.correct == 1) ? 'X' : ' '), ans.text);
            }

            sb.Append("\n");

            return sb.ToString();
        }



    }

    class QuizFillInBlank : QuizQuestion
    {
        public List<Answer> answers { get; set; } = new List<Answer>();

        public QuizFillInBlank(string baseName) : base(baseName)
        {
            ;
        }

        public string getTitle()
        {
            int len = text.Length < 35 ? text.Length : 35;
            return text.Substring(0, len);
        }

        public override string toD2LString()
        {
            StringBuilder sb = new StringBuilder("//Short Answer Type\nNewQuestion,SA\n");
            sb.AppendFormat("ID,{0}-{1}\n", base.baseName, id);
            sb.AppendFormat("Title,FIB-\"{0}\"\n", getTitle());
            sb.AppendFormat("QuestionText,\"{0}\"\n", text);
            sb.Append("Points,5\n");
            sb.Append("InputBox,1,40\n");

            foreach (Answer ans in answers)
            {
                sb.AppendFormat("Answer,{0},\"{1}\"\n", 
                    ((ans.correct == 1) ? 100 : 0), ans.text);
            }

            if (feedback == 1)
            {
                sb.AppendFormat("Feedback,\"{0}\",\"{1}\"\n", feedback_ok, feedback_nok);
            }
            sb.Append("\n");

            return sb.ToString();
        }

        public override string toGSString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("########## Short Answer ###########\n");
            sb.Append(text);
            sb.Append("\n\n");

            foreach (Answer ans in answers)
            {
                sb.AppendFormat("[____]({0})",ans.text);
            }
            sb.Append("\n");

            return sb.ToString();
        }

    }

    class QuizLogical : QuizQuestion
    {
        public int istrue { get; set;  }

        public QuizLogical(string baseName) : base(baseName)
        {
            ;
        }

        public string getTitle()
        {
            int len = text.Length < 35 ? text.Length : 35;
            return text.Substring(0, len);
        }

        public override string toD2LString()
        {
            StringBuilder sb = new StringBuilder(
                "//True False\n");
            sb.Append("NewQuestion,TF,,\n");

            sb.AppendFormat("ID,{0}-{1}\n", base.baseName, id);
            
            sb.AppendFormat("Title,TF-\"{0}\"\n", getTitle());
            sb.AppendFormat("QuestionText,\"{0}\"\n", text);
            sb.Append("Points,5\n");

            sb.AppendFormat("TRUE,{0},,\n", (istrue == 1) ? 100 : 0);
            sb.AppendFormat("FALSE,{0},,\n", (istrue == 0) ? 100 : 0);

            if (feedback == 1)
            {
                sb.AppendFormat("Feedback,\"{0}\",\"{1}\"\n", feedback_ok, feedback_nok);
            }
            sb.Append("\n");

            return sb.ToString();
        }

        public override string toGSString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("####### Logical #########\n");
            sb.Append(text);
            sb.Append("\n\n");


            sb.AppendFormat("({0}) True\n", (istrue == 1 ? 'X' : ' '));
            sb.AppendFormat("({0}) False\n", (istrue == 0 ? 'X' : ' '));
            
            sb.Append("\n");

            return sb.ToString();
        }

    }


    class QuizShortAnswer : QuizQuestion
    {

        public QuizShortAnswer(string baseName) : base(baseName)
        {
            ;
        }

        public string getTitle()
        {
            int len = text.Length < 35 ? text.Length : 35;
            return text.Substring(0, len);
        }

        public override string toD2LString( )
        {
            StringBuilder sb = new StringBuilder("//Short Answer Type\nNewQuestion,SA\n");
            sb.AppendFormat("ID,{0}-{1}\n", base.baseName,id);
            sb.AppendFormat("Title,SA-\"{0}\"\n", getTitle());
            sb.AppendFormat("QuestionText,\"{0}\"\n", text);
            sb.Append("Points,5\n");
            sb.Append("InputBox,3,40\n");
            if (feedback == 1)
            {
                sb.AppendFormat("Feedback,\"{0}\",\"{1}\"\n", feedback_ok, feedback_nok);
            }
            sb.Append("\n");

            return sb.ToString();
        }

        public override string toGSString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("######### Short Answer ##########");
            sb.Append(text);
            sb.Append("\n");
            sb.Append("|____|");
            sb.Append("\n");
            return sb.ToString();
        }

    }


    class Quiz
    {
        public List<QuizQuestion> questions { get; } = new List<QuizQuestion>();
        public int id { get; set; }
        public string name { get; set; }
        public string baseName { get; set; }

        public void parse(string xml)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xml);

            // get the root quiz info
            var root = xdoc.SelectSingleNode("Quiz");
            for (int i = 0; i < root.Attributes.Count; i++)
            {
                 if (root.Attributes[i].Name.Equals("id"))
                {
                    this.id = Int32.Parse(root.Attributes[i].Value);
                }
                else if (root.Attributes[i].Name.Equals("name"))
                {
                    this.name = root.Attributes[i].Value;
                }
            }

            var nodes = xdoc.SelectNodes("Quiz/Questions");
            foreach (XmlNode child in nodes)
            {
                foreach (XmlNode qnode in child.ChildNodes)
                {
                    // select every multiple choice node
                    if (!(qnode is System.Xml.XmlElement))
                        continue;

                    XmlElement qelem = (XmlElement)qnode;


                    if (qelem.Name.Equals("MultipleChoice"))
                    {
                        parseMultipleChoice(qnode, qelem);
                    }
                    else if (qelem.Name.Equals("Logical"))
                    {
                        parseLogical(qnode, qelem);
                    }
                    else if (qelem.Name.Equals("ShortAnswer"))
                    {
                        parseShortAnswer(qnode, qelem);
                    }
                    else if (qelem.Name.Equals("FillBlank"))
                    {
                        parseFIB(qnode, qelem);
                    }
                    
                } // end for each question type

            } // end for each child node

        } // end parse

        void parseMultipleChoice(XmlNode qnode, XmlElement qelem)
        {
            QuizMultipleChoice mc = new QuizMultipleChoice(this.baseName);
            mc.id = Int32.Parse(qelem.GetAttribute("id"));
            mc.text = qelem.GetAttribute("text");
            mc.feedback = Int32.Parse(qelem.GetAttribute("feedback"));
            mc.feedback_ok = qelem.GetAttribute("fb_correct");
            mc.feedback_nok = qelem.GetAttribute("fb_wrong");

            // still need to handle answers
            foreach (XmlNode ansnode in qnode.SelectNodes("./Answers/Answer"))
            {
                if (ansnode is System.Xml.XmlElement)
                {
                    XmlElement ansel = (XmlElement)ansnode;
                    Answer a = new Answer();
                    a.id = Int32.Parse(ansel.GetAttribute("id"));
                    a.text = ansel.GetAttribute("text");
                    a.correct = Int32.Parse(ansel.GetAttribute("iscorrect"));

                    mc.answers.Add(a);
                }
            }

            this.questions.Add(mc);
        }

        void parseFIB(XmlNode qnode, XmlElement qelem)
        {
            QuizFillInBlank mc = new QuizFillInBlank(this.baseName);
            mc.id = Int32.Parse(qelem.GetAttribute("id"));
            mc.text = qelem.GetAttribute("text");
            mc.feedback = Int32.Parse(qelem.GetAttribute("feedback"));
            mc.feedback_ok = qelem.GetAttribute("fb_correct");
            mc.feedback_nok = qelem.GetAttribute("fb_wrong");

            // still need to handle answers
            foreach (XmlNode ansnode in qnode.SelectNodes("./Answers/Answer"))
            {
                if (ansnode is System.Xml.XmlElement)
                {
                    XmlElement ansel = (XmlElement)ansnode;
                    Answer a = new Answer();
                    a.id = Int32.Parse(ansel.GetAttribute("id"));
                    a.text = ansel.GetAttribute("text");
                    a.correct = Int32.Parse(ansel.GetAttribute("iscorrect"));

                    mc.answers.Add(a);
                }
            }

            this.questions.Add(mc);
        }

        void parseShortAnswer(XmlNode qnode, XmlElement qelem)
        {
            QuizShortAnswer shortAns = new QuizShortAnswer(this.baseName);
            shortAns.id = Int32.Parse(qelem.GetAttribute("id"));
            shortAns.text = qelem.GetAttribute("text");
            shortAns.feedback = Int32.Parse(qelem.GetAttribute("feedback"));
            shortAns.feedback_ok = qelem.GetAttribute("fb_correct");
            shortAns.feedback_nok = qelem.GetAttribute("fb_wrong");

            this.questions.Add(shortAns);
        }

        void parseLogical(XmlNode qnode, XmlElement qelem)
        {
            QuizLogical logical = new QuizLogical(this.baseName);
            logical.id = Int32.Parse(qelem.GetAttribute("id"));
            logical.text = qelem.GetAttribute("text");
            logical.istrue = Int32.Parse(qelem.GetAttribute("istrue"));
            logical.feedback = Int32.Parse(qelem.GetAttribute("feedback"));
            logical.feedback_ok = qelem.GetAttribute("fb_correct");
            logical.feedback_nok = qelem.GetAttribute("fb_wrong");

            this.questions.Add(logical);
        }


        public string toD2LString( )
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("//Converted file {0}\n",
                QuizModelFactory.getModel().CamtasiaFileName);


            foreach (QuizQuestion question in questions)
            {
                string d2l = question.toD2LString();
                sb.Append(d2l);

            }

            return sb.ToString();
        }

        public string toGSString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("###### Converted file {0} #####\n",
                QuizModelFactory.getModel().CamtasiaFileName);


            foreach (QuizQuestion question in questions)
            {
                string d2l = question.toGSString();
                sb.Append(d2l);

            }

            return sb.ToString();
        }


    } // end class Quiz

    class QuizConverter
    {
        QuizModel model = QuizModelFactory.getModel();

        public string readProjectFile( )
        {
            return File.ReadAllText(model.CamtasiaFileName);
        }

        public string baseName( )
        {
            return Path.GetFileNameWithoutExtension(model.CamtasiaFileName);
        }

        public void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            
        }

        enum format { D2L, GS };

        public void convertQuiz(string txtCamProject)
        {
            convertQuizFormat(format.D2L, txtCamProject);
        }

        public void convertGS(string txtCamProject)
        {
            convertQuizFormat(format.GS, txtCamProject);
        }


        private void convertQuizFormat(format fmt, string txtCamProject)
        {

            string pattern1 = @"-\d*\.\d+e[+-]\d+";
            string pattern2 = @"\d*\.\d+e[+-]\d+";
            txtCamProject = Regex.Replace(txtCamProject, pattern1, "-20.0", RegexOptions.Multiline);
            txtCamProject = Regex.Replace(txtCamProject, pattern2, "20.0", RegexOptions.Multiline);
            

            JObject camProject = JObject.Parse(txtCamProject);

            System.IO.StreamWriter file =
                new System.IO.StreamWriter(model.QuizFile);

            // get JSON result objects into a list
            if ((!camProject.ContainsKey("timeline")) || (camProject["timeline"] == null))
            {
                Console.WriteLine("No timeline key");
                return;
            }

            if (camProject["timeline"]["parameters"] == null)
            {
                Console.WriteLine("No parameters in timeline.");
                return;
            }

            if (camProject["timeline"]["parameters"] == null)
            {
                Console.WriteLine("No Quiz in timeline parameters");
                return;
            }

            if (camProject["timeline"]["parameters"]["quiz"] == null)
            {
                Console.WriteLine("No Keyframes in timeline parameters quiz.");
                return;
            }

            if (camProject["timeline"]["parameters"]["quiz"]["keyframes"] == null)
            {
                Console.WriteLine("No quizzes found.");
            }

            IList<JToken> results = camProject["timeline"]["parameters"]["quiz"]["keyframes"].Children().ToList();
            
            foreach (JToken result in results)
            {

                if (result["value"] != null)
                {
                    Quiz Q = new Quiz();
                    Q.baseName = baseName();

                    Console.WriteLine(result["value"]);
                    Q.parse(result["value"].ToString());

                    if (fmt == format.D2L)
                    {
                        string converted = Q.toD2LString();
                        file.Write(converted);
                    }
                    else
                    {
                        string converted = Q.toGSString();
                        file.Write(converted);
                    }
                }
            }

            file.Close();
        }

        
    }
}
