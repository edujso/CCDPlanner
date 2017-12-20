import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { SpinnerService } from '../blocks/spinner';
import { ExceptionService } from '../blocks/exception.service';
import { ToastService } from '../blocks/toast';
import { Category } from '../model/category';

@Injectable()
export class CategoryService {
  constructor(
    private http: Http,
    private _spinnerService: SpinnerService,
    private _exceptionService: ExceptionService,
    private _toastService: ToastService
  ) { }

  getAll() {
    this._spinnerService.show();
      return this.http.get('/api/categories', this.jwt())
        .map((response: Response) => response.json())
        .catch(this._exceptionService.catchBadResponse)
        .finally(() => this._spinnerService.hide());
    }

    getById(id: any) {
      return this.http.get('/api/categories/' + id, this.jwt()).map((response: Response) => response.json());
    }

    create(user: any) {
      this._spinnerService.show();
      return this.http.post('/api/users', user, this.jwt())
        .map((response: Response) => response.json())
        .catch(this._exceptionService.catchBadResponse)
        .finally(() => this._spinnerService.hide());
    }

    update(user: any) {
        return this.http.put('/api/users/' + user.id, user, this.jwt()).map((response: Response) => response.json());
    }

    delete(id: any) {
      this._spinnerService.show();
      return this.http.delete('/api/users/' + id, this.jwt())
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
