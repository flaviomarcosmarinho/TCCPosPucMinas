import { Component } from '@angular/core';
import { RequestLogin } from 'src/app/models/request/RequestLogin';
import { AlertService } from 'src/app/services/alert.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  public requestLogin: RequestLogin = new RequestLogin();

  constructor(
    private loginService: LoginService,
    private alertService: AlertService
  ) {}

  ngOnInit(): void {
  }

  public Login() : void {
    this.loginService.login(this.requestLogin).subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (error) => {
        console.error(error);
      }});
  }
}
