import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';
import { NotifierService } from 'angular-notifier';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  user: User;
  constructor(private userService: UserService, private notifier: NotifierService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.getUserDetails();
  }

  getUserDetails() {
    this.userService.getUser(this.route.snapshot.params['id']).subscribe(
      (user: User) => this.user = user,
      (error) => this.notifier.notify('error', error)
    );
  }

}
