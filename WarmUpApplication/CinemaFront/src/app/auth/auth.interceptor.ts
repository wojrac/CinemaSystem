import {HttpInterceptor, HttpRequest, HttpHandler, HttpEvent} from '@angular/common/http'
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import {tap} from 'rxjs/operators'
import {Router} from '@angular/router'

@Injectable()
export class AuthInterceptor implements HttpInterceptor
{
    
    constructor(private router: Router){}
        

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if(localStorage.getItem('token')!=null)
        {
            const cloneReq = req.clone({
                headers:req.headers.set('Authorization', 'Bearer '+ localStorage.getItem('token'))
            });
            return next.handle(cloneReq).pipe(
                tap(
                    succ=>{},
                    err=>{
                        if(err.status == 401)
                        {
                            console.log("Unauthorized");
                            localStorage.removeItem('token');
                            this.router.navigateByUrl('user/login');
                        }
                    }
                )
            )
        }else return next.handle(req.clone());
    }
    
}