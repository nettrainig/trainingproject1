using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {            
            foreach (var prop in x.GetType().GetProperties())
                if (prop.IsDefined(typeof(UseForEqualityCheck), true))
                {
                    var value1 = x.GetType().GetProperty(prop.Name).GetValue(x).ToString();
                    var value2 = y.GetType().GetProperty(prop.Name).GetValue(y).ToString();
                    if (value1 != value2)
                        return false;
                }
            return true;
        }

        public int GetHashCode(Product obj)
        {
            foreach (var prop in obj.GetType().GetProperties())
                if (prop.IsDefined(typeof(UseForEqualityCheck), true))
                    return prop.GetValue(obj).GetHashCode();
            return obj.GetHashCode();
        }
    }
}
