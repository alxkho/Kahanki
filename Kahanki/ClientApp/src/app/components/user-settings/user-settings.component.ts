import { Component } from '@angular/core';
import { UserSettingsService } from 'src/app/services/userSettingsService';
import { UserService } from 'src/app/services/userService';
import { UserSettingsModel } from 'src/app/models/UserSettingsModel';

@Component({
  selector: 'app-user-settings',
  templateUrl: './user-settings.component.html',
  providers: [UserSettingsService, UserService]
})
export class UserSettingsComponent {
  public settings: UserSettingsModel = {
    id: '',
    age: 0,
    sex: 0,
    preferences: 0,
    job: "",
    education: "",
    description: "",
    ageFrom: 0,
    ageTo: 0,
    realName: ''
  };

  constructor(private userSettingsService: UserSettingsService) {
    userSettingsService.getCurrentUserSettings().then( c => this.settings = c);
  }

  async ngOnInit()	{
  }

  public Save() {
    this.userSettingsService.update(this.settings);
  }
}
