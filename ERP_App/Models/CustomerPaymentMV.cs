using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP_App.Models
{
    public partial class CustomerPaymentMV
    {
        public int CustomerPaymentID { get; set; }
        public int CustomerID { get; set; }
        public int CustomerInvoiceID { get; set; }
        public int BranchID { get; set; }
        public int CompanyID { get; set; }
        public string InvoiceNo { get; set; }
        public double TotalAmount { get; set; }
        public double PaidAmount { get; set; }
        public double RemainingBalance { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
    

    }
}
