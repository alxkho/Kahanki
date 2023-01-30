import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
import { ApiRoutes } from "../common/ApiRoutes";

export class CommonService<TModel>
{
    http: HttpClient;
    baseUrl: string;
    controllerUrl: string;

    constructor(http: HttpClient, baseUrl: string, controllerUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.controllerUrl = controllerUrl;
      }

    create()
    {
    }

    async read(id: string)
    {
        return this.http
            .get<TModel>(`${this.baseUrl + this.controllerUrl}/Read?id=${id}`)
            .subscribe(result => result);
    }

    async update(model: TModel)
    {
        return this.http
            .put<TModel>(`${this.baseUrl + this.controllerUrl}/Update`, model)
            .subscribe(result => result);
    }

    delete()
    {

    }

    list()
    {
        
    }
}