import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ApiRoutes } from '../common/ApiRoutes';
import { UserShortProfileModel } from '../models/UserShortProfileModel';
import { ChatModel } from '../models/chatModel';
import { tap, map } from 'rxjs/operators';


@Injectable()
export class ChatService {
    constructor(
      private readonly httpClient: HttpClient,
      @Inject('BASE_URL') private baseUrl: string) {
    }

    GetAllChatsForCurrentUser() {
        return this.httpClient.get(`${this.baseUrl + ApiRoutes.Chat}/GetChatList`) as Observable<UserShortProfileModel[]>;
    }

    GetChatByTargetId(targetUserId: string) {
        return this.httpClient.get<ChatModel>(`${this.baseUrl + ApiRoutes.Chat}/GetChatByTargetUserId?targetUserId=${targetUserId}`);
    }
  }