import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/shared/movie.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-moviedetails',
  templateUrl: './moviedetails.component.html',
  styleUrls: ['./moviedetails.component.css']
})
export class MoviedetailsComponent implements OnInit {
  movieId;
  movie

  constructor(public service: MovieService, private router: Router,public toastr: ToastrService) { 
    this.movieId = this.router.getCurrentNavigation().extras.state.idOfMovie;
  }

  ngOnInit(): void {
    this.service.getMovie(this.movieId).subscribe(
      res=>{
        this.movie = res;
      })
    
  }
  back()
  {
    this.router.navigateByUrl('/movielist');
  }
  
  

}
