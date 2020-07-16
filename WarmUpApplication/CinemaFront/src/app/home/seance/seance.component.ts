import { Component, OnInit } from '@angular/core';
import { SeanceService } from 'src/app/shared/seance.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-seance',
  templateUrl: './seance.component.html',
  styleUrls: ['./seance.component.css']
})
export class SeanceComponent implements OnInit {

  constructor(public service: SeanceService, private router: Router,public toastr: ToastrService) { }

  ngOnInit(): void {
    this.resetForm();
  }
  resetForm(form?:NgForm)
  {
    if(form != null)
    form.form.reset();
    this.service.seanceData ={
      SeanceId:0,
      MovieId :0,
      StartOfSeance: new Date(2017, 1, 1, 12, 23, 42),
      EndOfSeance: new Date(2017,1,1,15,0,0),
      Prize:0,
      Reservations:[],
      Seats:[]
    
    }
  }
  onSubmit(form:NgForm)
  {

  }

}
