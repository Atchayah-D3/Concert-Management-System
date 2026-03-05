import { Inject, Injectable } from "@angular/core";

// auth.service.ts
@Injectable({ providedIn: 'root' })
export class AuthService {
  private userId: number | null = null;
  private permissions: { action: string, resource: string }[] = [];
  constructor(){
    const token = localStorage.getItem('token');
    if (token) {
      this.setToken(token);
       const payload = JSON.parse(atob(token.split('.')[1]));
    }
  }
  setToken(token: string) {
  const payload = JSON.parse(atob(token.split('.')[1]));
 this.userId = Number(
  payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"]
);
  this.permissions = typeof payload.permissions === 'string'
    ? JSON.parse(payload.permissions)
    : payload.permissions || [];
}
  getUserId(): number | null {
  return this.userId;
}
  canDeleteConcert(concertCreatorId: number): boolean {
    
  const hasRolePermission = this.can('delete_concert', 'concert');
  return hasRolePermission && this.userId === concertCreatorId;
}
canUpdateConcert(creatorId:number):boolean{
  
  const hasRolePermission = this.can('update_concert', 'concert');
  console.log('Checking update permission for userId:', this.userId, 'and creatorId:', creatorId,'has permission',hasRolePermission);
  return hasRolePermission && this.userId === creatorId;
}
  can(action: string, resource: string): boolean {
    
    return this.permissions.some(p => p.action === action && p.resource === resource);
  }
}