import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, createUrlTreeFromSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router:Router,
    private oauthService:OAuthService
   ){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const token = this.oauthService.getAccessToken();
      console.log("state url",state.url);
      if(!token)
        return this.router.createUrlTree(['/login'],
    {queryParams:{returnUrl:state.url}});

      const payload = JSON.parse(atob(token.split('.')[1]));
      const expiry = payload.exp * 1000;
      
      if(Date.now()<=expiry)
        return true
      else
        return this.router.createUrlTree(['/login'],
    {queryParams:{returnUrl:state.url}});
      
  }
  
}
