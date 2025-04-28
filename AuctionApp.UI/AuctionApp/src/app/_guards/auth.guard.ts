import {
  ActivatedRouteSnapshot,
  CanActivate,
  CanActivateFn,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { LoginService } from '../_services/login.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class authGuard implements CanActivate {
  constructor(private loginService: LoginService, private router: Router) {}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    const role = route.data['Role'];
    if (
      this.loginService.isLoggedIn() &&
      this.loginService.decodeToken().role == role
    ) {
      return true;
    } else if (
      this.loginService.isLoggedIn() &&
      this.loginService.decodeToken().role !== role
    ) {
      this.router.navigate(['unauthorized']);
      return false;
    } else {
      this.router.navigate(['login']);
      return false;
    }
  }
}
