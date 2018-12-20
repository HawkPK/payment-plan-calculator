export class InstallmentResource {
    constructor(
        public month: Number,
        public installment: Number,
        public interest: Number,
        public asset: Number,
    ){}
}