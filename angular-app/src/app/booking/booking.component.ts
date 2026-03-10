import { Component, inject } from '@angular/core';
import { BookingService, ConcertService } from '../api/services';
import { BookingReqDto, ConcertResDto } from '../api/models';
import { FormControl, FormGroup, ɵInternalFormsSharedModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css'],
})
export class BookingComponent {
  private concertService=inject(ConcertService)
  private bookingService=inject(BookingService)
  concerts:ConcertResDto[]=[];
  bookingForm=new FormGroup({
    concert:new FormControl<number|null>(null) 
  });

  ngOnInit(){
    this.concertService.concertGet().subscribe({
      next:(response)=>{
        this.concerts=response;
        
      },
      error:(err)=>{
        console.log(err)
      }
    });      
  }

  bookConcert(){
    const formValue=this.bookingForm.getRawValue();
    const requestBody:BookingReqDto={
      concertId:formValue.concert??0
    }
    this.bookingService.bookingPost$Json({body:requestBody}).subscribe((response)=>{
      console.log(response);
    });
  }
}
