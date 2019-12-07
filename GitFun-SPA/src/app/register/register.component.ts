import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ThrowStmt } from '@angular/compiler';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { User } from '../_models/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: User = {};

  constructor(private authService: AuthService, private router: Router, private notifier: NotifierService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.model).subscribe(() => {
      this.notifier.notify('success', 'Registeration Successfull!');
      this.cancelRegister.emit(false);
    }, () => {
      this.notifier.notify('error', 'Registeration Failed!');
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
