using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantManagementApp.BusinessLayer.ViewModels
{
    public class MerchantViewModel
    {
        public int MerchantId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
