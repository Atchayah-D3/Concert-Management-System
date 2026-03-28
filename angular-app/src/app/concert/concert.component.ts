import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { FormGroup,FormControl,Validators } from '@angular/forms';
import { AddConcertService } from '../auto-refresh.service';
import { ConcertService, HallService } from '../api/services';
import { ConcertReqDto, ConcertResDto, HallDto, HallBookingReqDto } from '../api/models';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-concert',
  templateUrl: './concert.component.html',
  styleUrls: ['./concert.component.css']
})
export class ConcertComponent {
  concertService=inject(ConcertService);
  autoRefresh=inject(AddConcertService);
  hallService=inject(HallService)
  @Input() currentConcert!:ConcertResDto;
  @Output() updateEmitter=new EventEmitter();
  halls:HallDto[]|[]=[];
  message:string='';
  ngOnInit(){
    this.hallService.hallGet$Json().subscribe({
      next:(res)=>{
        this.halls=res;
      },
      error:(err)=>{
        console.log(err);
      }
    });
    if(this.currentConcert){
   this.concertForm.patchValue({
  concertName: this.currentConcert.concertName,
  concertSpec: {
    artist: this.currentConcert.concertSpec?.artist,
    price: this.currentConcert.concertSpec?.price,
    date: this.currentConcert.concertSpec?.date_Time?.substring(0,16)
  }
});
    }
  }
concertForm=new FormGroup({
  concertName: new FormControl('',[Validators.required,Validators.minLength(5),Validators.maxLength(20)]),
  concertSpec:new FormGroup({
    date:new FormControl<string|null>(''),
    artist:new FormControl('',[Validators.minLength(2),Validators.maxLength(50)]),
    price:new FormControl<number|null>(null) 
  }),
  bookHall: new FormControl<boolean>(false),
  hallId: new FormControl<number|null>(null),
  fromDate:new FormControl<string|null>(null),
  toDate:new FormControl<string|null>(null),
  customHall:new FormControl<string|null>(null)
});

buildReqBody():any{

  const formValue = this.concertForm.getRawValue();
  const requestBody:ConcertReqDto={concertName: formValue.concertName,
    concertSpec: {
      artist: formValue.concertSpec.artist,
      date_Time: formValue.concertSpec.date
                ? new Date(formValue.concertSpec.date).toISOString()
                : null,
      price: formValue.concertSpec.price
    }  
  }; 
if(formValue.bookHall){
  const bookingReq: HallBookingReqDto={
  hallId: formValue.hallId!,
  fromDateTime:  formValue.fromDate
                ? new Date(formValue.fromDate).toISOString()
                :undefined,
  toDateTime:  formValue.toDate
                ? new Date(formValue.toDate).toISOString()
                :undefined
  } 
  requestBody.hallBookingReq= bookingReq;
}
else{
  requestBody.customHall=formValue.customHall;
}
  return requestBody;

}
sendConcert(){
  const requestBody:ConcertReqDto=this.buildReqBody();
  this.concertService.concertPost({body:requestBody}).subscribe({
   next:(response)=>{
      console.log(response);
   },
   error:(err:HttpErrorResponse)=>{
    console.log(err);
    if(err.error?.errors){
      this.message=Object.values(err.error?.errors).flat().join('\n');
      console.log(this.message);
    }
    else{    
    this.message = err.error?.message || err.statusText || "An error occurred";
    }
   },
   complete:()=>{
    this.message="concert created successfully"
    this.concertForm.reset();
   }
  });
}
update(){
  const reqBody:ConcertReqDto=this.buildReqBody();
  this.updateEmitter.emit(reqBody);
}
}
