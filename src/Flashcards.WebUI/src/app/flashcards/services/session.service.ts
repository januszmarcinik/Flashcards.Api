import {Injectable} from '@angular/core';
import {AuthService} from '../../shared/auth.service';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
import {environment} from '../../../environments/environment';
import {SessionState} from "../models/session/sessionState";

@Injectable()

@Injectable()
export class SessionService {

  constructor(private http: HttpClient,
              private authService: AuthService) { }

  getSessionState(topic: string, category: string, deck: string): Observable<HttpResponse<SessionState>> {
    return this.http.get<SessionState>(
      `${environment.API_URL}/topics/${topic}/categories/${category}/decks/${deck}/sessions`, {
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${this.authService.getToken()}`
        }, observe: 'response'
      });
  }

  applySessionCard(topic: string, category: string, deck: string, card: any): Observable<HttpResponse<SessionState>> {
    return this.http.post<SessionState>(
      `${environment.API_URL}/topics/${topic}/categories/${category}/decks/${deck}/sessions`, card, {
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${this.authService.getToken()}`
        }, observe: 'response'
      });
  }

}
