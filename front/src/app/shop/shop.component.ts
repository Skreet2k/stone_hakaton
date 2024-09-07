import { Component, OnInit } from '@angular/core';
import { Stone, StoneService } from '../stone.service';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-shop',
  standalone: true,
  imports: [NgClass],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss',
})
export class ShopComponent implements OnInit {
  stones: Stone[] = [];
  currentStone: Stone | undefined;
  index: number = 0;
  constructor(private stoneService: StoneService) {}

  ngOnInit() {
    this.stones = this.stoneService.getStones();
    this.fillCurrentStone();
  }

  clickRight() {
    if(this.index + 1 == this.stones.length) {
      this.index = 0;
    }
    else {
      this.index++;
    }
    this.fillCurrentStone();
  }

  clickLeft() {
    if(this.index - 1 < 0) {
      this.index = this.stones.length - 1;
    }
    else {
      this.index--;
    }
    this.fillCurrentStone();
  }

  private fillCurrentStone() {
    this.currentStone = this.stones[this.index];
  }
}
