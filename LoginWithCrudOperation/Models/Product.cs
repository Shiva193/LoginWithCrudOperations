using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginWithCrudOperation.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int ActualPrice { get; set; }
        public int FinalPrice { get; set; }
        public int OfferPrice { get; set; }
        public int SaleCommission { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }
        public string ImagePath4 { get; set; }

    }
}

