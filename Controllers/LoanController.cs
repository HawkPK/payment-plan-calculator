using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using payment_plan_calculator.Controllers.Resources;
namespace payment_plan_calculator.Controllers
{
    [Route("api/[controller]")]
    public class LoanController
    {
        [HttpGet("[action]")]
        public decimal[] Detail([FromQuery]int value, 
            [FromQuery]int repaymentPeriod, [FromQuery]string loanType)
        {
            if(loanType == "Mortage"){
                Console.WriteLine(value + " Wartosc kredytu," + repaymentPeriod + " czas splaty kredytu");
                decimal[] installments = new decimal[repaymentPeriod];
                decimal installment = value/repaymentPeriod;
                decimal loanCost = (decimal)value;
                for(var i = 0; i < repaymentPeriod; i++){
                    var interst = loanCost*0.035m;
                    Console.WriteLine(interst);
                    installments[i] = installment + interst;
                    Console.WriteLine(installment + interst);
                    loanCost -= installment;
                    Console.WriteLine(loanCost);
                }
            }
            return installments;
        }
    }
}