using payment_plan_calculator.Model;
using payment_plan_calculator.Service.Domain.Interface;
using System.Collections.Generic;
using System.Linq;

namespace payment_plan_calculator.Service.DataAccess.Interface
{
    public interface ILoanOfferRepository
    {
        List<LoanOffer> GetLoanOffers();
        LoanOffer GetLoanOffer(int loanOfferId);
    }
}
