import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { ConcertService } from './api/services';

@Injectable({
  providedIn: 'root'
})
export class AddConcertService {
  concertService=inject(ConcertService)
  constructor() { }
  
  refresh=new Subject<void>();
  updateCount=new BehaviorSubject(0);

 
  autoRefresh(){
  this.refresh.next();}

  update(countConcerts:number){
  this.updateCount.next(countConcerts);
  }
}
