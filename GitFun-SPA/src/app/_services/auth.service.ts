import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  authUrl = 'http://localhost:5000/auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.authUrl + 'login', model).pipe(
      map((response: any) => {
        if (response) {
          localStorage.setItem('token', response.token);
          this.decodedToken = this.jwtHelper.decodeToken(localStorage.getItem('token'));
        }
      })
    );
  }

  register = (registrationData: any) => this.http.post(this.authUrl + 'register', registrationData);

  isLoggedIn = () => !this.jwtHelper.isTokenExpired(localStorage.getItem('token'));

  getUsername = () => this.decodedToken.unique_name;
}
