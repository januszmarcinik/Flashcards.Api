import {Injectable} from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';

import {AuthService} from '../../shared/auth.service';
import {API_URL} from '../../../constans/constans';
import {Deck} from '../models/deck';

@Injectable()
export class DecksService {

  constructor(private http: HttpClient,
              private authService: AuthService) {
  }

  getByCategory(topic: string, category: string): Observable<HttpResponse<Deck[]>> {
    return this.http.get<Deck[]>(`${API_URL}/topics/${topic}/categories/${category}/decks`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  getByName(topic: string, category: string, deck: string): Observable<HttpResponse<Deck>> {
    return this.http.get<Deck>(`${API_URL}/topics/${topic}/categories/${category}/decks/${deck}`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  add(topic: string, category: string, deck: Deck): Observable<HttpResponse<any>> {
    return this.http.post<any>(`${API_URL}/topics/${topic}/categories/${category}/decks`, deck, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  edit(topic: string, category: string, deck: Deck): Observable<HttpResponse<any>> {
    return this.http.put(`${API_URL}/topics/${topic}/categories/${category}/decks`, deck, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }
}
