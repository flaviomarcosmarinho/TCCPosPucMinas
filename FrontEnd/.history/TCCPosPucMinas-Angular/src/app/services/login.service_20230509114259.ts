import { Injectable } from '@angular/core';
import { RequestLogin } from '../models/request/RequestLogin';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseLogin } from '../models/response/ResponseLogin';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }

  public login(requestLogin: RequestLogin) : Observable<ResponseLogin> {
    return this.httpClient.post<ResponseLogin>('http://localhost:8080/api/login', requestLogin);
  }
}
