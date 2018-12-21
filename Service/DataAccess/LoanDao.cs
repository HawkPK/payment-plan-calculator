using payment_plan_calculator.Model;
using payment_plan_calculator.Service.DataAccess.Interface;
using payment_plan_calculator.Service.DataAccess.Persistence;
using System.Collections.Generic;

namespace payment_plan_calculator.Service.DataAccess
{
    public class LoanDao : ILoanDao
    {
        private ILoanOfferRepository _loanOfferRepository;
        public LoanDao() : this(new LoanOfferRepository())
        {
        }
        public LoanDao(ILoanOfferRepository loanOfferRepository)
        {
            _loanOfferRepository = loanOfferRepository;
        }
        public IEnumerable<LoanOffer> GetAllOferts()
        {
            var loanOffers = _loanOfferRepository.GetLoanOffers();
            return (IEnumerable<LoanOffer>)loanOffers;
        }

        public LoanOffer GetLoanDetail(int loanOfferId)
        {
            var loanOffer = _loanOfferRepository.GetLoanOffer(loanOfferId);
            return loanOffer;
        }
    }
}