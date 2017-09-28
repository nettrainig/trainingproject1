using System;

namespace TestProject1
{
    public class Product : IComparable
    {
        public int ID { get; set; }

        [UseForEqualityCheck]
        public string Code { get; set; }

        public string Name { get; set; }

        public Decimal Price { get; set; }

        public int WarehouseID { get; set; }

        public int CompareTo(object obj)
        {
            return string.Compare(Code, (obj as Product).Code);
        }
    }
}
