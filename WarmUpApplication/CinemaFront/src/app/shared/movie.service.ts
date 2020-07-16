import { Injectable } from '@angular/core';
import { Movie } from './movie.model';
import {HttpClient} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  movieData:Movie;
  readonly rootURL = 'https://localhost:5001/api';

  constructor(public http:HttpClient) { }

getAllMovies()
{
  return this.http.get(this.rootURL + '/movie');
}
addMovie(movieData:Movie)
{
   return this.http.post(this.rootURL + '/movie', movieData);
}
updateMovie(movieData:Movie, movieId)
{
  return this.http.put(this.rootURL+ '/movie/'+movieId, movieData);
}
getMovie(id)
{
  return this.http.get(this.rootURL+ '/movie/' + id );
}
deleteMovie(id)
{
  return this.http.delete(this.rootURL + '/movie/'+ id);
}

}
