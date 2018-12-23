using payment_plan_calculator.Model;
using payment_plan_calculator.Service.Domain.Interface;
using System.Collections.Generic;

namespace payment_plan_calculator.Service
{
    public class DecreasingInstallmentPlanner : IInstallmentPlanner
    {
        public List<Installment> CreateNew(int loanValue, int totalMonthNumber, decimal interest)
        {
            var installments = new List<Installment>();
            decimal asset = (decimal)loanValue / totalMonthNumber;
            decimal loanValueToPay = loanValue;
            for (var i = 1; i <= totalMonthNumber; i++)
            {
                var installment = new Installment()
                {
                    Id = i,
                    Asset = asset,
                    Interest = loanValueToPay * interest,
                };
                installments.Add(installment);
                loanValueToPay -= asset;
            }
            return installments;
        }
    }
}