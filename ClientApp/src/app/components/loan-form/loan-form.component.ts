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
  private _loanResource: LoanResource;
  private _loanOfferResources: LoanOfferResource[];

  constructor(private _creditService: CreditService) { 
  }

  ngOnInit() {
    this._creditService.GetLoanOfferts().subscribe( data => {
      this._loanOfferResources = data as LoanOfferResource[];
      var loanOfferResource = this._loanOfferResources[0];
      this._loanResource = new LoanResource(25000,10,loanOfferResource.id,loanOfferResource.type,loanOfferResource.interest);
      this._loanOfferResources.forEach(function(element){
        console.log("The value of the credit amount is " + element.id + " " + element.type);
      })
    });
   
  }

  calculate(loadResource: LoanResource){
    this._creditService.GetInstallmentsPerMonth(loadResource).subscribe( data => {
      this._installements = data as InstallmentResource[];
      this._installements.forEach(function(element){
        console.log("The value of the credit amount is " + element.month + " " + element.installment);
      })
    
    });
  }

  setLoanOffer(id: Number): void {
    console.log(id);
    var loanOffer = this._loanOfferResources.filter(x => x.id == id)[0];
    this._loanResource.interest = loanOffer.interest;
    this._loanResource.loanOfferType = loanOffer.type;
    }
}
