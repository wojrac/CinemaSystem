import { Injectable } from '@angular/core';
import {User} from './user.model'
import {HttpClient} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class UserService {
  formData:User;
  readonly rootURL = "https://localhost:5001/api";
  

  constructor(public http:HttpClient) { }

  registerUser(formData:User)
  {
    return this.http.post(this.rootURL+'/user',formData);
  }
}
