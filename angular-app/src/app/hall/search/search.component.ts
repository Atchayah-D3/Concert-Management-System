import { Component, inject } from '@angular/core';
import { NumberValueAccessor } from '@angular/forms';
import { HallDto } from 'src/app/api/models';
import { HallService } from 'src/app/api/services';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
hallList:HallDto[]=[];
selectedHall:HallDto=null!;
showEditForm:boolean=false;
hallService=inject(HallService)
ngOnInit(){
  this.hallService.hallGet$Json().subscribe({
    next:(res)=>{
      this.hallList=res;
    }
  });
}
editHall($event:HallDto){
this.selectedHall=$event;
}
bookHall($event:number){
  
}
trackById(_index:number,item:HallDto):number{
return item.hallId? item.hallId:-1;
}
}
