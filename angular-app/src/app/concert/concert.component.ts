import { Component, inject } from '@angular/core';
import { FormGroup,FormControl,Validators } from '@angular/forms';
import { Inject } from '@angular/core';
import { AddConcertService } from '../auto-refresh.service';
import { ConcertListComponent } from '../concert-list/concert-list.component';
import { ConcertService } from '../api/services';
import { ConcertReqDto, ConcertResDto } from '../api/models';
import { Subject } from 'rxjs';
@Component({
  selector: 'app-concert',
  templateUrl: './concert.component.html',
  styleUrls: ['./concert.component.css']
})
export class ConcertComponent {
  concertService=inject(ConcertService);
  autoRefresh=inject(AddConcertService);
 
concertForm=new FormGroup({
  concertName: new FormControl('',[Validators.required,Validators.minLength(5),Validators.maxLength(20)]),
  concertSpec:new FormGroup({
    date:new FormControl(''),
    artist:new FormControl('',[Validators.minLength(2),Validators.maxLength(50)]),
    price:new FormControl<number|null>(null) 
  })
});

sendConcert(){
  console.log("inside sendConcert()")
  const formValue = this.concertForm.getRawValue();
  console.log("Raw values",formValue);
  const requestBody:ConcertReqDto={concertName: formValue.concertName,
    concertSpec: {
      artist: formValue.concertSpec.artist,
      date_Time: formValue.concertSpec.date
                ? new Date(formValue.concertSpec.date).toISOString()
                : null,
      price: formValue.concertSpec.price
    }
  }; 
  console.log("Req ",requestBody);
  this.concertService.concertPost({body:requestBody}).subscribe((response)=>{
    console.log("res",response);
    this.autoRefresh.autoRefresh();
  });
  
}

}
