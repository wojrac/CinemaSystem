import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Seance } from './seance.model';
import { __importDefault } from 'tslib';

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
  showSeances()
  {
    return this.http.get(this.rootURL + '/seance/all');
  }
  deleteSeance(id)
  {
    return this.http.delete(this.rootURL + '/seance/'+ id);
  }
  updateSeance(seanceData:Seance, id)
  {
    return this.http.put(this.rootURL+'/seance/'+ id, seanceData);
  }
  getSeance(id)
  {
    return this.http.get(this.rootURL+'/seance/'+ id);
  }


}

