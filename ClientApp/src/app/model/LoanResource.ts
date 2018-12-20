export class LoanResource {
    constructor(
        public value: Number = 250000,
        public repaymentPeriod: Number = 10,
        public loanTypeId: Number = 1,
        public loanType: String,
    ){}
}
