import { Injectable } from '@angular/core';

export interface Mine {
  name: string;
  price: number;
  src: string;
  status: MineStatus;
  reward: number;
}

export interface MineStatus {
  state: MineState;
  time?: number;
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
        name: 'Базовая шахта ', price: 1500, reward: 50, src: 'images/mining1.png', status: {
          state: MineState.Locked
        }
      },
      {
        name: 'Базовая шахта ', price: 1500, reward: 50, src: 'images/mining1.png', status: {
          state: MineState.Available
        }
      },
      {
        name: 'Базовая шахта ', price: 1500, reward: 50, src: 'images/mining1.png', status: {
          state: MineState.Owned
        }
      },
      {
        name: 'Базовая шахта ', price: 1500, reward: 50, src: 'images/mining1.png', status: {
          state: MineState.Mining, time: 3600
        }
      }
    ];
  }
}
