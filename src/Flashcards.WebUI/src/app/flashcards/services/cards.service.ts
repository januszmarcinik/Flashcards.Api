import {Injectable} from '@angular/core';
import {API_URL} from '../../../constans/constans';
import {AuthService} from '../../shared/auth.service';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
import {Card} from '../models/cards/card';

@Injectable()
export class CardsService {

  constructor(private http: HttpClient,
              private authService: AuthService) {
  }

  getByDeck(topic: string, category: string, deck: string): Observable<HttpResponse<Card[]>> {
    return this.http.get<Card[]>(
      `${API_URL}/topics/${topic}/categories/${category}/decks/${deck}/cards`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  getById(topic: string, category: string, deck: string, id: string): Observable<HttpResponse<Card>> {
    return this.http.get<Card>(
      `${API_URL}/topics/${topic}/categories/${category}/decks/${deck}/cards/${id}`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  add(topic: string, category: string, deck: string, card: Card): Observable<HttpResponse<any>> {
    return this.http.post<any>(
      `${API_URL}/topics/${topic}/categories/${category}/decks/${deck}/cards`, card, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  edit(topic: string, category: string, deck: string, card: Card): Observable<HttpResponse<any>> {
    return this.http.put<any>(
      `${API_URL}/topics/${topic}/categories/${category}/decks/${deck}/cards`, card, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  remove(topic: string, category: string, deck: string, card: Card): Observable<HttpResponse<any>> {
    return this.http.delete<any>(
      `${API_URL}/topics/${topic}/categories/${category}/decks/${deck}/cards/${card.id}`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

}
