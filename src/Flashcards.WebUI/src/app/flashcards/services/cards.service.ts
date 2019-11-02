import {Injectable} from '@angular/core';
import {AuthService} from '../../shared/auth.service';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
import {Card} from '../models/card';
import {environment} from '../../../environments/environment';

@Injectable()
export class CardsService {

  constructor(private http: HttpClient,
              private authService: AuthService) {
  }

  getByDeck(deck: string): Observable<HttpResponse<Card[]>> {
    return this.http.get<Card[]>(
      `${environment.API_URL}/decks/${deck}/cards`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  getById(deck: string, id: string): Observable<HttpResponse<Card>> {
    return this.http.get<Card>(
      `${environment.API_URL}/decks/${deck}/cards/${id}`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  add(deck: string, card: Card): Observable<HttpResponse<any>> {
    return this.http.post<any>(
      `${environment.API_URL}/decks/${deck}/cards`, card, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  edit(deck: string, card: Card): Observable<HttpResponse<any>> {
    return this.http.put<any>(
      `${environment.API_URL}/decks/${deck}/cards`, card, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  remove(deck: string, card: Card): Observable<HttpResponse<any>> {
    return this.http.delete<any>(
      `${environment.API_URL}/decks/${deck}/cards/${card.id}`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

}
