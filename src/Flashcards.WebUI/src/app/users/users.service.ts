import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Observable';
import {HttpClient, HttpResponse} from '@angular/common/http';
import 'rxjs/add/operator/map';

import {API_URL} from '../../constans/constans';
import {UserLogin} from './models/user-login';
import {Token} from './models/token';
import {AuthService} from '../shared/auth.service';
import {User} from './models/user';
import {UserRegister} from './models/user-register';

@Injectable()
export class UsersService {
  private url: string;

  constructor(private http: HttpClient,
              private authService: AuthService) {
    this.url = `${API_URL}/users/`;
  }

  getAll(): Observable<HttpResponse<User[]>> {
    return this.http.get<User[]>(this.url, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });

  }

  getById(id: number): Observable<HttpResponse<User>> {
    return this.http.get<User>(`${this.url}/${id}`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  add(user: UserRegister): Observable<HttpResponse<any>> {
    return this.http.post<any>(this.url, user, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  edit(id: number, data): Observable<HttpResponse<any>> {
    return this.http.put<any>(`${this.url}/${id}`, data, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  remove(id: number): Observable<HttpResponse<any>> {
    return this.http.delete<any>(`${this.url}/${id}`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  auth(login: UserLogin): Observable<HttpResponse<Token>> {
    return this.http.post<Token>(`${API_URL}/auth`, login, {
      headers: {
        'Content-Type': 'application/json'
      }, observe: 'response'
    });
  }
}
