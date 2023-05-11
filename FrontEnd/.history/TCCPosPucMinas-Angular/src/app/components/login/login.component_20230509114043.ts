import { Component } from '@angular/core';
import { RequestLogin } from 'src/app/models/request/RequestLogin';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  public requestLogin: RequestLogin = new RequestLogin();

  constructor() {}

  ngOnInit(): void {
  }

  public Login() : void {
    console.log(this.requestLogin);
  }
}
