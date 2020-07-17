import { Component, OnInit } from '@angular/core';
import { SeanceService } from 'src/app/shared/seance.service';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-seancelist',
  templateUrl: './seancelist.component.html',
  styleUrls: ['./seancelist.component.css']
})
export class SeancelistComponent implements OnInit {
  seances;
  userProfile;
  isAdmin;
  constructor(private service:SeanceService, private router:Router, private userService: UserService ) { }

  ngOnInit(): void {
   this.service.showSeances().subscribe(
     res=>{
       this.seances = res;
     }
     
   )
  this.userService.getUserProfile().subscribe(
     res=>
     {
        this.userProfile = res;
        this.isAdmin = this.userProfile.isAdmin;
     }
   );
   
  }
  back()
  {
    this.router.navigateByUrl('/home');
  }
  goUpdate(seanceId)
  {
    this.router.navigate(['/seanceupdate'], {state:{idOfSeance: seanceId}});

  }
  details(seanceId)
  {
    this.router.navigate(['/seancedetails'], {state:{idOfSeance:seanceId}});
  }
  /*select(seanceId)
  {
    //console.log(movieId); tu jest ok
    this.router.navigate(['/seance'], {state:{idOfMovie:seanceId}})
  }*/
  onDelete(seanceId)
  {
    this.service.deleteSeance(seanceId).subscribe(
      res=>{
        window.location.reload();
      },
      err=>{

      }
    )
  }

}
