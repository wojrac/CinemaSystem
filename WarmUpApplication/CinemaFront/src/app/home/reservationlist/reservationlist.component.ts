import { Component, OnInit } from '@angular/core';
import { ReservationService } from 'src/app/shared/reservation.service';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-reservationlist',
  templateUrl: './reservationlist.component.html',
  styleUrls: ['./reservationlist.component.css']
})
export class ReservationlistComponent implements OnInit {
  reservations;
  userProfile;
  isAdmin;
 

  constructor(private reservationService:ReservationService, private router:Router, private userService: UserService,private toastr: ToastrService) { }

  ngOnInit(): void {
    this.userService.getUserProfile().subscribe(
      res=>
      {
        //console.log(res);
         this.userProfile = res;
    this.isAdmin = this.userProfile.isAdmin;
    if(this.isAdmin===true)
    {
      this.reservationService.getAllReservations().subscribe(
        res=>{
          this.reservations =res;
        }
      )
    }
    else{
      this.reservationService.getReservationforUser().subscribe(
        res=>{
          this.reservations = res;
          
        }
      )
    }
         
      }
    );
    
  }
  back()
  {
    this.router.navigateByUrl('/home');
  }
  onDelete(reservationId)
  {
    this.reservationService.deleteReservation(reservationId).subscribe(
      res=>{
        this.toastr.success("Reservation deleted", "Succesfull deleting");
        window.location.reload();
      }
    )
  }
}
