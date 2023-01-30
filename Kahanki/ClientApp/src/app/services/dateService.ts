import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ApiRoutes } from '../common/ApiRoutes';
import { UserProfileModel } from '../models/userProfileModel';


@Injectable()
export class DateService {
    constructor(
      private readonly httpClient: HttpClient, 
      @Inject('BASE_URL') private baseUrl: string) {
    }

    GetNext(): Observable<UserProfileModel> {
        return this.httpClient.get(`${this.baseUrl + ApiRoutes.Date}/GetNextProfile`) as Observable<UserProfileModel>;
    }

    SubmitUserCation(targetUserId: string, actionId: number) {
        return this.httpClient.get(`${this.baseUrl + ApiRoutes.Date}/SubmitUserAction?targetUserId=${targetUserId}&actionId=${actionId}`) as Observable<boolean>;
    }

    DisMatch(targetUser: string) {
        return this.httpClient.get(`${this.baseUrl + ApiRoutes.Date}/DisMatch?targetUser=${targetUser}`) as Observable<boolean>;
    }
  }