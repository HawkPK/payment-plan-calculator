using System.Collections.Generic;
using AutoMapper;
using payment_plan_calculator.Controllers;
using payment_plan_calculator.Controllers.Resources;
using payment_plan_calculator.Mapping.Interface;
using payment_plan_calculator.Model;
using payment_plan_calculator.Service.Domain.Interface;

namespace payment_plan_calculator.Mapping
{
    public class ResourceMapper : IResourceMapper
    {
        private IMapper _mapper;
        public ResourceMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public InstallmentResource MapToInstallmentResource(Installment installment)
        {
            var installmentResource = _mapper.Map<Installment, InstallmentResource>(installment);
            installmentResource.Installment = installmentResource.Asset + installmentResource.Interest;
            installmentResource.Month = installment.Id;
            return installmentResource;
        }

        public IEnumerable<OfferResource> MapToOfferResource(IEnumerable<LoanOffer> offers)
        {
            List<OfferResource> offerResources = new List<OfferResource>();
            foreach(var offer in offers)
            {
                var offerResource = _mapper.Map<LoanOffer, OfferResource>(offer);
                offerResources.Add(offerResource);
            }
            return (IEnumerable<OfferResource>)offerResources;
        }
    }
}