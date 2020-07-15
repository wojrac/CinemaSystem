import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/shared/movie.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  toastr: any;

  constructor(public service: MovieService, private router: Router) { }

  ngOnInit(): void {
  }
  onSubmit(form: NgForm)
 {
  this.service.addMovie(form.value).subscribe(
    res=>{
      this.toastr.success("Movie added", "Succesfull adding");
      this.router.navigateByUrl('/home');
    }
  )
 }

}

