import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms'
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import {UserService} from './shared/user.service';
import { MovieComponent } from './home/movie/movie.component';
import { HomeComponent } from './home/home.component';
import {AuthInterceptor} from './auth/auth.interceptor';
import { ProfileComponent } from './home/profile/profile.component';
import { SeanceComponent } from './home/seance/seance.component';
import {MovieService} from './shared/movie.service';
import { MovielistComponent } from './home/movielist/movielist.component';
import { MovieupdateComponent } from './home/movieupdate/movieupdate.component';
import { MoviedetailsComponent } from './home/moviedetails/moviedetails.component';
import {SeanceService} from './shared/seance.service';
import { SeancelistComponent } from './home/seancelist/seancelist.component';
import { SeanceupdateComponent } from './home/seanceupdate/seanceupdate.component';
import { SeancedetailsComponent } from './home/seancedetails/seancedetails.component';
import {ReservationService} from './shared/reservation.service';
import { ReservationlistComponent } from './home/reservationlist/reservationlist.component';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    UserLoginComponent,
    UserRegisterComponent,
    MovieComponent,
    HomeComponent,
    ProfileComponent,
    SeanceComponent,
    MovielistComponent,
    MovieupdateComponent,
    MoviedetailsComponent,
    SeancelistComponent,
    SeanceupdateComponent,
    SeancedetailsComponent,
    ReservationlistComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    AppRoutingModule
  ],
  providers: [UserService,MovieService,SeanceService,ReservationService
    ,{
    provide: HTTP_INTERCEPTORS,
    useClass:AuthInterceptor,
    multi:true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
