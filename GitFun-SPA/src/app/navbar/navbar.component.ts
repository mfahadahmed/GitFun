import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model: any = {};

  constructor(public authService: AuthService, private router: Router,
    private notifierService: NotifierService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(
      next => this.notifierService.notify('success', 'Login Successfull!'),
      error => this.notifierService.notify('error', 'Login Failed!'),
      () => this.router.navigate(['/profile'])
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/home']);
    this.notifierService.notify('success', 'Logout Successfull!')
  }

  isLoggedIn = () => this.authService.isLoggedIn();
}
