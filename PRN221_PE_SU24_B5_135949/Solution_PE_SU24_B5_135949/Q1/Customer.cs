using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class Customer
    {
        public int ID{ get; set; }
        public string Name{ get; set; }

        public DateTime DOB{ get; set; }

        public Customer(int iD, string name, DateTime dOB)
        {
            ID = iD;
            Name = name;
            DOB = dOB;
        }

        public Customer()
        {
        }

        public override string ToString()
        {
            return ID + " " + Name + " " + DOB;
        }
    }
}
