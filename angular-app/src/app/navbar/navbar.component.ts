import { Component, inject } from '@angular/core';
import { AppRoutingModule } from "../app-routing.module";
import { AddConcertService } from '../auto-refresh.service';
import { ConcertService } from '../api/services';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
 private concertService = inject(ConcertService);
  authService=inject(AuthService)
  autoRefreshService=inject(AddConcertService);
  router=inject(Router)
  concertCount = this.autoRefreshService.updateCount;
  mode:string="Hall";
  ngOnInit() {
    this.concertService.concertGet().subscribe({
      next:(res)=>{
        this.autoRefreshService.updateCount.next(res.length);
      }
    });
  }
  setMode(Mode:string){
    this.mode=Mode;
     //this.router.navigate(["/home"]);    
       this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
    this.router.navigate(['/home']);
  });
    this.autoRefreshService.autoRefresh();
  }
}
