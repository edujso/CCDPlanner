import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import 'rxjs/add/operator/map'

import { SpinnerService } from '../blocks/spinner';
import { ExceptionService } from '../blocks/exception.service';

@Injectable()
export class AuthenticationService {
    public token: string;

    // Create a stream of logged in status to communicate throughout app
    public loggedIn: boolean;
    //loggedIn$ = new BehaviorSubject<boolean>(this.loggedIn);

    constructor(
      private http: Http,
      private _spinnerService: SpinnerService,
      private _exceptionService: ExceptionService) {
        // set token if saved in local storage
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.token = currentUser && currentUser.token;
        this.setLoggedIn(true);
    }

    login(username: any, password: any): Observable<boolean> {

      this._spinnerService.show();

      let headers = new Headers({ 'content-type': 'application/json' });
      let options = new RequestOptions({ headers: headers });

        return this.http.post('/api/auth/createtoken', JSON.stringify({ userName: username, password: password }), options)
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                let token = response.json() && response.json().token;
                if (token) {
                    // set token property
                    this.token = token;
                    
                    // store username and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify({ userName: username, token: token }));

                    this.setLoggedIn(true);
                    // return true to indicate successful login
                    return true;
                } else {
                    // return false to indicate failed login
                    return false;
                }
          })
          .catch(this._exceptionService.catchBadResponse)
          .finally(() => this._spinnerService.hide());
    }

    setLoggedIn(value: boolean) {
      // Update login status subject
      //this.loggedIn$.next(value);
      this.loggedIn = value;
    }

    logout(): void {
        // clear token remove user from local storage to log user out
        this.token = null;
        localStorage.removeItem('currentUser');
        this.setLoggedIn(false);
    }
}
