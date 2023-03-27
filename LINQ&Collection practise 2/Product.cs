using System;
using System.Runtime.Remoting.Messaging;

namespace LINQ_Collection_practise_2
{
     class Product
    {
        public string Name { get; set; }    
        public int Energy { get; set; }

        public override string ToString()
        {
            return $"{Name}({Energy})";
        }
    }
}
