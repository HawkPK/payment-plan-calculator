export class LoanResource {
    constructor(
        public value: Number,
        public repaymentPeriod: Number,
        public loanOfferId: Number,
        public loanOfferType: String,
        public interest: Number
    ){}
}
