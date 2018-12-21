namespace payment_plan_calculator.Controllers.Resources
{
    public class OfferResource
    {
        public int Id { get; internal set; }
        public decimal Interest { get; internal set; }
        public string Type { get; internal set; }
        public string Name { get; internal set; }
    }
}
