import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response, ResponseContentType } from '@angular/http';
import { SpinnerService } from '../blocks/spinner';
import { ExceptionService } from '../blocks/exception.service';
import { ToastService } from '../blocks/toast';
import { Company } from '../model/company';
import { Observable } from "rxjs/Observable";

@Injectable()
export class VendorService {
  constructor(
    private http: Http,
    private _spinnerService: SpinnerService,
    private _exceptionService: ExceptionService,
    private _toastService: ToastService
  ) { }

  getAll() {
    this._spinnerService.show();
      return this.http.get('/api/vendors', this.jwt())
        .map((response: Response) => response.json())
        .catch(this._exceptionService.catchBadResponse)
        .finally(() => this._spinnerService.hide());
  }

  getAllCompanies() {
      this._spinnerService.show();
      return this.http.get('/api/Companies', this.jwt())
          .map((response: Response) => response.json())
          .catch(this._exceptionService.catchBadResponse)
          .finally(() => this._spinnerService.hide());
  }


    getById(id: any) {
      return this.http.get('/api/vendors/' + id, this.jwt())
        .map((response: Response) => response.json())
        .catch(this._exceptionService.catchBadResponse)
        .finally(() => this._spinnerService.hide());
    }

    create(vendor: any) {
        debugger;
      this._spinnerService.show();
      return this.http.post('/api/vendors', vendor, this.jwt())
        .map((response: Response) => response.json())
        .catch(this._exceptionService.catchBadResponse)
        .finally(() => this._spinnerService.hide());
    }
    
    update(vendor: any) {
      return this.http.put('/api/vendors/' + vendor.id, vendor, this.jwt())
        .map((response: Response) => response.json())
        .catch(this._exceptionService.catchBadResponse)
        .finally(() => this._spinnerService.hide());
    }

    delete(id: any) {
      this._spinnerService.show();
      return this.http.delete('/api/vendors/' + id, this.jwt())
        .map((response: Response) => response.json())
        .catch(this._exceptionService.catchBadResponse)
        .finally(() => this._spinnerService.hide());
    }


    deleteCompany(companyId: any) {
      this._spinnerService.show();
      return this.http.delete('/api/companies/' + companyId, this.jwt())
        .map((response: Response) => response.json())
        .catch(this._exceptionService.catchBadResponse)
        .finally(() => this._spinnerService.hide());
    }


    addCompanyForVendor(vendorId: string, company: Company) {
      this._spinnerService.show();
      return this.http.post('/api/companies/CreateCompanyForVendor/' + vendorId, company, this.jwt())
        .map((response: Response) => response.json())
        .catch(this._exceptionService.catchBadResponse)
        .finally(() => this._spinnerService.hide());
    }

    getAllClaims() {
      this._spinnerService.show();
      return this.http.get('/api/vendors/getAllClaims', this.jwt())
        .map((response: Response) => response.json())
        .catch(this._exceptionService.catchBadResponse)
        .finally(() => this._spinnerService.hide());
    }


  //  exportExcel(body) {
  //    let currentUser = JSON.parse(localStorage.getItem('currentUser'));
  //    let user_token: string = currentUser.token;
  //  let headers = new Headers();
  //  return this.http.post('/api/files/exportExcel', body, {
  //    headers: headers,
  //    responseType: ResponseContentType.Blob
  //  }).map(res => new Blob([res.blob], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' }));
  //}

    export(vendorId: string): Observable<Object[]> {
      return Observable.create(observer => {
        let xhr = new XMLHttpRequest();
        xhr.open('POST', '/api/files/exportExcel/' + vendorId, true);
        xhr.setRequestHeader('Content-type', 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet');
        xhr.responseType = 'blob';

        xhr.onreadystatechange = function () {
          if (xhr.readyState === 4) {
            if (xhr.status === 200) {

              var contentType = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet';
              var blob = new Blob([xhr.response], { type: contentType });
              observer.next(blob);
              observer.complete();
            } else {
              observer.error(xhr.response);
            }
          }
        }
        xhr.send();

      });
    }

    generateToken(vendor: any) {

        debugger;
        this._spinnerService.show();
        return this.http.post('/api/vendors/generateToken/', vendor, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }

    // private helper methods

    private jwt() {
        // create authorization header with jwt token
        let currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser && currentUser.token) {
            let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token });
            return new RequestOptions({ headers: headers });
        }
    }
}
