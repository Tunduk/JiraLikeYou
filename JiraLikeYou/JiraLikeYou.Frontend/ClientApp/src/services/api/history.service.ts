import { HttpService } from "./httpService";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { HistoryApiDto } from "./historyApiDto";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class HistoryService extends HttpService {
  constructor(http: HttpClient) {
    super(http,"Occasion");
  }


  public getLastHistory(): Observable<HistoryApiDto[]>{
    return this.get<HistoryApiDto[]>();
  }
}
