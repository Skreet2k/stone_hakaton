import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TelegramService {
  // Проверим, что Telegram WebApp доступен
  private isTelegramWebAppAvailable(): boolean {
    return typeof (window as any).Telegram !== 'undefined';
  }

  // Получим информацию о пользователе
  getUserData() {
    if (this.isTelegramWebAppAvailable()) {
      const tg = (window as any).Telegram.WebApp;
      const user = tg.initDataUnsafe?.user;
      if (user) {
        return {
          id: user.id,
          first_name: user.first_name,
          last_name: user.last_name,
          username: user.username,
        };
      } else {
        console.error('Нет данных о пользователе');
        return null;
      }
    } else {
      console.error('Telegram WebApp недоступен');
      return null;
    }
  }
}
