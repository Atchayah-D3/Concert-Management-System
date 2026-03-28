import { Component, inject,Input } from '@angular/core';
import { FormGroup,FormControl,Validators } from '@angular/forms';
import { BookingReqDto, HallBookingReqDto, HallDto } from 'src/app/api/models';
import { BookingService, HallService } from 'src/app/api/services';
@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent {
  halls:HallDto[]=[]!;
  hallService=inject(HallService);
  bookingService=inject(BookingService);
  @Input() hall=0;
  ngOnInit(){
    this.hallService.hallGet$Json()
    .subscribe({
      next:(res)=>{
        this.halls=res;
      }
    })
  }
  buildPayload(){
    const formValue=this.bookingForm.getRawValue();
    const reqBody:HallBookingReqDto={     
      hallId:formValue.hallId??0,
      fromDateTime:formValue.fromDateTime??'',
      toDateTime:formValue.toDateTime??''
    }
    return reqBody;
  }
  bookingForm = new FormGroup({
    hallId: new FormControl<number | null>(this.hall, Validators.required),
    concertId: new FormControl<number | null>(null),
    fromDateTime: new FormControl<string | null>(null, Validators.required),
    toDateTime: new FormControl<string | null>(null, Validators.required)
  });
  OnSubmit(){
    const payload=this.buildPayload();
    console.log("Inside OnSubmit")
    this.bookingService.bookingPost$Json({body:payload})    
    .subscribe({
      next:(res)=>{
        console.log(res);
        alert("booking created successfully");
      },
      error:(err)=>{
        console.log(err);
        alert("Booking couldn't be processed");
      }
    })

  }
}
