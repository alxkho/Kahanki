import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ApiRoutes } from '../common/ApiRoutes';
import { UserModel } from '../models/userModel';


@Injectable()
export class UserService {
    constructor(
      private readonly httpClient: HttpClient, 
      @Inject('BASE_URL') private baseUrl: string) {
    }

    GetCurrentUserId(): Observable<string> {
        return this.httpClient.get(`${this.baseUrl + ApiRoutes.UserSettings}/GetCurrentUserId`,{responseType: 'text'}) as Observable<string>;
    }
  }