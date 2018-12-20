using AutoMapper;
using payment_plan_calculator.Controllers.Resources;
using payment_plan_calculator.Mapping.Interface;
using payment_plan_calculator.Model;

namespace payment_plan_calculator.Mapping
{
    public class InstallmentResourceMapper : IResourceMapper
    {
        private IMapper _mapper;
        public InstallmentResourceMapper(IMapper mapper)
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
    }
}