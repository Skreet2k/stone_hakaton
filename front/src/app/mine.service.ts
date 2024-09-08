import { Injectable } from '@angular/core';

export interface Mine {
  id: string;
  name: string;
  price: number;
  src: string;
  status: MineStatus;
  reward: number;
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

@Injectable({
  providedIn: 'root'
})

export class MineService {

  constructor() { }

  // моковые данные
  getMines(): Mine[] {
    return [
      {
        id: '1', name: 'Базовая шахта ', price: 1500, reward: 50, src: 'images/mining1.png', status: {
          state: MineState.Locked
        }
      },
      {
        id: '2', name: 'Базовая шахта ', price: 1500, reward: 50, src: 'images/mining1.png', status: {
          state: MineState.Available
        }
      },
      {
        id: '3', name: 'Базовая шахта ', price: 1500, reward: 50, src: 'images/mining1.png', status: {
          state: MineState.Owned
        }
      },
      {
        id: '4', name: 'Базовая шахта ', price: 1500, reward: 50, src: 'images/mining1.png', status: {
          state: MineState.Mining, time: 3600
        }
      }
    ];
  }

  purchaseMine(mine: Mine) {

  }

  startMining(mine: Mine) {

  }

  getReward(mine: Mine) {

  }
}
