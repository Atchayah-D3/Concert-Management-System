import { Component,inject, Output,Input } from '@angular/core';
import { FormControl,FormGroup,Validators } from '@angular/forms';
import { HallDto } from 'src/app/api/models';
import { HallService } from 'src/app/api/services';
import { AuthService } from 'src/app/auth.service';
@Component({
  selector: 'app-hall-form',
  templateUrl: './hall-form.component.html',
  styleUrls: ['./hall-form.component.css']
})
export class HallFormComponent {
  hallService=inject(HallService);
  authService=inject(AuthService)
  @Input() selectedHall:HallDto=null!;

HallForm=new FormGroup({
  hallName: new FormControl('',[Validators.required,Validators.minLength(5),Validators.maxLength(20)]),
  location:new FormControl<string|null>(''),
  capacity:new FormControl<number>(0,[Validators.required]),
  pph:new FormControl<number|null>(null,[Validators.required])
});
ngOnInit(){
  if(this.selectedHall)
  this.editHall();
}
buildRequestBody():HallDto{
 const formValue = this.HallForm.getRawValue();
  const requestBody:HallDto={
    hallName:formValue.hallName,
    location:formValue.location,
    capacity:formValue.capacity??0,
    pricePerHour:formValue.pph??0,
    ownerId:this.selectedHall?.ownerId
  }; 
  return requestBody;
}

addHall(){
var payload:HallDto=this.buildRequestBody();
this.hallService.hallPost$Json$Response({body:payload})
.subscribe({
  next:(res)=>{
    if(res.status==201)
      alert("Hall added successfully");
    this.HallForm.reset();
  },
  error:(err)=>{
    alert(err.error);
  }
  });
}
editHall(){
  this.HallForm.patchValue({
pph:this.selectedHall.pricePerHour
  });
    this.HallForm.patchValue(this.selectedHall);
}
updateHall(){
const payload=this.buildRequestBody();
this.hallService.hallIdPut$Json$Response({
  id:this.selectedHall.hallId??0,
  body:payload
}).subscribe({
  next:(res)=>{
    alert("Hall updated successfully")
  },
  error:(err)=>{
    alert(err.error);
  }
})
}
}
