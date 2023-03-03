using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class Contact : IComparable<Contact>
    {

        public string firstName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string lastName { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string Phone { get; set; }
        public string email { get; set; }


        public int CompareTo(Contact other)
        {
            return this.firstName.CompareTo(other.firstName);
        }
        

        public override string ToString()
        {
            return $"Name: {firstName} {lastName} , City: {city} , State: {state} , ZIP: {zip} , Phone: {Phone} , Email : {email}";
        }

    }
}
