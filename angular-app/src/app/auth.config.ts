import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {
  issuer: 'http://localhost:8080/realms/ConcertRealm',
  redirectUri: window.location.origin,
  clientId: 'concert-frontend',
  responseType: 'code',
  scope: 'openid profile email',
  showDebugInformation: true
};