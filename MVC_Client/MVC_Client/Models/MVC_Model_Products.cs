using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Client.Models
{
    public class MVC_Model_Products
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int ModelNumber { get; set; }
        public string ModelName { get; set; }
        public int UnitCost { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }


    }
}