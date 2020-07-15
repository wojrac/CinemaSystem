import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { stringify } from '@angular/compiler/src/util';
import { User } from 'src/app/shared/user.model';
import { NgForm } from '@angular/forms';
import {Router} from '@angular/router';
import { ToastrService } from 'ngx-toastr';;

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styles: [
  ]
})
export class UserLoginComponent implements OnInit {
  loginModel = {
    Email : '',
    Password : ''
  };
  constructor(private service : UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    if(localStorage.getItem('token')!=null)
    this.router.navigateByUrl('/home');

  }
  
  onSubmit(form:NgForm)
  {

    this.service.loginUser(form.value).subscribe(
      (res:any) => {
       // console.log(res);
        localStorage.setItem('token', res.accessToken);
        this.router.navigateByUrl('/home');
      },
      err => {
        if(err.status == 400)
        {
          this.toastr.error("Incorrect Email or Password", "Unsuccessfull login")
        }
      }
    );
  }

}
