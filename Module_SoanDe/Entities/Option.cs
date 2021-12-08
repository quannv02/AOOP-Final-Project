using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_SoanDe.Entities
{
    internal class Option
    {
        private String _content = "";
        private Boolean _isTrue = false;

        public String Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public Boolean IsTrue
        {
            get { return _isTrue; }
            set { _isTrue = value; }
        }

        public override String ToString()
        {
            return $"{Content} - {IsTrue.ToString()}";
        }
    }
}
