using AutoMapper;
using payment_plan_calculator.Controllers.Resources;
using payment_plan_calculator.Model;

namespace payment_plan_calculator.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Installment, InstallmentResource>();
            // API Resource to Domain
        }
    }
}