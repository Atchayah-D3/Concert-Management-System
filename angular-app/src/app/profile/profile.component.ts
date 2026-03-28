import { Component, inject } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { UserService } from '../api/services';
import { UserResDto,BookingResDto } from '../api/models';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  oAuthService=inject(OAuthService);
  userService=inject(UserService);
  token:string='';
  isConcertExist:boolean=false;
  isBookingsExist:boolean=false;
  showConcerts:boolean=false;
  showBookings:boolean=false;
  loggedInUser:UserResDto|null=null;

  ngOnInit(){
    this.token=this.oAuthService.getAccessToken();
    const payload = JSON.parse(atob(this.token.split('.')[1]));
    const uuid = payload["sub"];
    var userId:number=null!;
    console.log(uuid)
    this.userService.userGet$Json().subscribe((res)=>{
      userId=res;
    this.userService.userUserIdGet$Json({userId:userId}).subscribe(
      {
        next:(response)=>{
          console.log(response);
          this.loggedInUser=response 
          this.isConcertExist=response.concerts?.length?true:false;
          this.isBookingsExist=response.bookings?.length?true:false;
        },
        complete:()=>{
          console.log(this.loggedInUser);
        }
      }
    );
    });
    console.log(this.loggedInUser)
  }
  toggleConcert(){
    this.showConcerts=this.showConcerts?false:true;
    this.showBookings=this.showConcerts?false:true;
  } 
  toggleBooking(){
    this.showBookings=this.showBookings?false:true;
    this.showConcerts=this.showBookings?false:true;
  }
  trackById(_index:number,item:BookingResDto):number{
return item.bookingId? item.bookingId:-1;
}
}
