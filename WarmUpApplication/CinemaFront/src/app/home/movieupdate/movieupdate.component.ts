import { Component, OnInit, Input } from '@angular/core';
import { MovieService } from 'src/app/shared/movie.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-movieupdate',
  templateUrl: './movieupdate.component.html',
  styleUrls: ['./movieupdate.component.css']
})
export class MovieupdateComponent implements OnInit {
movie;
movieId;
  constructor(public service: MovieService, private router: Router,public toastr: ToastrService) { 
    //console.log("constructor");
    this.movieId = this.router.getCurrentNavigation().extras.state.idOfMovie;
  }

  ngOnInit(): void {
    this.resetForm();
  }
  resetForm(form?:NgForm)
  {
    if(form != null)
    form.resetForm();
    this.service.movieData ={
      MovieId :0,
      Title :'',
      DurationInHours:0,
      ImageFile:''
    
    }
  }
  /*getMovie(id:number)
  {
    this.service.getMovie(id).subscribe(
      res=>{
        this.movie = res;
        console.log(this.movie);
      }
    )
  }*/
  onUpdate(form: NgForm)
  {
    
    this.service.updateMovie(form.value, this.movieId).subscribe(
      res=>{
        //this.resetForm(form);;
        
        //this.service.movieData= this.movie;
        this.toastr.success("Movie updated", "Succesfull update");
        this.router.navigateByUrl('/home');
      },
      err=>{
      }
    )
  }

}
