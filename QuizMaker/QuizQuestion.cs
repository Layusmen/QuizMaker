using System;
using System.Linq;
using System.Xml.Linq;

namespace QuizMaker
{
    public class QuizQuestion
    {
        public string question { get; set; }
        public List<string> questionOption { get; set; }
        public string correctOption { get; set; }
    }
}
