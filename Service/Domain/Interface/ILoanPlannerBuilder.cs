using payment_plan_calculator.Model;
using System.Collections.Generic;

namespace payment_plan_calculator.Service.Domain.Interface
{
    public interface ILoanPlannerBuilder
    {
        List<Installment> GetInstallmentPlan(int loanTypeId, int loanValue, int repaymentPeriod);
    }
}