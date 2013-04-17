using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Nancy.Rest
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return "{\n\t'Id': " + Id + ",\n\t'Date': '" + Date + "',\n\t'Name': '" + Name + "'\n}";
        }
    }
}
