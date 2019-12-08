import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';
import { NotifierService } from 'angular-notifier';
import { Router } from '@angular/router';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {
  user: User = {};
  constructor(private userService: UserService, private authService: AuthService,
    private notifier: NotifierService, private router: Router) { }

  ngOnInit() {
    this.getUser();
  }

  getUser() {
    this.userService.getUser(this.authService.getUserId()).subscribe(
      (user: User) => this.user = user,
      err => this.notifier.notify('error', err.error) 
    );
  }
}
