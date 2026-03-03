import { Component, inject } from '@angular/core';
import { AddConcertService } from '../auto-refresh.service';
import { HttpClient } from '@angular/common/http';
import { ConcertService } from '../api/services';
import { ConcertResDto } from '../api/models';

export interface concert{
  
}
@Component({
  selector: 'app-concert-list',
  templateUrl: './concert-list.component.html',
  styleUrls: ['./concert-list.component.css']
})
export class ConcertListComponent {
  concertService=inject(ConcertService);
  refreshService=inject(AddConcertService);
  url:string='https://localhost:7063/Concert'
  concerts:ConcertResDto[]=[];
  constructor(){ }
  ngOnInit(){
    this.refreshService.refresh.subscribe(()=>{
      this.showConcerts();
  });
  this.showConcerts();
}
  showConcerts(){
    
    let res=this.concertService.concertGet();
    res.subscribe({
      next:(response)=>{
        this.concerts=response;
        this.refreshService.update(this.concerts.length);
    //  console.log(response);
    },
    error:(err)=>{
      
    }
    })
    
  }

trackById(_index:number,item:ConcertResDto):number{
return item.concertId? item.concertId:-1;
}

}

