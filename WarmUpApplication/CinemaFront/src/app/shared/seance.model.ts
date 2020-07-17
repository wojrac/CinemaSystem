import { Movie } from './movie.model';

export class Seance
{
    SeanceId : number;
    Reservations: [];
    MovieId: number;
    Movie: Movie;
    StartOfSeance: Date;
    EndOfSeance: Date;
    Prize: number;
    Seats:[];
}