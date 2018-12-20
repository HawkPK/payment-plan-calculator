using payment_plan_calculator.Controllers.Resources;
using payment_plan_calculator.Model;

namespace payment_plan_calculator.Mapping.Interface
{
    public interface IResourceMapper
    {
        InstallmentResource MapToInstallmentResource(Installment installment);
    }
}
