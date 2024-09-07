import { Injectable } from '@angular/core';
import { HttpService, Leaderboard} from './http-service.service';
import { Observable } from 'rxjs';
import { TelegramService } from './telegram.service';

export interface Leader {
  name: string;
  trophies: number;
  avatar: string;
}

@Injectable({
  providedIn: 'root'
})
export class LeaderboardService {

  constructor(private httpService: HttpService, private telegramService: TelegramService) { }

  getLeaders(): Observable<Leaderboard> {
    var user = this.telegramService.getUserData();
    return this.httpService.getLeaderboard(user.userId);
  }
}