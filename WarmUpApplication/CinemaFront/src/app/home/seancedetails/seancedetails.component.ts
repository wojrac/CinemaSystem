import { Component, OnInit } from '@angular/core';
import { SeanceService } from 'src/app/shared/seance.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ReservationService } from 'src/app/shared/reservation.service';
import { generate } from 'rxjs';

@Component({
  selector: 'app-seancedetails',
  templateUrl: './seancedetails.component.html',
  styleUrls: ['./seancedetails.component.css']
})
export class SeancedetailsComponent implements OnInit {
seanceId;
seance;
reservation;
seats:number[];

  constructor(public service: SeanceService, private router: Router,public toastr: ToastrService, public reservationService:ReservationService) { 

    this.seanceId = this.router.getCurrentNavigation().extras.state.idOfSeance;
  }

  ngOnInit(): void {
    this.service.getSeance(this.seanceId).subscribe(
      res=>{
        this.seance = res;
      }
    )
  }
  back()
  {
    this.router.navigateByUrl('/seancelist');
  }
  reserve(seanceId,seatNr:number, seatId)
  {
    //console.log("reserve");
    this.seats = new Array<number>();
    console.log(seatNr);
    this.seats.push(seatNr);
    
    this.reservationService.reservationData =
    {
      ReservationId:seatId,
      SeanceId :seanceId,
      Seance:null,
      numberOfSeatsToReserve : this.seats
    }
    this.reservationService.addReservation(this.reservationService.reservationData).subscribe(
      res=>
      {
        //window.location.reload();
        this.toastr.success("Seat reserved", "Success");
        this.router.navigateByUrl('/seancelist');
      },
      err=>{
        console.log(err.error);
      }
    )
  }

}
