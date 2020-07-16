import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/shared/movie.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {

  constructor(public service: MovieService, private router: Router,public toastr: ToastrService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?:NgForm)
  {
    if(form != null)
    form.form.reset();
    this.service.movieData ={
      MovieId :0,
      Title :'',
      DurationInHours:0,
      ImageFile:''
    
    }
  }
  onSubmit(form: NgForm)
 { 
   this.insert(form);
 }

 insert(form:NgForm)
 {
   console.log("insert");
  this.service.addMovie(form.value).subscribe(
    res=>{
      this.resetForm(form);
      this.toastr.success("Movie added", "Succesfull adding");
      this.router.navigateByUrl('/home');
    },
    err=>{
    }
  )
 }
 
 
 

}

