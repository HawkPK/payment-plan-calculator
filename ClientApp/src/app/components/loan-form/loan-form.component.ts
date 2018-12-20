import { CreditService } from '../../services/credit.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LoanResource } from '../../model/LoanResource';
import { InstallmentResource } from '../../model/InstallmentResource';

@Component({
  selector: 'app-credit-form',
  templateUrl: './loan-form.component.html',
  styleUrls: ['./loan-form.component.css']
})
export class LoanFormComponent implements OnInit {

  private _route: ActivatedRoute;
  private _installements: InstallmentResource[];
  private _loanResource: LoanResource;
  private _loanResources: LoanResource[];
  private _loanTypes: String[] = ["Mortage","Cars"];
  private _loanType: String;

  constructor(route: ActivatedRoute, private _creditService: CreditService) { 
    this._route = route;
  }

  ngOnInit() {
    this._loanResource = new LoanResource(25000,10,1, "Mortgage");
    this._creditService.GetLoanOfferts().subscribe( data => {
      this._loanResources = data as LoanResource[];
      this._installements.forEach(function(element){
        console.log("The value of the credit amount is " + element.month + " " + element.installment);
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
}
