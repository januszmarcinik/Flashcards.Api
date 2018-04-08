import {Injectable} from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';

import {AuthService} from '../../shared/auth.service';
import {API_URL} from '../../../constans/constans';
import {Deck} from '../models/deck';
import {DeckForCreation} from '../models/deckForCreation';

@Injectable()
export class DecksService {

  constructor(private http: HttpClient,
              private authService: AuthService) {
  }

  getDecks(topic: string, category: string): Observable<HttpResponse<Deck[]>> {
    return this.http.get<Deck[]>(`${API_URL}/topics/${topic}/categories/${category}/decks`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  addDeck(topic: string, category: string, deck: DeckForCreation): Observable<HttpResponse<any>> {
    return this.http.post<any>(`${API_URL}/topics/${topic}/categories/${category}/decks`, deck, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  getDeck(topic: string, category: string, deck: string): Observable<HttpResponse<Deck>> {
    return this.http.get<Deck>(`${API_URL}/topics/${topic}/categories/${category}/decks/${deck}`, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }

  updateDeck(topic: string, category: string, deck: Deck): Observable<HttpResponse<any>> {
    return this.http.put(`${API_URL}/topics/${topic}/categories/${category}/decks`, deck, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.authService.getToken()}`
      }, observe: 'response'
    });
  }
}
