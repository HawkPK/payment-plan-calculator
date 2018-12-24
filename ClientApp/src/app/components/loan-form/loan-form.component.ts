import { CreditService } from '../../services/credit.service';
import { Component, OnInit } from '@angular/core';
import { LoanResource } from '../../model/LoanResource';
import { InstallmentResource } from '../../model/InstallmentResource';
import { LoanOfferResource } from '../../model/LoanOfferResource';

@Component({
  selector: 'app-credit-form',
  templateUrl: './loan-form.component.html',
  styleUrls: ['./loan-form.component.css']
})
export class LoanFormComponent implements OnInit {
  private _installments: InstallmentResource[];
  private _isDisplaySummary: boolean = false;
  private _installementsPageSource: InstallmentResource[];
  private _loanResource: LoanResource = new LoanResource();
  private _loanOfferResources: LoanOfferResource[];
  private _pageSize = 10;
  private _error = false;

  constructor(private _creditService: CreditService) { 
  }
  ngOnInit() {
    this._creditService.GetLoanOfferts().subscribe( data => {
      this._loanOfferResources = data as LoanOfferResource[];
      this.setDefaultLoanOffer();
    });
  }
  calculate(loanResource: LoanResource){
    if(!this._creditService.CheckIsLoanValid(loanResource)){
      this._error = true;
      this._isDisplaySummary = false;
    } else {
      this._error = false;
      this._creditService.GetInstallmentsPerMonth(loanResource).subscribe( data => {
        this._installments = data as InstallmentResource[]; 
        this._isDisplaySummary = true;
        this._installementsPageSource =  this._installments.slice(0,this._pageSize); 
      });
    }
  }
  setDefaultLoanOffer(){
    var defaultLoanOfferId = 1;
    this.setLoanOffer(defaultLoanOfferId);
  }
  setLoanOffer(id: Number): void {
    var loanOffer = this._loanOfferResources.filter(x => x.id == id)[0];
    this._loanResource.interest = loanOffer.interest;
    this._loanResource.loanOfferId = loanOffer.id;
    this._loanResource.loanOfferType = loanOffer.type;
    this._isDisplaySummary = false;
  }
  resetCalculation(){
    this._isDisplaySummary = false;
  }
  onPageChange(page){
    var rightBorder = page * this._pageSize;
    var leftBorder = rightBorder - this._pageSize;
    this._installementsPageSource = this._installments.slice(leftBorder, rightBorder);
  }
}
