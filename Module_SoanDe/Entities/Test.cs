using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_SoanDe.Entities
{
    internal class Test
    {
        private List<Quiz> _lstTestQuiz = new List<Quiz>();
        private String _name = "";

        public String Name 
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Quiz> lstTestQuiz
        {
            get { return _lstTestQuiz; }
            set { _lstTestQuiz = value; }
        }

        public override String ToString()
        {
            return Name;
        }
    }
}
