import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConcertComponent } from './concert/concert.component';
import { ConcertListComponent } from './concert-list/concert-list.component';
import { HomeComponent } from './home/home.component';
import { BookingComponent } from './booking/booking.component';
import { AuthGuard } from './auth.guard';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [ {path:'concert',component:ConcertComponent,canActivate:[AuthGuard]},
{path:'concertList',component:ConcertListComponent},
{path:'',component:HomeComponent},
{path:'booking',component:BookingComponent,canActivate:[AuthGuard]},
{path:'profile',component:ProfileComponent,canActivate:[AuthGuard]},
{
  path: 'hall',
  loadChildren: () =>
    import('./hall/hall.module').then(m => m.HallModule),
  canActivate:[AuthGuard]
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
