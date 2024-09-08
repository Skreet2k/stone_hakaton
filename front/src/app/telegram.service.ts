import { Injectable } from '@angular/core';

export interface User {
  userId: number;
  firstName: string;
  lastName: string;
  username: string;
  avatar: string;
}

@Injectable({
  providedIn: 'root',
})
export class TelegramService {
  user: User = {
    userId: 267575209,
    firstName: 'Alexander',
    lastName: 'Kharkovskiy',
    username: 'akharkovskiy',
    avatar: 'images/avatar.png'
  };

  // Проверим, что Telegram WebApp доступен
  private isTelegramWebAppAvailable(): boolean {
    return typeof (window as any).Telegram !== 'undefined';
  }

  // Получим информацию о пользователе
  getUserData(): User {
    const localUser = localStorage.getItem('user');

    if(localUser) { 
      this.user = JSON.parse(localUser);
      return this.user;
    }

    if (this.isTelegramWebAppAvailable()) {
      const tg = (window as any).Telegram.WebApp;
      const user = tg.initDataUnsafe?.user;
      if (user) {
        this.user = {
          firstName: user.first_name,
          lastName: user.last_name,
          userId: user.id,
          username: user.username,
          avatar: 'images/avatar.png'
        };
        localStorage.setItem('user', JSON.stringify(this.user));
      } else {
        console.error('Нет данных о пользователе');
      }
    } else {
      console.error('Telegram WebApp недоступен');
    }
    return this.user;
  }
}
