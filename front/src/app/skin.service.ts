import { Injectable } from '@angular/core';
import { HttpService, Skin } from './http-service.service';
import { Observable } from 'rxjs';
import { TelegramService } from './telegram.service';

@Injectable({
  providedIn: 'root',
})
export class SkinService {
  constructor(
    private httpService: HttpService,
    private telegramService: TelegramService
  ) {}

  getSkins(): Observable<Skin[]> {
    return this.httpService.getAllSkins();
  }

  getUserSkins(): Observable<Skin[]> {
    const user = this.telegramService.getUserData();
    return this.httpService.getUserSkins(user.userId);
  }

  getCurrentSkin(): Observable<Skin> {
    const user = this.telegramService.getUserData();
    return this.httpService.getCurrentUserSkin(user.userId);
  }

  applySkin(skinId: number): Observable<void> {
    const user = this.telegramService.getUserData();
    return this.httpService.applySkin(skinId, user.userId);
  }
}
