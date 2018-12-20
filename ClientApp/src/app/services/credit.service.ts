import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { LoanResource } from '../model/LoanResource';
import { HttpParams } from '@angular/common/http';

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
      loanTypeId: loanResource.loanTypeId,
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
}
