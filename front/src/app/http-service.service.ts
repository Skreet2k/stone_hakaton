import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './telegram.service';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  private baseUrl = 'https://stone-api.onebranch.dev/';

  constructor(private httpClient: HttpClient) {}

  getUserScore(userId: number): Observable<UserScore> {
    return this.httpClient.get<UserScore>(this.baseUrl + 'scores/' + userId);
  }

  initUser(user: User) {
    this.httpClient.post(this.baseUrl + 'users/init', user).subscribe();
  }

  click(userId: number): Observable<UserScore> {
    return this.httpClient.put<UserScore>(this.baseUrl + 'scores/click', {
      userId: userId,
      count: 1,
    });
  }

  getLeaderboard(
    userId: number,
    search: string | null
  ): Observable<Leaderboard> {
    return this.httpClient.get<Leaderboard>(
      this.baseUrl + 'scores/leaderboard?userId=' + userId + '&search=' + search
    );
  }

  getAllSkins(): Observable<Skin[]> {
    return this.httpClient.get<Skin[]>(this.baseUrl + 'skins');
  }

  getUserSkins(userId: number): Observable<Skin[]> {
    return this.httpClient.get<Skin[]>(this.baseUrl + 'skins?userId=' + userId);
  }

  getCurrentUserSkin(userId: number): Observable<Skin> {
    return this.httpClient.get<Skin>(
      this.baseUrl + 'skins/current?userId=' + userId
    );
  }

  buySkin(skinId: number, userId: number): Observable<void> {
    return this.httpClient.post<void>(
      this.baseUrl + 'shop/skins/' + skinId + '?userId=' + userId,
      {}
    );
  }

  applySkin(skinId: number, userId: number): Observable<void> {
    return this.httpClient.put<void>(
      this.baseUrl + 'skins?skinId=' + skinId + '&userId=' + userId,
      {}
    );
  }

  getMines(): Observable<Mine[]> {
    return this.httpClient.get<Mine[]>(this.baseUrl + 'miners');
  }

  getUserMines(userId: number): Observable<Mine[]> {
    return this.httpClient.get<Mine[]>(
      this.baseUrl + 'miners?userId=' + userId
    );
  }

  getActiveMine(userId: number): Observable<ActiveMine> {
    return this.httpClient.get<ActiveMine>(
      this.baseUrl + 'miners/current?userId=' + userId
    );
  }

  purchaseMine(userId: number, mineId: number): Observable<void> {
    return this.httpClient.put<void>(
      this.baseUrl + 'miners?userId=' + userId + '&minerId=' + mineId,
      {}
    );
  }
}

export interface ActiveMine {
  miner: Mine;
  startedAt: string,
  collectedInMine: number

}

export interface Mine {
  coinsCountPerTimeSpan: number;
  timeSpan: string;
  id: number;
  slug: string;
  name: string;
  discription: string;
  url: string;
  price: number;
  status: MineStatus
}

export interface MineStatus {
  state: MineState;
  time?: number;
  timeString?: string;
}

export enum MineState {
  None,
  Locked,
  Available,
  Owned,
  Mining
}

export interface UserScore {
  totalScore: number;
  todayLimit: number;
  todayScore: number;
  currentScore: number;
}

export interface Leaderboard {
  currentUser: Leader;
  leaders: Leader[];
}

export interface Leader {
  order: number;
  score: number;
  user: User;
}

export interface Skin {
  id: number;
  slug: string;
  name: string;
  discription: string;
  url: string;
  price: number;
}
