import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MovieService } from 'src/app/shared/movie.service';

@Component({
  selector: 'app-movielist',
  templateUrl: './movielist.component.html',
  styleUrls: ['./movielist.component.css']
})
export class MovielistComponent implements OnInit {
  movies;


  constructor(private router:Router, private service : MovieService ) { }

  ngOnInit(): void {
    this.service.getAllMovies().subscribe(
      res=>{
        
        this.movies = res;
       // console.log(this.movies);
      },
      err=>
      {
          
      }
    )
  }
  /*resetForm()
  {
    this.service.movieData ={
      MovieId :0,
      Title :'',
      DurationInHours:0,
      ImageFile:''
    
    }
  }*/
  back()
  {
    this.router.navigateByUrl('/home');
  }
  goUpdate(movieId)
  {
    this.router.navigate(['/movieupdate'], {state:{idOfMovie: movieId}});

  }
  details(movieId)
  {
    this.router.navigate(['/moviedetails'], {state:{idOfMovie:movieId}});
  }
  onDelete(movieId)
  {
    this.service.deleteMovie(movieId).subscribe(
      res=>{
        window.location.reload();
      },
      err=>{

      }
    )
  }
  

}
