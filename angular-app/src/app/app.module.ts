import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { OAuthModule } from 'angular-oauth2-oidc';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserModuleModule } from './user-module/user-module.module';
import { ConcertComponent } from './concert/concert.component';
import { ConcertListComponent } from './concert-list/concert-list.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { BookingComponent } from './booking/booking.component';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { AddConcertService } from './auto-refresh.service';
import { AuthInterceptor } from './interceptors/auth.interceptor';

//import { KeycloakAngularModule, KeycloakService } from 'keycloak-angular';

// function initializeKeycloak(keycloak: KeycloakService) {
  
//   return () =>                           
//     keycloak.init({
//       config: {
//         url: 'http://localhost:8080',
//         realm: 'ConcertRealm',
//         clientId: 'concert-frontend'
//       },
//       initOptions: {
//         onLoad: 'login-required',
//         checkLoginIframe: false,
//         pkceMethod: 'S256',
//         redirectUri: window.location.origin
//       }
//     });
// }

@NgModule({
  declarations: [
    AppComponent,
    ConcertComponent,
    ConcertListComponent,
    NavbarComponent,
    HomeComponent,
    BookingComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UserModuleModule,
    ReactiveFormsModule,
    HttpClientModule,
    ConfirmDialogModule,
    BrowserAnimationsModule,
    OAuthModule.forRoot()
  ],
  providers: [ConfirmationService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}