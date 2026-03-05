import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConcertComponent } from './concert/concert.component';
import { ConcertListComponent } from './concert-list/concert-list.component';
import { HomeComponent } from './home/home.component';
import { BookingComponent } from './booking/booking.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [ {path:'Concert',component:ConcertComponent},
{path:'ConcertList',component:ConcertListComponent,canActivate:[AuthGuard]},
{path:'',component:HomeComponent},
{path:'Booking',component:BookingComponent,canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
