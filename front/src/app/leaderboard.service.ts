import { Injectable } from '@angular/core';

export interface Leader {
  name: string;
  trophies: number;
  avatar: string;
}

@Injectable({
  providedIn: 'root'
})
export class LeaderboardService {

  constructor() { }

  // Моковые данные
  getLeaders(): Leader[] {
    return [
      { name: 'Meh', trophies: 10, avatar: 'images/avatar.png' },
      { name: 'Meh', trophies: 10, avatar: 'images/avatar.png' },
      { name: 'Meh', trophies: 10, avatar: 'images/avatar.png' },
      { name: 'Meh', trophies: 10, avatar: 'images/avatar.png' },
      { name: 'Meh', trophies: 10, avatar: 'images/avatar.png' },
      { name: 'Meh', trophies: 10, avatar: 'images/avatar.png' },
      { name: 'Meh', trophies: 10, avatar: 'images/avatar.png' },
    ];
  }
}