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
        id: '1', name: 'Basic', price: 500, reward: 50, src: 'images/mining1.png', status: {
          state: MineState.Mining
        }
      },
      {
        id: '2', name: 'Advenced', price: 1500, reward: 50, src: 'images/mining2.png', status: {
          state: MineState.Available
        }
      },
      {
        id: '3', name: 'Cyberpunk', price: 3000, reward: 50, src: 'images/mining3.png', status: {
          state: MineState.Locked
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
