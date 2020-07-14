import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { NgForm } from '@angular/forms';
import { formatCurrency } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styles: [
  ]
})
export class UserRegisterComponent implements OnInit {

  constructor(public service : UserService, public toastr: ToastrService) { }

  ngOnInit(): void {
    this.resetForm()
  }

  resetForm(form?:NgForm)
  {
    if(form != null)
    form.resetForm();
    this.service.formData ={
      UserId :0,
      Name :'',
      LastName:'',
      Email:'',
      Password:'',
      ConfirmedPassword:''
    
    }
  }
  onSubmit(form:NgForm)
  {
    //console.log("Submit before");
    this.service.registerUser(form.value).subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success("User registered", "Succesfull register");
      },
      err => {
        //console.log(err+"My error");
        this.toastr.error("Register is not done", "Unsuccessfull register");
      }
    );
    //console.log("Submit after");
  }

}
