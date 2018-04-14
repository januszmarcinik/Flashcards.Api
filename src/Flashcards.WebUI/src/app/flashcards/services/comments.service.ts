import {Injectable} from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {API_URL} from '../../../constans/constans';
import {Comment} from '../models/comment';
import {AuthService} from '../../shared/auth.service';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class CommentsService {

  constructor(private http: HttpClient,
              private authService: AuthService) {
  }

  getByCard(topic: string, category: string, deck: string, card: string): Observable<HttpResponse<Comment[]>> {
    return this.http.get<Comment[]>(
      `${API_URL}/topics/${topic}/categories/${category}/decks/${deck}/cards/${card}/comments`, {
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${this.authService.getToken()}`
        }, observe: 'response'
      });
  }

  getById(topic: string, category: string, deck: string, card: string, id: string): Observable<HttpResponse<Comment>> {
    return this.http.get<Comment>(
      `${API_URL}/topics/${topic}/categories/${category}/decks/${deck}/cards/${card}/comments/${id}`, {
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${this.authService.getToken()}`
        }, observe: 'response'
      });
  }

  add(topic: string, category: string, deck: string, card: string, comment: Comment): Observable<HttpResponse<any>> {
    return this.http.post<any>(
      `${API_URL}/topics/${topic}/categories/${category}/decks/${deck}/cards/${card}/comments`, comment, {
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${this.authService.getToken()}`
        }, observe: 'response'
      });
  }

}
