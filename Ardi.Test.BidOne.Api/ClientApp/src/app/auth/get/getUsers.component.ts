import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-getUsers',
  templateUrl: './getUsers.component.html'
})
export class GetUsersComponent {
  public users: User[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<User[]>(baseUrl + 'auth/getusers').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }
}

interface User {
  username: string;
  email: string;
}
