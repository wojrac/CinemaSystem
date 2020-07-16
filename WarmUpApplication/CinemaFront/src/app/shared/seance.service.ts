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
}
