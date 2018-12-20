using payment_plan_calculator.Model;
using payment_plan_calculator.Service.Domain.Interface;
using System.Collections.Generic;

namespace payment_plan_calculator.Service
{
    public class DecreasingInstallmentPlanner : IInstallmentPlanner
    {
        public List<Installment> CreateNew(int loanValue, int totalMonthNumber, decimal interest)
        {
            throw new System.NotImplementedException();
        }
    }
}