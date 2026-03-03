import { Component } from '@angular/core';
import { FormGroup,FormControl,Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginServiceService } from 'src/app/login-service.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  title:string="Login"
  isLoggedIn:boolean|undefined=false;
  loginMessage:string='';
  returnUrl:string='';
form=new FormGroup({
userEmail:new FormControl('',[Validators.email,Validators.required]),
password:new FormControl('',Validators.required)
});

constructor(private loginService:LoginServiceService,
  private router:Router,
  private route:ActivatedRoute
){ }

ngOnInit(){
this.returnUrl=this.route.snapshot.queryParams['returnUrl']||''
}

handleLogin(){
  this.loginService.login(this.form.value).subscribe({

    next:(response)=>{
     this.isLoggedIn=response.success;
      if(this.isLoggedIn){
        localStorage.setItem('token', response.token??'');
      const role:string|null=this.loginService.getUserRole();
      if(this.returnUrl)
        this.router.navigateByUrl(this.returnUrl);
      else{
      if(role=="CONCERT_CREATOR")
        this.router.navigate(["/Concert"]);
      else
        this.router.navigate(["/ConcertList"]);
    }    }
    },

    error:(err)=>{
      this.loginMessage=err.error?.Message||"Login failed";
    }
   })
}
}