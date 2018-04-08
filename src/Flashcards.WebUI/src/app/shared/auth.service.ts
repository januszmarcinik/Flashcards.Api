import {Injectable} from '@angular/core';
import {Token} from '../users/models/token';


export const TOKEN_NAME = 'jwt_token';
export const EXPIRY = 'expiry';


@Injectable()
export class AuthService {
  getToken(): string {
    return localStorage.getItem(TOKEN_NAME);
  }

  setToken(tokenModel: Token) {
    localStorage.setItem(TOKEN_NAME, tokenModel.token);
    localStorage.setItem(EXPIRY, tokenModel.expiry);
  }

  getTokenExpirationDate(): number {
    const validTo = localStorage.getItem((EXPIRY));
    return Date.parse(validTo);
  }

  isTokenExpired(token?: string): boolean {
    if (!token) token = this.getToken();
    if (!token) return true;

    const date = this.getTokenExpirationDate();
    if (date === undefined) return false;
    return !(date.valueOf() > new Date().valueOf());
  }

  removeTokens(): void {
    localStorage.removeItem(TOKEN_NAME);
    localStorage.removeItem(EXPIRY);
  }

}
