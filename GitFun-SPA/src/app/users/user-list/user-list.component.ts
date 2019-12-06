import { Component, OnInit } from '@angular/core';
import { UserService } from '../../_services/user.service';
import { NotifierService } from 'angular-notifier';
import { User } from '../../_models/user';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: User[];
  
  constructor(private userService: UserService, private notifier: NotifierService) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    return this.userService.getUsers().subscribe(
      users => this.users = users,
      error => this.notifier.notify('error', error)
    );
  }

}
