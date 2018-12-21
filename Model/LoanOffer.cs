namespace payment_plan_calculator.Model
{
    public class LoanOffer
    {
        public int Id { get; internal set; }
        public decimal Interest { get; internal set; }
        public string Type { get; internal set; }
        public string Name { get; internal set; }
    }
}