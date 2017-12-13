import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { SpinnerService } from '../blocks/spinner';
import { ExceptionService } from '../blocks/exception.service';
import { ToastService } from '../blocks/toast';

@Injectable()
export class DataStructureService {
  constructor(
    private http: Http,
    private _spinnerService: SpinnerService,
    private _exceptionService: ExceptionService,
    private _toastService: ToastService
  ) { }

  getAll() {
        this._spinnerService.show();
        return this.http.get('/api/FieldKeys/GetAllFieldKeys', this.jwt())
        .map((response: Response) => response.json())
        .catch(this._exceptionService.catchBadResponse)
        .finally(() => this._spinnerService.hide());
    }

    getById(id: any) {
        return this.http.get('/api/FieldKeys/GetFieldKeyById?id=' + id, this.jwt()).map((response: Response) => response.json());
    }

    create(FieldKey: any)
    {
        this._spinnerService.show();
        return this.http.post('/api/FieldKeys/', FieldKey, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());



    }

    update(FieldKey: any) {
        return this.http.put('/api/FieldKeys/UpdateFieldKey', FieldKey, this.jwt()).map((response: Response) => response.json());
    }


    delete(id: any) {
        this._spinnerService.show();
        return this.http.delete('/api/FieldKeys/' + id, this.jwt())
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
