import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { AddConcertService } from '../auto-refresh.service';
import {  ConcertService } from '../api/services';
import { ConcertResDto } from '../api/models';
import { AuthService } from '../auth.service';
import { ConfirmationService } from 'primeng/api';
@Component({
  selector: 'app-concert-card',
  templateUrl: './concert-card.component.html',
  styleUrls: ['./concert-card.component.css']
})
export class ConcertCardComponent {
   authService=inject(AuthService);
   @Input() concert:ConcertResDto|null=null;
   @Output() deleteEmitter=new EventEmitter();
   @Output() editEmitter=new EventEmitter();
    concerts:ConcertResDto[]=[];
   constructor(){ }
   ngOnInit(){ console.log(this.concert)}
  OnDelete(concertId:number){
    this.deleteEmitter.emit(concertId);
  }
  OnEdit(concertId:number){
    console.log("Inside edit emitter");
    this.editEmitter.emit(concertId);
  }
 }
 
 