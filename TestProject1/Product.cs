using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    class Product: IComparable
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public int CompareTo(object obj)
        {
            return string.Compare(Code, (obj as Product).Code);
        }
    }
}
