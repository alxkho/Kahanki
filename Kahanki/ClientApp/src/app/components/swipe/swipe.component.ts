import { Component } from '@angular/core';
import { UserService } from 'src/app/services/userService';
import { UserProfileModel } from 'src/app/models/userProfileModel';
import { DateService } from 'src/app/services/dateService';

@Component({
  selector: 'app-swipe',
  templateUrl: './swipe.component.html',
  providers: [DateService, UserService]
})
export class SwipeComponent {

  public candidate: UserProfileModel = {
    id: '',
    age: 0,
    name: '',
    description: '',
    job: '',
    education: ''
  }

  constructor(private dateService: DateService) {
    this.Next();
  }

  async ngOnInit()	{
  }

  public Next() {
    this.dateService.GetNext().toPromise().then(c => c != null ? this.candidate = c : this.candidate.id = '');
  }

  public Like() {
    this.SubmitResult(0);
  }
  
  public Superlike() {
    this.SubmitResult(1);
  }
  
  public Disike() {
    this.SubmitResult(2);
  }

  private SubmitResult(action: number) {
    this.dateService.SubmitUserCation(this.candidate.id, action).toPromise().then(() => this.Next());
  }
}
