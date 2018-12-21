using payment_plan_calculator.Model;
using System.Collections.Generic;

namespace payment_plan_calculator.Service.DataAccess.Interface
{
    public interface ILoanDao
    {
       IEnumerable<LoanOffer> GetAllOferts();
       LoanOffer GetLoanDetail(int ofertId);
    }
}