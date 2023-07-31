using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
 
        public int ID { get; set; }
        public string NAME { get; set; }
        public decimal PRICE { get; set; }
        public int STOCK { get; set; }
    }
}
