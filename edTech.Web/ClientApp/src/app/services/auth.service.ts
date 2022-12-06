import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AUTH_ID } from '../app.constant';
import { Login } from '../models/login';
import { User } from '../models/user';
import { UserSignup } from '../models/usersignup';
import { UtilService } from './util.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user: User | undefined;
  httpHeaders: HttpHeaders;
  constructor(private httpClient: HttpClient, private utilService: UtilService) { 
    this.httpHeaders = new HttpHeaders({ 'content-type': 'application/json' });
  }

  ValidateUser(model: Login): Observable<HttpResponse<User>>{
    return this.httpClient.post<User>(environment.apiAddress + '/auth/validateUser', JSON.stringify(model),{
      headers: this.httpHeaders, observe: 'response'
    });
  }

  // UserSignUp(model: UserSignup): Observable<HttpResponse<any>>{
  //   console.log('inside auth service UserSignUp')
  //   console.log(model);
  //   return this.httpClient.post<any>(environment.apiAddress + '/auth/createuser', JSON.stringify(model),{
  //     headers: this.httpHeaders, observe: 'response'
  //   });
  // }

  UserSignUp(model: UserSignup): Observable<HttpResponse<any>> {
    return this.httpClient.post<any>(environment.apiAddress + '/auth/createuser', JSON.stringify(model), { headers: this.httpHeaders, observe: 'response' });
  }

  private LoadAuthUser(){
    const encData = localStorage.getItem(AUTH_ID);
    if(encData != undefined && encData != null){
      this.user = this.utilService.Decrypt(encData);
    }
    else{
      this.user = undefined;
    }
  }

  SetAuthUser(user: User){
    let userData = this.utilService.Encrypt(user);
    localStorage.setItem(AUTH_ID, userData);
    this.LoadAuthUser();
  }

  RemoveAuthUser(){
    const data = localStorage.getItem(AUTH_ID);
    if( data ! == undefined && data != null){
      localStorage.removeItem(AUTH_ID);
      this.user = undefined;
    }
    else{
      this.user = undefined;
    }

    this.LoadAuthUser();
  }
}
