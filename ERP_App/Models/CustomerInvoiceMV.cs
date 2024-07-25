
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP_App.Models
{
    public partial class CustomerInvoiceMV
    {       
    
        public int CustomerInvoiceID { get; set; }
        public int CustomerID { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int InvoiceNo { get; set; }
        public string Title { get; set; }
        public int TotalAmount { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }
    
        
    }
}
