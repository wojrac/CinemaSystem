import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userDetails;
  isAdmin;

  constructor(private router: Router, private service: UserService) { }

  ngOnInit(): void {
    this.service.getUserProfile().subscribe(
      res=>{
        this.userDetails = res;
        this.isAdmin = this.userDetails.isAdmin;
      },
      err=>{}
   );

  }
  onLogout()
  {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
  seeProfile()
  {
    this.router.navigateByUrl('/profile');
  }
  goToAddForm()
  {
    this.router.navigateByUrl('/movie');
  }
  showMovies()
  {
    this.router.navigateByUrl('/movielist');
  }
  goToAddSeanceForm()
  {
    this.router.navigateByUrl('/seance');
  }
  showSeances()
  {
    this.router.navigateByUrl('/seancelist');
  }
  showReservations()
  {
    this.router.navigateByUrl('/reservationlist');
  }

}
