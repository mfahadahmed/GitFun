import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model: any = {};

  constructor(public authService: AuthService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(
      next => console.log('login successful'),
      error => console.log('login failed')
    );
  }

  logout = () => localStorage.removeItem('token');

  isLoggedIn = () => this.authService.isLoggedIn();
}
