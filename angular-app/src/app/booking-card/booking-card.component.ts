import { Component,inject,Input } from '@angular/core';
import { BookingResDto } from '../api/models';
import { AuthService } from '../auth.service';
import { BookingService } from '../api/services';
import { AddConcertService } from '../auto-refresh.service';
@Component({
  selector: 'app-booking-card',
  templateUrl: './booking-card.component.html',
  styleUrls: ['./booking-card.component.css']
})
export class BookingCardComponent {
@Input() booking:BookingResDto=null!;
authService=inject(AuthService)
autoRefreshService=inject(AddConcertService)
bookingService=inject(BookingService)
cancelBooking(bookingId:number){
  this.bookingService.bookingIdPatch$Response({id:bookingId})
  .subscribe({
    next:(res)=>{
     this.autoRefreshService.autoRefresh();
    },
    error:(err)=>{
      alert(err.error)
    }
  })
}
}
