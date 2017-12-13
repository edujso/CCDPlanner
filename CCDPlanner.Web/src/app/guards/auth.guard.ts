// auth.guard.ts
import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(
    private _authenticationService: AuthenticationService,
    private router: Router
  ) { }

  canActivate() {

    if (!this._authenticationService.loggedIn) {
      localStorage.removeItem('currentUser');
      this.router.navigate(['/login']);
      return false;
    }

    return true;
  }
}
