using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPayslip.Controllers
{
    [RoutePrefix("api/Payment")]
    public class PayController : ApiController
    {
        //In memory data 
        List<TaxableIncom> taxList = new List<TaxableIncom>(){            
                new TaxableIncom { FromAmount = 0, ToAmount=18200, FromYear=2012, FromMonth=6, TaxBaseValue=0, TaxExtra=0, ToMonth=6, ToYear=2013},
                new TaxableIncom { FromAmount = 18201, ToAmount=37000, FromYear=2012, FromMonth=6, TaxBaseValue=0, TaxExtra=19, ToMonth=6, ToYear=2013},
                new TaxableIncom { FromAmount = 37001, ToAmount=80000, FromYear=2012, FromMonth=6, TaxBaseValue=3572, TaxExtra=32.5M, ToMonth=6, ToYear=2013},
                new TaxableIncom { FromAmount = 80001, ToAmount=180000, FromYear=2012, FromMonth=6, TaxBaseValue=17547, TaxExtra=37, ToMonth=6, ToYear=2013},
                new TaxableIncom { FromAmount = 180001, ToAmount=-1, FromYear=2012, FromMonth=6, TaxBaseValue=54547, TaxExtra=45, ToMonth=6, ToYear=2013}
            };

        [Route("Get")]
        [HttpPost]
        public IHttpActionResult GetPayslip(Payslip payslip) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            //init tax list
            TaxableIncom tax=new TaxableIncom();
            tax.incomeTaxList = taxList;            
            //call calculator
            CalculateTax calc = new CalculateTax();
            payslip = calc.CalculatePayment(payslip, tax.incomeTaxList);
            return Ok(payslip);
        }
    }
}
