import { CreditService } from '../../services/credit.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LoanResource } from '../../model/LoanResource';

@Component({
  selector: 'app-credit-form',
  templateUrl: './loan-form.component.html',
  styleUrls: ['./loan-form.component.css']
})
export class LoanFormComponent implements OnInit {

  private _route: ActivatedRoute;
  private _installements: Number[];
  private _loanResource: LoanResource;
  private _loanTypes: String[] = ["Mortage","Cars"];
  private _loanType: String;

  constructor(route: ActivatedRoute, private _creditService: CreditService) { 
    this._route = route;
  }

  ngOnInit() {
    this._loanResource = new LoanResource();
    this._installements = [1111,2222];
  }

  calculate(loadResource: LoanResource){
    this._creditService.GetInstallmentsPerMonth(loadResource).subscribe( data => {
      this._installements = data as Number[];
      console.log("The value of the credit amount is " + this._installements);
    });
  }
}
