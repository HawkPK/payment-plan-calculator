using payment_plan_calculator.Controllers;
using payment_plan_calculator.Controllers.Resources;
using payment_plan_calculator.Model;
using payment_plan_calculator.Service.Domain.Interface;
using System.Collections.Generic;

namespace payment_plan_calculator.Mapping.Interface
{
    public interface IResourceMapper
    {
        InstallmentResource MapToInstallmentResource(Installment installment);
        IEnumerable<OfferResource> MapToOfferResource(IEnumerable<LoanOffer> offers);
    }
}
