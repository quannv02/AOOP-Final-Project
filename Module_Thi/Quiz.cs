using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Thi
{
    public class Quiz
    {
        private int _id;
        private String _question = "";
        private List<String> _option = new List<string>();
        private int _selected = -1;
        private bool _done = false;
        private bool _consider = false;

        public int ID 
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Question
        {
            get { return _question; }
            set { _question = value; }
        }

        public List<String> Option
        {
            get { return _option; }
            set { _option = value; }
        }

        public int Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public bool Done
        {
            get { return _done; }
            set { _done = value; }
        }

        public bool Consider
        {
            get { return _consider; }
            set { _consider = value; }
        }

        public Quiz Clone()
        {
            Quiz q = new Quiz();
            ID = q.ID;
            q.Question = Question;
            q.Option = Option;
            q.Selected = Selected;
            q.Done = Done;
            q.Consider = Consider;
            return q;
        }

        public override string ToString()
        {
            String status1 = "";
            String status2 = "";
            if (Done == true)
                status1 = " - Đã làm";
            if (Consider == true)
                status2 = " - Cần xem lại";
            return $"Câu {ID}{status1}{status2}";
        }
    }
}
