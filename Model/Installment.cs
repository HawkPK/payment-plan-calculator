namespace payment_plan_calculator.Model
{
    public class Installment
    {
        public int Id { get; internal set; }
        public decimal Interest { get; internal set; }
        public decimal Asset { get; internal set; }
    }
}