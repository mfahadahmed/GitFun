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
      (err: any) => this.notifierService.notify('error', err['error']),
      () => this.router.navigate(['/overview'])
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/home']);
  }

  isLoggedIn = () => this.authService.isLoggedIn();
}
