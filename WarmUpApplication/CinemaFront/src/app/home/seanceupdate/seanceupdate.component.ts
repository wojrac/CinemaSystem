import { Component, OnInit } from '@angular/core';
import { SeanceService } from 'src/app/shared/seance.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-seanceupdate',
  templateUrl: './seanceupdate.component.html',
  styleUrls: ['./seanceupdate.component.css']
})
export class SeanceupdateComponent implements OnInit {
seanceId;
  constructor(public service: SeanceService, private router: Router,public toastr: ToastrService) {
    this.seanceId =this.router.getCurrentNavigation().extras.state.idOfSeance;
   }

  ngOnInit(): void {
    this.resetForm();
  }
  resetForm(form?:NgForm)
  {
    if(form != null)
    form.resetForm();
    this.service.seanceData ={
      SeanceId:0,
      MovieId :0,
      Movie:null,
      StartOfSeance: new Date(2017, 1, 1, 12, 23, 42),
      EndOfSeance: new Date(2017,1,1,15,0,0),
      Prize:0,
      Reservations:[],
      Seats:[]
    
    }
  }
  onSubmit(form:NgForm)
  {
    //a tu za pozno :/
     
    // form.value.SeanceId = this.seanceId;
    this.service.updateSeance(form.value, this.seanceId).subscribe(
      res=>{
        
        this.resetForm(form);
        this.toastr.success("Seance updated", "Succesfull updating");
        this.router.navigateByUrl('/home');
      },
      err=>{
        console.log();
        this.toastr.error(err.error.message, "Unsuccessfull create");
      }
    )
  }
  goToSelect()
  {
    this.router.navigateByUrl('/movielist');
  }

}
