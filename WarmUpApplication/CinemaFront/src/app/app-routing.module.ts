
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {MovieComponent} from './home/movie/movie.component';
import {UserRegisterComponent} from './user/user-register/user-register.component';
import {UserLoginComponent} from './user/user-login/user-login.component';
import {UserComponent} from './user/user.component';
import {HomeComponent} from './home/home.component';
import {ProfileComponent} from './home/profile/profile.component'
import {AuthGuard} from './auth/auth.guard';
import {MovielistComponent} from './home/movielist/movielist.component';
import {MovieupdateComponent} from './home/movieupdate/movieupdate.component';
import {MoviedetailsComponent} from './home/moviedetails/moviedetails.component';
import {SeanceComponent} from './home/seance/seance.component';


const routes: Routes = [

  {path:'',redirectTo:'/user/registration',pathMatch:'full'},
  
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: UserRegisterComponent },
      { path: 'login', component: UserLoginComponent }
    ]
  },

  {path:'movie',component:MovieComponent, canActivate:[AuthGuard]},
  {path:'home', component:HomeComponent, canActivate:[AuthGuard]},
  {path:'profile', component:ProfileComponent, canActivate:[AuthGuard]},
  {path:'movielist',component:MovielistComponent, canActivate:[AuthGuard]},
  {path:'movieupdate',component:MovieupdateComponent, canActivate:[AuthGuard]},
  {path:'moviedetails',component:MoviedetailsComponent, canActivate:[AuthGuard]},
  {path:'seance',component:SeanceComponent, canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }