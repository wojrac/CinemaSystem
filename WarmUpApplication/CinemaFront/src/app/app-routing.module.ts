
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {MovieComponent} from './movie/movie.component';
import {UserRegisterComponent} from './user/user-register/user-register.component';
import {UserLoginComponent} from './user/user-login/user-login.component';
import {UserComponent} from './user/user.component';



const routes: Routes = [

  {path:'',redirectTo:'/user/registration',pathMatch:'full'},
  
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: UserRegisterComponent },
      { path: 'login', component: UserLoginComponent }
    ]
  },

  {path:'movie',component:MovieComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }