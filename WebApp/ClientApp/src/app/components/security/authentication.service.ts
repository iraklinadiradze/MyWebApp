import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../../environments/environment';
import { User } from './user';
import { SessionInfo } from './sessionInfo';


@Injectable({ providedIn: 'root' })
export class AuthenticationService {

  private currentUserSubject: BehaviorSubject<SessionInfo>;
  public currentUser: Observable<SessionInfo>;


  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<SessionInfo>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }


  public get currentUserValue(): SessionInfo {
    return this.currentUserSubject.value;
  }


  login(username: string, password: string) {
//    return this.http.post<any>(`${environment.apiURL}/users/authenticate`, { username, password })

    return this.http.post<any>(`${environment.apiURL}/token?` + `_username=` + username + `&_password=` + password, {},
      {
        headers: {
          'Content-Type': 'application/json; charset=UTF-8'
        }
      }
    )
      .pipe(map(user => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      }));
  }


  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }

}
