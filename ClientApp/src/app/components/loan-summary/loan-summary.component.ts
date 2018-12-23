import { Component, OnInit, Input, OnChanges } from '@angular/core';

@Component({
  selector: 'loan-summary',
  templateUrl: './loan-summary.component.html',
  styleUrls: ['./loan-summary.component.css']
})
export class LoanSummaryComponent implements OnInit {

  @Input('loanResource') loanResource;
  @Input('installments') installments;
  private minInstallmentValue: number;
  private maxInstallmentValue: number;
  
  constructor() { }

  ngOnInit() {
    this.minInstallmentValue = this.installments[0].installment;
    this.maxInstallmentValue = this.installments[this.installments.length-1].installment;
  }

  checkIsEqualInstallmentType(){
    var equalType = "Equal";
    if(this.loanResource.loanOfferType == equalType){
      return true;
    }
    return false;
  }

}
