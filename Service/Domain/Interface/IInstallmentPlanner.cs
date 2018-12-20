using payment_plan_calculator.Model;
using System.Collections.Generic;

namespace payment_plan_calculator.Service.Domain.Interface
{
    public interface IInstallmentPlanner
    {
        List<Installment> CreateNew(int loanValue, int totalMonthNumber, decimal interest);
    }
}