using payment_plan_calculator.Model;
using payment_plan_calculator.Service.Code;
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

            return installmentPlan;
        }
    }

    public class LoanDao : ILoanDao
    {
        public IEnumerable<Ofert> GetAllOferts()
        {
            var loanDetail = new Ofert()
            {
                Id = 1,
                Interest = 0.035m,
                Type = IntallmentType.Equal
            };

            List<Ofert> loanOfferts = new List<Ofert>();
            loanOfferts.Add(loanDetail);
            return (IEnumerable<Ofert>)loanOfferts;
        }

        public Ofert GetLoanDetail(int ofertId)
        {
            var ofertDetail = new Ofert()
            {
                Id = 1,
                Interest = 0.035m,
                Type = IntallmentType.Equal
            };

            return ofertDetail;
        }
    }

    public class Ofert
    {
        public int Id { get; internal set; }
        public decimal Interest { get; internal set; }
        public string Type { get; internal set; }
    }

    public interface ILoanDao
    {
       IEnumerable<Ofert> GetAllOferts();
       Ofert GetLoanDetail(int ofertId);
    }
}