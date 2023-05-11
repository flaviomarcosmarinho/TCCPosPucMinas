import { Component } from '@angular/core';
import { RequestLogin } from 'src/app/models/RequestLogin';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  public requestLogin: RequestLogin;

  constructor() {}

  ngOnInit(): void {
    this.requestLogin = new RequestLogin();
  }
}
