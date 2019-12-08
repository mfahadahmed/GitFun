import { Component, OnInit, Input } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { NotifierService } from 'angular-notifier';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  user: User = {};

  constructor(private userService: UserService, private notifier: NotifierService,
    private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.userService.getUser(this.route.params['id']).subscribe(
      (data) => this.user = data,
      (err) => this.notifier.notify('error', err.error)
    )
  }

  editUser() {
    this.userService.updateUser(this.user.id, this.user).subscribe(
      () => {
        this.notifier.notify('success', 'User updated successfully');
        this.router.navigate(['/overview']);
      },
      (err) => this.notifier.notify('error', err.error)
    );
  }
}
