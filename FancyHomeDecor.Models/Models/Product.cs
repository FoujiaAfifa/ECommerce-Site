using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyHomeDecor.Models.Models
{
   public class Product:BaseModel
    {

        public decimal Price { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
