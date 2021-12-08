using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_SoanDe.Entities
{
    internal class Quiz
    {
        private int _id;
        private String _topic = "";
        private String _question = "";
        private List<Option> _answers = new List<Option>();

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public String Topic
        {
            get { return _topic; }
            set { _topic = value; }
        }

        public String Question
        {
            get { return _question; }
            set { _question = value; }
        }

        public List<Option> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }

        public int Compare(Quiz q)
        {
            return String.Compare(this.Question, q.Question);
        }

        public override string ToString()
        {
            return Question;
        }
    }
}
