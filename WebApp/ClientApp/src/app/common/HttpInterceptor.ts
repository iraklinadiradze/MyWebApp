import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable , throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { Injectable } from "@angular/core";
import { catchError } from 'rxjs/operators';
import { AlertService } from './alert.service';
import { AuthService } from './Auth.service';

export class JsonDateInterceptor implements HttpInterceptor {


//  private _isoDateFormat = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(?:\.\d*)?Z$/;
  private _isoDateFormat = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}/;

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
  //  console.log(JSON.stringify(req));

    return next.handle(req).pipe(map((val: HttpEvent<any>) => {
      if (val instanceof HttpResponse) {
        const body = val.body;
        this.convert(body);
      }
      return val;
    }));
  }

  isIsoDateString(value: any): boolean {
    if (value === null || value === undefined) {
      return false;
    }
    if (typeof value === 'string') {
      return this._isoDateFormat.test(value);
    } return false;
  }
  convert(body: any) {
    if (body === null || body === undefined) {
      return body;
    }
    if (typeof body !== 'object') {
      return body;
    }
    for (const key of Object.keys(body)) {
      const value = body[key];
      if (this.isIsoDateString(value)) {
//        console.log("convert_____________" + value);
        body[key] = new Date(value);
//        console.log("convert1_____________" + body[key]);
      } else if (typeof value === 'object') {
        this.convert(value);
      }
    }
  }
}

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private alertService: AlertService)
  { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.error("eroror interceptor");
    return next.handle(request).pipe(catchError(err => {
      const error = err.error.message || err.statusText;
      this.alertService.error(error + "dddddd1");
      console.error(err + "dddddd2");
      return throwError(error + "dddddd3");
    }))
  }
}

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(public auth: AuthService) { }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${this.auth.getToken()}`
      }
    });
    return next.handle(request);
  }
}
