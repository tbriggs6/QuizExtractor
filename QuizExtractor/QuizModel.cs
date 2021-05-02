using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExtractor
{
    class QuizModel
    {
        public string CamtasiaFileName { get; set;  }
        public string QuizFile { get; set;  }
        public string ConversionStatus { get; set; }
    }

    class QuizModelFactory
    {
        static QuizModel model = new QuizModel();

        public static QuizModel getModel() { return model; }
    }
}
