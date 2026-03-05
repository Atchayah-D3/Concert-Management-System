import { Component, inject } from '@angular/core';
import { AddConcertService } from '../auto-refresh.service';
import { HttpClient } from '@angular/common/http';
import {  ConcertService } from '../api/services';
import { ConcertResDto } from '../api/models';
import { AuthService } from '../auth.service';
import { ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-concert-list',
  templateUrl: './concert-list.component.html',
  styleUrls: ['./concert-list.component.css']
})
export class ConcertListComponent {
  concertService=inject(ConcertService);
  refreshService=inject(AddConcertService);
  authService=inject(AuthService);
  confirmationService = inject(ConfirmationService);
  //url:string='https://localhost:7063/Concert'
  concerts:ConcertResDto[]=[];
  constructor(){ }
  ngOnInit(){
    this.refreshService.refresh.subscribe(()=>{
      this.showConcerts();
  });
  this.showConcerts();
}
confirmDelete(id: any) {
  this.confirmationService.confirm({
    message: 'Are you sure you want to delete this concert?',
    header: 'Delete Confirmation',
    icon: 'pi pi-exclamation-triangle',
    accept: () => {
      this.delete(id);
    }
  });
}
delete(id:any){
  if(id){
    this.concertService.concertIdDelete({ id: id }).subscribe({
      next:(response)=>{
        this.showConcerts();
      },
      error:(err)=>{
        console.error('Error deleting concert:', err);
      }
    });
  }
}
update(){
  
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

