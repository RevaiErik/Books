using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1219
{
    internal class Author
    {
        private string lastName;
        private string firstName;

        public string LastName { get => lastName;
            set {
                if (value.Length < 3 || value.Length > 32)
                    throw new ArgumentException("Invalid Lastname");
                lastName = value; }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (value.Length < 3 || value.Length > 32)
                    throw new ArgumentException("Invalid Firstname");
                firstName = value;
            }
        }
        public Guid GUID { get; set; }

        public Author(string fullname)
        {
            GUID = Guid.NewGuid();
            string[] nps = fullname.Split(' ');
            FirstName = nps[0];
            LastName = nps[1];
        }
    }
}
