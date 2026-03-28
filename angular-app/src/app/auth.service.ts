import { Inject, Injectable } from "@angular/core";
import { authConfig } from "./auth.config";
import { OAuthService } from "angular-oauth2-oidc";
import { PermissionService } from "./api/services/permission.service";
import { Permission } from "./api/models";
import { UserService } from "./api/services";
import { BehaviorSubject, Observable } from "rxjs";
import { distinctUntilChanged, map } from "rxjs/operators";

export interface UserIdResponse {
  userId: number;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  
  private permissions$ = new BehaviorSubject<Permission[] >([]);
  private userId: number | null = null;
  private email:string=null!;
  constructor(
    private oauthService: OAuthService,
    private userService: UserService,
    private permissionService: PermissionService
  ) {
    const token = this.oauthService.getAccessToken();
    if (token) {
      this.setToken(token);
    }
  }

  initLogin() {
  this.oauthService.configure(authConfig);

  this.oauthService.loadDiscoveryDocumentAndTryLogin().then(() => {

    const token = this.oauthService.getAccessToken();

    if (token) {
      this.setToken(token);
    }

  });
}

  login() { this.oauthService.initCodeFlow(); }
  logout() { 
    this.permissions$.next([]);
    this.userId = null;
    this.oauthService.logOut(); }
  getToken() { return this.oauthService.getAccessToken(); }
  isLoggedIn() { return this.oauthService.hasValidAccessToken(); }
  getUserId(): number | null { return this.userId; }

  setToken(token: string) {
    const payload = JSON.parse(atob(token.split('.')[1]));
    const uuid = payload["sub"];
    const role = payload["role"];
    this.email=payload["email"];
    if (uuid) {
      this.userService.userGet$Json({ uuid }).subscribe({
        next: (response: number) => { this.userId = response; },
        error: err => console.error(err)
      });
    }

    this.permissionService.permissionGet({ role }).subscribe({
      next: (response) => {
        this.permissions$.next(response || []);         
      },
      error: err => console.error(err)
    });
  }

  can(action: string, resource: string): boolean {
  const permissions = this.permissions$.getValue();
  if (!permissions) return false;
  return permissions.some(
    p => p.action === action && p.resource === resource
  );
}

can$(action: string, resource: string): Observable<boolean> {
  return this.permissions$.pipe(
    map((permissions: Permission[] | null) => {
      if (!permissions) return false;
      return permissions?.some(
        (p: Permission) => {return p.action === action && p.resource === resource}
      ) ?? false;
    }),
    distinctUntilChanged()
  );
}
canShowConcertTab$(): Observable<boolean> {
  return this.can$('create_concert','concert');
}

canShowBookingTab$(): Observable<boolean> {
  return this.can$('create_booking','booking');
}
  canDeleteConcert(concertCreatorId: number): boolean {
    return this.can('delete_concert', 'concert') && this.userId === concertCreatorId;
  }
canUpdateHall(ownerId:number):boolean{
  return this.can('edit_hall','hall') && this.userId===ownerId;
}
  canUpdateConcert(creatorId: number): boolean {
    
    return this.can('update_concert', 'concert') && this.userId === creatorId;
  }
  canDeleteBooking(userEmail:string):boolean{
    const canCancel:boolean= this.can('cancel_booking','booking')
    return canCancel && this.email===userEmail;
  }
}