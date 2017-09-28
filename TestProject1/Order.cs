using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class Order
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public DateTime DateCreated { get; set; }
        public int Status { get; set; }        
    }
}
