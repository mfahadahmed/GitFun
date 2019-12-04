import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  users: any;
  
  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.httpClient.get('http://localhost:5000/users').subscribe(response => {
      this.users = response;
      console.log(this.users);
    }, error => console.log(error));
  }

}
