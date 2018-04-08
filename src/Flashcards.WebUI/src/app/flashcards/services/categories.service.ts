import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Observable';
import {HttpClient, HttpResponse} from '@angular/common/http';
import 'rxjs/add/operator/map';

import {API_URL} from '../../../constans/constans';
import {Category} from '../models/category';
import {AuthService} from '../../shared/auth.service';

@Injectable()
export class CategoriesService {

  constructor(private http: HttpClient,
              private authService: AuthService) { }

  getByTopic(topic: string): Observable<HttpResponse<Category[]>> {
    return this.http.get<Category[]>(`${API_URL}/topics/${topic}/categories`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  getByName(topic: string, name: string): Observable<HttpResponse<Category>> {
    return this.http.get<Category>(`${API_URL}/topics/${topic}/categories/${name}`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  add(topic: string, category: Category): Observable<HttpResponse<any>> {
    return this.http.post<any>(`${API_URL}/topics/${topic}/categories`, category, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  edit(topic: string, category: Category): Observable<HttpResponse<any>> {
    return this.http.put<any>(`${API_URL}/topics/${topic}/categories`, category, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  remove(topic: string, category: Category): Observable<HttpResponse<any>> {
    return this.http.delete<any>(`${API_URL}/topics/${topic}/categories/${category.id}`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }
}
