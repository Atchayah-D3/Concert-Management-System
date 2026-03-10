import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {jwtDecode} from 'jwt-decode';
import { AuthService } from './api/services';
import { OAuthService } from 'angular-oauth2-oidc';
@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

//url:string="https://localhost:7063/Auth/";
constructor(private http:HttpClient, 
  private authService:AuthService,
private oauthService:OAuthService){ }
  
  login(value:any){
    const payload={
      email:value.userEmail,
      password:value.password
    }
   return this.authService.authLoginPost$Json({body:payload});
  }

  getUserRole():string|null{
    const token = this.oauthService.getAccessToken();
    if(!token) return null;
    console.log(jwtDecode(token));
    const decode:any= jwtDecode(token);
  return decode["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
  }
}
