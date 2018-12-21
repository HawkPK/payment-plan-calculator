
using payment_plan_calculator.Model;
using payment_plan_calculator.Service.Code;
using payment_plan_calculator.Service.DataAccess.Interface;
using payment_plan_calculator.Service.Domain.Interface;
using System.Collections.Generic;
using System.Linq;

namespace payment_plan_calculator.Service.DataAccess.Persistence
{
    public class LoanOfferRepository : ILoanOfferRepository
    {
        private static List<LoanOffer> _loanOffers;

        public LoanOfferRepository()
        {
            if(_loanOffers is null)
            {
                _loanOffers = new List<LoanOffer>();
                var loanMortgageDetail = new LoanOffer()
                {
                    Id = 1,
                    Interest = 0.035m,
                    Type = IntallmentType.Equal,
                    Name = LoanName.Mortgage,
                };
                _loanOffers.Add(loanMortgageDetail);

                var loanCarOffer = new LoanOffer()
                {
                    Id = 2,
                    Interest = 0.095m,
                    Type = IntallmentType.Decreasing,
                    Name = LoanName.Car,
                };
                _loanOffers.Add(loanCarOffer);
            }
        }

        public LoanOffer GetLoanOffer(int loanOfferId)
        {
            return _loanOffers.FirstOrDefault(x => x.Id == loanOfferId);
        }

        public List<LoanOffer> GetLoanOffers()
        {
            return _loanOffers;
        }
    }
}
