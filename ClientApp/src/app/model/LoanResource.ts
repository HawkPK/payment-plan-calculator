export class LoanResource {
  loanTypeId: string;
    constructor(
        public value: Number = 250000,
        public repaymentPeriod: Number = 10,
        public loanType: String = "Nic",
    ){}
}