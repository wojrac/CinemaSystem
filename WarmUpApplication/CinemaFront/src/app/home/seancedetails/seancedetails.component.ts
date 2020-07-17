import { Component, OnInit } from '@angular/core';
import { SeanceService } from 'src/app/shared/seance.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-seancedetails',
  templateUrl: './seancedetails.component.html',
  styleUrls: ['./seancedetails.component.css']
})
export class SeancedetailsComponent implements OnInit {
seanceId;
seance;
  constructor(public service: SeanceService, private router: Router,public toastr: ToastrService) { 
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
  reserve(seanceId, seatNr)
  {
    
  }

}
