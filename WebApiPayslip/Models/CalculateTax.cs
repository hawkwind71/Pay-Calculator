using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPayslip {
    public class CalculateTax {
        public Payslip CalculatePayment(Payslip payslip, List<TaxableIncom> tax) {
            var taxes = tax.Where(x => 
                x.FromAmount <= payslip.AnnualSalary && 
                (x.ToAmount >= payslip.AnnualSalary || x.ToAmount == -1) &&
                new DateTime(payslip.PaymentYear, payslip.PaymentMonth,1)  >= new DateTime(x.FromYear, x.FromMonth, 1) &&
                new DateTime(payslip.PaymentYear, payslip.PaymentMonth, 1) <= new DateTime(x.ToYear, x.FromMonth, 1).AddMonths(1).AddDays(-1));
            if (taxes != null && taxes.Count() > 0) {
                var _tax = taxes.SingleOrDefault();
                DateTime pday = new DateTime(payslip.PaymentYear, payslip.PaymentMonth, 1);
                payslip.PaymentMonthName = pday.ToString("MMMM");
                payslip.GrossIncome = Math.Round(payslip.AnnualSalary / 12, 0, MidpointRounding.ToEven);
                payslip.IncomeTax = Math.Round((_tax.TaxBaseValue + (payslip.AnnualSalary - (_tax.FromAmount - 1)) * (_tax.TaxExtra / 100)) / 12, 0, MidpointRounding.ToEven);
                payslip.NetIncome = payslip.GrossIncome - payslip.IncomeTax;
                payslip.Super = Math.Round(payslip.GrossIncome * (payslip.SuperRate / 100), 0, MidpointRounding.ToEven);
            }
            return payslip;
        }        
    }
}