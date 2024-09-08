import { Injectable } from '@angular/core';
import { HttpService } from './http-service.service';
import { TelegramService } from './telegram.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  constructor(
    private httpService: HttpService,
    private telegramService: TelegramService
  ) {}

  buySkin(skinId: number): Observable<void> {
    const user = this.telegramService.getUserData();

    return this.httpService.buySkin(skinId, user.userId);
  }
}
