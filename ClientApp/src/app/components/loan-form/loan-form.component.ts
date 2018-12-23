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
  private _installmentsCount: number = 0;
  private _installementsPageSource: InstallmentResource[];
  private _loanResource: LoanResource;
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
  calculate(loadResource: LoanResource){
    if(!this._creditService.CheckIsLoanValid(loadResource)){
      this._error = true;
      this._installmentsCount = 0;
    } else {
      this._error = false;
      this._creditService.GetInstallmentsPerMonth(loadResource).subscribe( data => {
        this._installments = data as InstallmentResource[]; 
        this._installmentsCount = this._installments.length;
        this._installementsPageSource =  this._installments.slice(0,this._pageSize); 
      });
      
    }
  }
  setDefaultLoanOffer(){
    var defaultLoanOfferId = 1;
    if(this._loanResource){
      this._loanResource = new LoanResource();
      this.setLoanOffer(defaultLoanOfferId);
    }
  }
  setLoanOffer(id: Number): void {
    var loanOffer = this._loanOfferResources.filter(x => x.id == id)[0];
    this._loanResource.interest = loanOffer.interest;
    this._loanResource.loanOfferId = loanOffer.id;
    this._loanResource.loanOfferType = loanOffer.type;
    this._installmentsCount = 0;
    }

  onPageChange(page){
    var rightBorder = page * this._pageSize;
    var leftBorder = rightBorder - this._pageSize;
    this._installementsPageSource = this._installments.slice(leftBorder, rightBorder);
  }
}
