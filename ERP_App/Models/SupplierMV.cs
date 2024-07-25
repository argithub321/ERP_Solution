using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP_App.Models
{
    public partial class SupplierMV
    {
    
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierConatctNo { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierEmail { get; set; }
        public string Discription { get; set; }
        public int BranchID { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
    

    }
}
