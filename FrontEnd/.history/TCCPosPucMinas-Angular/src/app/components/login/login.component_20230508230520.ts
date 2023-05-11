import { Component } from '@angular/core';
import { RequestLogin } from 'src/app/models/RequestLogin';

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

  Login() {

  }
}
