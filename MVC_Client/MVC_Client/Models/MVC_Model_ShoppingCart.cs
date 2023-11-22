using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Client.Models
{
    public class MVC_Model_ShoppingCart
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public int  Quantity { get; set; }
        public int ProductId { get; set; }
        public DateTime DateCreated { get; set; }
       

    }
}