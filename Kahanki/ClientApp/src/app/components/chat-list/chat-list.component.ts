import { Component } from '@angular/core';
import { UserShortProfileModel } from 'src/app/models/UserShortProfileModel';
import { ChatService } from 'src/app/services/chatService';
import { DateService } from 'src/app/services/dateService';

@Component({
  selector: 'app-chat-list',
  templateUrl: './chat-list.component.html',
  providers: [ChatService, DateService]
})
export class ChatListComponent {

    public chatList: UserShortProfileModel[] = [];

  constructor(private chatService: ChatService, private dateService: DateService) {
    chatService.GetAllChatsForCurrentUser().toPromise().then(c => this.chatList = c);
  }

  async ngOnInit()	{
  }

  disMatch(targetUser: string) {
    this.dateService.DisMatch(targetUser).toPromise();
    this.chatList = this.chatList.filter(r => r.id != targetUser)
  }

}
