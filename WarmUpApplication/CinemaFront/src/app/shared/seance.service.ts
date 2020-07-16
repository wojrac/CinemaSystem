import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Seance } from './seance.model';

@Injectable({
  providedIn: 'root'
})
export class SeanceService {
  seanceData:Seance
  readonly rootURL = 'https://localhost:5001/api';
  constructor(private http:HttpClient) { }

  addSeance(seanceData:Seance)
  {
      return this.http.post(this.rootURL+'/seance', seanceData);
  }


}

