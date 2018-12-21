using payment_plan_calculator.Model;
using payment_plan_calculator.Service.Code;
using payment_plan_calculator.Service.DataAccess;
using payment_plan_calculator.Service.DataAccess.Interface;
using System.Collections.Generic;

namespace payment_plan_calculator.Service.Domain.Interface
{
    public class LoanPlannerBuilder : ILoanPlannerBuilder
    {
        private IInstallmentPlanner _equalInstallmentPlanner;
        private IInstallmentPlanner _decreasingInstallmentPlanner;
        private ILoanDao _loanDao;
        public LoanPlannerBuilder() : this(new EqualInstallmentPlanner(), new EqualInstallmentPlanner(), new LoanDao())
        {
        }

        public LoanPlannerBuilder(IInstallmentPlanner equalInstallmentPlanner, IInstallmentPlanner decreasingInstallmentPlanner, ILoanDao loanDao)
        {
            _equalInstallmentPlanner = equalInstallmentPlanner;
            _decreasingInstallmentPlanner = decreasingInstallmentPlanner;
            _loanDao = loanDao;
        }
        public List<Installment> GetInstallmentPlan(int loanTypeId, int loanValue, int repaymentPeriod)
        {
            var installmentPlan = new List<Installment>();
            var loanDetail = _loanDao.GetLoanDetail(loanTypeId);

            if(loanDetail.Type == IntallmentType.Equal)
            {
                installmentPlan = _equalInstallmentPlanner.CreateNew(loanValue, repaymentPeriod, loanDetail.Interest);
            }

            if (loanDetail.Type == IntallmentType.Decreasing)
            {
                installmentPlan = _decreasingInstallmentPlanner.CreateNew(loanValue, repaymentPeriod, loanDetail.Interest);
            }
       
            return installmentPlan;
        }
    }
}