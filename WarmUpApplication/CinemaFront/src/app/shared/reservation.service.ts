import { Injectable } from '@angular/core';
import { Reservation } from './reservation.model';
import {HttpClient} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  reservationData:Reservation
  readonly rootURL = 'https://localhost:5001/api';
  constructor(private http:HttpClient) { }

  addReservation(reservationData:Reservation)
  {
    return this.http.post(this.rootURL+ '/reservation', reservationData);
  }
  getAllReservations()
  {
    return this.http.get(this.rootURL+'/reservation/all');
  }
  getReservationforUser()
  {
    return this.http.get(this.rootURL + '/reservation');
  }
  deleteReservation(id)
  {
    return this.http.delete(this.rootURL + '/reservation/'+id);
  }
}

