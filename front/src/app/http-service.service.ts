import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './telegram.service';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private baseUrl = "https://stone-api.onebranch.dev/"

  constructor(private httpClient: HttpClient) { }

  getUserScore(userId: number): Observable<UserScore> {
    return this.httpClient.get<UserScore>(this.baseUrl + "scores/" + userId);
  }

  initUser(user: User) {
    this.httpClient.post(this.baseUrl + "users/init", user).subscribe();
  }

  click(userId: number): Observable<UserScore> {
    return this.httpClient.put<UserScore>(this.baseUrl + "scores/click", {userId: userId, count: 1});
  }

  getLeaderboard(userId: number): Observable<Leaderboard> {
    return this.httpClient.get<Leaderboard>(this.baseUrl + "scores/leaderboard?userId=" + userId);
  }
}

export interface UserScore {
  totalScore: number;
  todayLimit: number;
  todayScore: number;
  currentScore: number;
}

export interface Leaderboard {
  currentUser: Leader;
  leaders: Leader[]
}

export interface Leader {
  order: number;
  score: number;
  user: User
}