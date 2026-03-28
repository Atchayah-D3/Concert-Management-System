import { Component, inject } from '@angular/core';
import { AddConcertService } from '../auto-refresh.service';
import {  ConcertService } from '../api/services';
import { ConcertReqDto, ConcertResDto } from '../api/models';
import { AuthService } from '../auth.service';
import { ConfirmationService } from 'primeng/api';
import { Input } from '@angular/core';

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
  @Input() mode:'all' |'user'='all';
  @Input() title:string="Available Concerts";
  concerts:ConcertResDto[]=[];
  showEditForm:boolean=false;
  reqConcert!:ConcertResDto;
  reqConcertId!:number;
  constructor(){ }
  ngOnInit(){
    this.refreshService.refresh.subscribe(()=>{
      this.showConcerts();
  });
  if(this.mode==='all'){
  this.showConcerts();
  }
  else{
    this.showUserConcerts();
  }
}
confirmDelete(id: number) {
  this.confirmationService.confirm({
    message: 'Are you sure you want to delete this concert?',
    header: 'Delete Confirmation',
    icon: 'pi pi-exclamation-triangle',
    accept: () => {
      this.delete(id);
    }
  });
}
confirmUpdate(updatedConcert:ConcertReqDto){
  this.confirmationService.confirm({
    message:'Are you sure you want to save changes?',
    header:'Update Concert Details',
    icon:'pi pi-info-circle',
    accept:()=>{
      this.update(updatedConcert);
      this.showEditForm=false;
    }
  })
}
update(updatedConcert:ConcertReqDto){
  this.concertService.concertIdPut({id:this.reqConcertId,
    body:updatedConcert})
  .subscribe({
    next:()=>{
      console.log("Updated successfully");
    }
  })
}
delete(id:number){
  if(id){
    this.concertService.concertIdDelete({ id: id }).subscribe({
      next:(response)=>{
        if(this.mode==='all')
        this.showConcerts();
        else
          this.showUserConcerts();
      },
      error:(err)=>{
        console.error('Error deleting concert:', err);
      }
    });
  }
}
edit(id:number){
 
  if(id){
    this.concertService.concertIdGet({id}).subscribe({
      next:(concert)=>{
        this.reqConcert=concert;
        this.reqConcertId=id;
        this.showEditForm=true;
      },
      error:(err)=>{
        console.log(err);
      }
    });
  }
}
  showConcerts(){
    
    let res=this.concertService.concertGet();
    res.subscribe({
      next:(response)=>{
        this.concerts=response;
        this.refreshService.update(this.concerts.length);
    },
    error:(err)=>{
      
    }
    })
    
  }
  showUserConcerts(){
    this.concertService.concertUserGet()
    .subscribe({
      next:(res)=>{
        this.concerts=res;
      }
    })
  }

trackById(_index:number,item:ConcertResDto):number{
return item.concertId? item.concertId:-1;
}

}

