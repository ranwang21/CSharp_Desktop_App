using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Person
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public bool gender { get; set; }
        public DateTime birthday { get; set; }
        public string address { get; set; }
        public string mobile { get; set; }
    }
}
