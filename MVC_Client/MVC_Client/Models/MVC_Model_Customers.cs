using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Client.Models
{
    public class Customers
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string DeliveryAddress { get; set; }
        public int PhoneNumber { get; set; }
       

    }
}