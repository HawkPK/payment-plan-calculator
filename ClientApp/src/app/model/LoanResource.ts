export class LoanResource {
    constructor(
        public value: Number = 25000,
        public repaymentPeriod: Number = 10,
        public loanOfferId: Number = 1,
        public loanOfferType: String = "",
        public interest: Number = 0
    ){}
}
