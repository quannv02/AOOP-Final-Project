using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_SoanDe.Entities
{
    internal class TestTaker
    {
        private String _name = "";
        private String _time = "";
        private List<String> _answer = new List<String>();
        private int _correctNum;

        public float Score
        {
            get { return ((float)CorrectNumber / Answer.Count) * 10; }
        }

        public int CorrectNumber
        {
            get { return _correctNum; }
            set { _correctNum = value; }
        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public String Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public List<String> Answer 
        {
            get { return _answer; }
            set { _answer = value; }
        }
    }
}
