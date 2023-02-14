import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-userRegister',
  templateUrl: './userRegister.component.html'
})
export class UserRegisterComponent {
  public userRegister: UserRegister = new UserRegister();

  public username: string = "";
  public password: string = "";
  public passwordConfirm: string = "";
  public email: string = "";

  public result: UserRegisterCode = new UserRegisterCode();
  public baseUrl: string = "";
  public http: HttpClient;
  public router: Router;
;

  constructor(router: Router, http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this.baseUrl = baseUrl;
    this.http = http;
    this.router = router;
  }

  public submit()
  {
    this.userRegister.username = this.username;
    this.userRegister.email = this.email;
    this.userRegister.password = this.password;
    this.userRegister.passwordConfirm = this.passwordConfirm;
    this.http.post<UserRegisterCode>(this.baseUrl + 'auth/register', this.userRegister).subscribe(result =>
    {
      this.result = result;
      console.log(result);
      if (result != null && result.code != "" && result.code == "Succeed")
      {
        this.router.navigate(['getUsers']);
      }
      else
      {
        alert(result.code);
      }
      
    }, error => console.error(error));
  }
}

export class UserRegister {
  username: string = "";
  password: string = "";
  passwordConfirm: string = "";
  email: string = "";
}

export class UserRegisterCode
{
  code: string = "";
}
