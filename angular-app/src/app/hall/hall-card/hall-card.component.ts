import { Component, EventEmitter, inject, Input,Output } from '@angular/core';
import { HallDto } from 'src/app/api/models';
import { AuthService } from 'src/app/auth.service';
@Component({
  selector: 'app-hall-card',
  templateUrl: './hall-card.component.html',
  styleUrls: ['./hall-card.component.css']
})
export class HallCardComponent {
@Input() hall:HallDto=null!;
@Output() edit=new EventEmitter();
@Output() book=new EventEmitter();
authService=inject(AuthService)
onEdit(hall:HallDto){
  this.edit.emit(hall);
}
onBooking(hallId:number){
  this.book.emit(hallId);
}
}
