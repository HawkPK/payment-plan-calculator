namespace payment_plan_calculator.Controllers.Resources
{
    public class InstallmentResource
    {
        public int Month { get; internal set; }
        public decimal Interest { get; internal set; }
        public decimal Asset { get; internal set; }
        public decimal Installment { get; internal set; }
    }
}