import { NgModule } from '@angular/core';
import { CommonModule, CurrencyPipe } from '@angular/common';

import { HallRoutingModule } from './hall-routing.module';
import { HallFormComponent } from './hall-form/hall-form.component';
import { SearchComponent } from './search/search.component';
import { BookingComponent } from './booking/booking.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HallCardComponent } from './hall-card/hall-card.component';


@NgModule({
  declarations: [
    HallFormComponent,
    SearchComponent,
    BookingComponent,
    HallCardComponent
  ],
  imports: [
    CommonModule,
    HallRoutingModule,
    ReactiveFormsModule,
    CurrencyPipe
  ]
})
export class HallModule { }
