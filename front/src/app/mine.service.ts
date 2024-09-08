import { Injectable } from '@angular/core';
import { Observable, Timestamp } from 'rxjs';
import { ActiveMine, HttpService, Mine } from './http-service.service';
import { TelegramService } from './telegram.service';

@Injectable({
  providedIn: 'root'
})

export class MineService {

  constructor(
    private httpService: HttpService,
    private telegramService: TelegramService
  ) { }

  getMines(): Observable<Mine[]> {
    return this.httpService.getMines();
  }

  getUserMines(): Observable<Mine[]> {
    const user = this.telegramService.getUserData();
    return this.httpService.getUserMines(user.userId);
  }

  getActiveMiner(): Observable<ActiveMine> {
    const user = this.telegramService.getUserData();
    return this.httpService.getActiveMine(user.userId);
  }

  purchaseMine(mine: Mine) {
    const user = this.telegramService.getUserData();
    return this.httpService.purchaseMine(user.userId, mine.id);
  }

  startMining(mine: Mine) {
    const user = this.telegramService.getUserData();
    return this.httpService.startMining(user.userId, mine.id);
  }

  getReward(mine: Mine) {
    const user = this.telegramService.getUserData();
    return this.httpService.getReward(user.userId);
  }
}
