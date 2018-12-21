import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { LoanResource } from '../model/LoanResource';

@Injectable()
export class CreditService {

  private _baseUrl: string;
  private _result: string;

  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) { 
    this._baseUrl = baseUrl;
  }

  GetInstallmentsPerMonth(loanResource: LoanResource): Observable<any> {
    const data = {
      value: loanResource.value,
      repaymentPeriod: loanResource.repaymentPeriod,
      loanTypeId: loanResource.loanOfferId,
    }
    return this.http.get(this._baseUrl + 'api/Loan/Detail',  {params: data}).map(result => {
        this._result = result.json() as string;
        return this._result}) 
  }

  GetLoanOfferts(): Observable<any> {
    return this.http.get(this._baseUrl + 'api/Loan/Offer').map(result => {
        this._result = result.json() as string;
        return this._result}) 
  }

  CheckIsLoanValid(loadResource: LoanResource) {
    if(loadResource.value > 0 && loadResource.repaymentPeriod > 0){
      return true;
    }
    return false;
  }
}
