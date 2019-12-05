import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model: any = {};

  constructor(public authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(
      next => console.log('login successful'),
      error => console.log('login failed'),
      () => this.router.navigate(['/profile'])
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/home']);
  }

  isLoggedIn = () => this.authService.isLoggedIn();
}
