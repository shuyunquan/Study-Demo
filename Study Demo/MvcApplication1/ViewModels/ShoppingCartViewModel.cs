using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MvcApplication1.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}