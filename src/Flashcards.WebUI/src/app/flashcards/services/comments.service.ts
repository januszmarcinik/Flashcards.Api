import {Injectable} from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http';

import {Comment} from '../models/comment';
import {AuthService} from '../../shared/auth.service';
import {Observable} from 'rxjs/Observable';
import {environment} from '../../../environments/environment';

@Injectable()
export class CommentsService {

  constructor(private http: HttpClient,
              private authService: AuthService) {
  }

  getByCard(deck: string, card: string): Observable<HttpResponse<Comment[]>> {
    return this.http.get<Comment[]>(
      `${environment.API_URL}/decks/${deck}/cards/${card}/comments`, {
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${this.authService.getToken()}`
        }, observe: 'response'
      });
  }

  getById(deck: string, card: string, id: string): Observable<HttpResponse<Comment>> {
    return this.http.get<Comment>(
      `${environment.API_URL}/decks/${deck}/cards/${card}/comments/${id}`, {
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${this.authService.getToken()}`
        }, observe: 'response'
      });
  }

  add(deck: string, card: string, comment: Comment): Observable<HttpResponse<any>> {
    return this.http.post<any>(
      `${environment.API_URL}/decks/${deck}/cards/${card}/comments`, comment, {
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${this.authService.getToken()}`
        }, observe: 'response'
      });
  }

}
