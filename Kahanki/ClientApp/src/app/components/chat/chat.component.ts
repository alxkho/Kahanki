import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ChatModel } from 'src/app/models/chatModel';
import { ChatService } from 'src/app/services/chatService';
import * as signalR from "@microsoft/signalr";
import { UserService } from 'src/app/services/userService';
import { ViewportScroller } from '@angular/common';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css'],
  providers: [ChatService, UserService]
})
export class ChatComponent implements OnInit, OnDestroy {
  id!: string;
  private sub: any;

  connection!: signalR.HubConnection;

  currentMessage: string = '';

  currentUserId: string = '';

  secondUserName: string = '';

  chat: ChatModel = {
    id: '',
    messages: [],
    users: []
  }

  constructor(
    private route: ActivatedRoute,
    private chatService: ChatService, 
    private userService: UserService, 
    private scroller: ViewportScroller,
    @Inject('BASE_URL') private baseUrl: string) {

      this.userService.GetCurrentUserId().subscribe(c => this.currentUserId = c);
      
      this.connection = new signalR.HubConnectionBuilder()
      .withUrl(baseUrl+"chatHub")
      .build()
      
      this.connection
      .start()
      .then(() => console.log('WS connection started'))
      .catch(err => console.log('Error while starting WS connection: ' + err));
      this.goDown();
  }

  async ngOnInit() {
    this.goDown();
    this.sub = this.route.params.subscribe(params => {
      this.id = params['id'];

      this.chatService.GetChatByTargetId(this.id)
      .toPromise()
      .then(c => {
          this.chat = {
            id: c.id,
            users: c.users.map(s => {
              if(s.id == this.id) 
                this.secondUserName = s.userName
              return ({
              id: s.id,
                userName: s.userName
            })}),
            messages: c.messages.map(s => ({
              id: s.id,
              content: s.content,
              created: s.created,
              senderId: s.senderId}))
          };   

          this.connection.on('messageReceived', (chatId: string, username: string, message: string, created: Date) => {
            if(chatId == this.chat.id) {

              this.chat.messages.push({
                id: '',
                content: message,
                senderId: username,
                created: created
              })
            }
          });
          this.goDown();
        });
    });
  }

  goDown() {
    this.scroller.scrollToAnchor("messageInput");
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  Send() {
    if(this.currentMessage.trim() != "") {
      this.connection
      .send('sendMessage', this.chat.id, this.currentUserId, this.currentMessage)
      .then(() => (this.currentMessage = ""));
    }
  }
}
