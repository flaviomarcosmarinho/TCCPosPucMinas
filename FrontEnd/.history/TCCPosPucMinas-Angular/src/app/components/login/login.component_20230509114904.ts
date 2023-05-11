import { Component } from '@angular/core';
import { RequestLogin } from 'src/app/models/request/RequestLogin';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  public requestLogin: RequestLogin = new RequestLogin();

  constructor( private loginService: LoginService) {}

  ngOnInit(): void {
  }

  public Login() : void {
    this.loginService.login(this.requestLogin).subscribe(response => {
      console.log(response);
    }, (error) => {
      console.error(error);
    });
  }
}
