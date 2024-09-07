import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private baseUrl = "/api/"

  constructor(private httpClient: HttpClient) { }

  getUserScore(userId: any): Observable<UserScore> {
    return this.httpClient.post<UserScore>(this.baseUrl + "score", {userId: userId});
  }
}

export class UserScore {
  totalScore!: number;
  todayLimit!: number;
}