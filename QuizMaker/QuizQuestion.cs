using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class QuizQuestion
    {
        public string question { get; set; }
        public List<string> questionOption { get; set; }
        public string correctOption { get; set; }


    }
}
