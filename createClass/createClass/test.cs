using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createClass
{
    class kullanici
    {
        private string _name;
        private string _surname;
        private string _email;
        private string _password;
        private string _guid;

        public string name
        {

            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }


        }

        public string email
        {
            get { return _email; }
            set
            {
                if (!value.Contains("@"))
                { throw new Exception("hatalı mail adresi"); }
                else if (value.Contains("@"))
                { _email = value; }
            }
        }

        public string surName
        {

            get { return _surname; }
            set { _surname = value; }


        }

        public string setName(string name, string surName)
        {
            string fullName = name + " " + surName;
            return fullName;
        }
    }
}
