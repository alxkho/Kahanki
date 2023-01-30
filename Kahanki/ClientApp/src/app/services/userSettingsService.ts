import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { ApiRoutes } from "../common/ApiRoutes";
import { CommonService } from "./common-service";
import { UserSettingsModel } from "./../models/UserSettingsModel";

@Injectable()
export class UserSettingsService extends CommonService<UserSettingsModel>
{
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        super(http, baseUrl, ApiRoutes.UserSettings);
    }

    async getCurrentUserSettings(): Promise<UserSettingsModel> {
        var url = this.baseUrl + ApiRoutes.UserSettings + "/GetCurrentUserSettings";
        var result = await this.http
            .get<UserSettingsModel>(url)
            .toPromise();

        return result;
    }
}