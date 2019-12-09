import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { UserService } from '../../_services/user.service';
import { NotifierService } from 'angular-notifier';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from 'src/app/_models/user';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  @Input() user: User;
  @Output() disableEdit = new EventEmitter();

  constructor(private userService: UserService, private notifier: NotifierService) { }

  ngOnInit() {
  }

  editUser() {
    this.userService.updateUser(this.user.id, this.user).subscribe(
      () => {
        this.notifier.notify('success', 'User updated successfully');
        this.disableEdit.emit(false);
      },
      (err) => this.notifier.notify('error', err.error)
    );
  }
}
