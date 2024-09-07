import { Injectable } from '@angular/core';

export interface Stone {
  name: string;
  price: number;
  src: string;
  isPurchased: boolean;
} 

@Injectable({
  providedIn: 'root'
})
export class StoneService {

  constructor() { }

    // Моковые данные
    getStones(): Stone[] {
      return [
        { name: 'Cool name', price: 1000, src: 'stones/fermer-4-450px.png', isPurchased: true},
          { name: 'Cool name', price: 1000, src: 'stones/firestone-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/gold-1-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/gold-2-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/gold-3-350px.png', isPurchased: true},
          { name: 'Cool name', price: 1000, src: 'stones/gold-4-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/gray-1-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/gray-2-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/gray-3-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/gray-4-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/gray-5-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/gray-6-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/gray-7-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/gray-8-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/gray-9-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/minestone-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/police-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/red-1-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/red-2-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/red-3-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/red-4-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/red-5-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/stone-1-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/stone-2-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/stone-3-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/stone-redflag-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/stonetooth-1-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/stonetooth-2-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/turtle-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/white-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/bdsm-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/circle-stone350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/clown-1-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/clown-2-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/clown-3-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/clown-4.5-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/clown-4-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/clown-5-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/clown-6-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/fermer-1-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/fermer-2-350px.png', isPurchased: false},
          { name: 'Cool name', price: 1000, src: 'stones/fermer-3-350px.png', isPurchased: false}
      ];
    }
}
