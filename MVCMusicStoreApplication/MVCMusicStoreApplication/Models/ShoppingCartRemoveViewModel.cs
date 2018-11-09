using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStoreApplication.Models.ViewModels
{
    public class ShoppingCartRemoveViewModel
    {
        public int DeleteId;
        public decimal CartTotal;
        public int ItemCount;
        public int CartCount;
        public string Message;
    }
}