using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPayslip {

    
    public class Payslip {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PaymentMonth { get; set; }
        public string PaymentMonthName { get; set; }
        public int PaymentYear { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal NetIncome { get; set; }
        public decimal Super { get; set; }
        public decimal SuperRate { get; set; }
        public decimal IncomeTax { get; set; }
    }

    public class TaxableIncom {        
        public decimal FromAmount { get; set; }
        public decimal ToAmount { get; set; }
        public decimal TaxBaseValue { get; set; }
        public decimal TaxExtra { get; set; }
        public int FromMonth { get; set; }
        public int FromYear { get; set; }
        public int ToMonth { get; set; }
        public int ToYear { get; set; }
        public List<TaxableIncom> incomeTaxList { get; set; }
    }
}