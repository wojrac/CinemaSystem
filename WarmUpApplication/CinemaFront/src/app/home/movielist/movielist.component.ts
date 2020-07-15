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
      },
      err=>
      {
          
      }
    )
  }

}
