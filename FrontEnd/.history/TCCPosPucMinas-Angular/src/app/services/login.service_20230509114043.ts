import { Injectable } from '@angular/core';
import { RequestLogin } from '../models/request/RequestLogin';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }

  public login(requestLogin: RequestLogin) {
    return this.httpClient.post('http://localhost:8080/api/login', requestLogin);
  }
}
