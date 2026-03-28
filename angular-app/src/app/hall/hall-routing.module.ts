import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HallFormComponent } from './hall-form/hall-form.component';
import { SearchComponent } from './search/search.component';
import { BookingComponent } from './booking/booking.component';

const routes: Routes = [
  {'path':'register',component:HallFormComponent},
{'path':'search',component:SearchComponent},
{'path':'booking',component:BookingComponent}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule ]
})
export class HallRoutingModule { }
