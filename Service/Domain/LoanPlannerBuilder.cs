using payment_plan_calculator.Model;
using payment_plan_calculator.Service.Code;
using payment_plan_calculator.Service.DataAccess;
using payment_plan_calculator.Service.DataAccess.Interface;
using System.Collections.Generic;

namespace payment_plan_calculator.Service.Domain.Interface
{
    public class LoanPlannerBuilder : ILoanPlannerBuilder
    {
        private IInstallmentPlanner _installmentPlanner;
        private ILoanDao _loanDao;
        public LoanPlannerBuilder() : this(new EqualInstallmentPlanner(), new LoanDao())
        {
        }

        public LoanPlannerBuilder(IInstallmentPlanner installmentPlanner, ILoanDao loanDao)
        {
            _installmentPlanner = installmentPlanner;
            _loanDao = loanDao;
        }
        public List<Installment> GetInstallmentPlan(int loanTypeId, int loanValue, int repaymentPeriod)
        {
            var installmentPlan = new List<Installment>();
            var loanDetail = _loanDao.GetLoanDetail(loanTypeId);

            if(loanDetail.Type == IntallmentType.Equal)
            {
                installmentPlan = _installmentPlanner.CreateNew(loanValue, repaymentPeriod, loanDetail.Interest);
            }

            installmentPlan = _installmentPlanner.CreateNew(loanValue, repaymentPeriod, loanDetail.Interest);
            return installmentPlan;
        }
    }
}