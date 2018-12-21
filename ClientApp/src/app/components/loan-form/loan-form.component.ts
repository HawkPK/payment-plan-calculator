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
  private _installements: InstallmentResource[];
  private _loanResource: LoanResource = new LoanResource(0,0,0,"",0.0);
  private _loanOfferResources: LoanOfferResource[];
  private _error = false;

  constructor(private _creditService: CreditService) { 
  }

  ngOnInit() {
    this._creditService.GetLoanOfferts().subscribe( data => {
      this._loanOfferResources = data as LoanOfferResource[];
      var loanOfferResource = this._loanOfferResources[0];
      this._loanResource = new LoanResource(25000,10,loanOfferResource.id,loanOfferResource.type,loanOfferResource.interest);
    });
   
  }

  calculate(loadResource: LoanResource){
    if(!this._creditService.CheckIsLoanValid(loadResource)){
      this._error = true;
    } else {
      this._error = false;
      this._creditService.GetInstallmentsPerMonth(loadResource).subscribe( data => {
        this._installements = data as InstallmentResource[];   
      });
    }
  }

  setLoanOffer(id: Number): void {
    var loanOffer = this._loanOfferResources.filter(x => x.id == id)[0];
    this._loanResource.interest = loanOffer.interest;
    this._loanResource.loanOfferType = loanOffer.type;
    }
}
