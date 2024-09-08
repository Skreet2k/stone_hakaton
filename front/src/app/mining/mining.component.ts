import { Component, OnInit } from '@angular/core';
import { MineService, Mine, MineStatus, MineState } from '../mine.service';
import { NgClass, NgForOf, NgIf, NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';

@Component({
  selector: 'app-mining',
  standalone: true,
  imports: [NgClass, NgForOf, NgSwitch, NgSwitchCase, NgIf],
  templateUrl: './mining.component.html',
  styleUrl: './mining.component.scss'
})
export class MiningComponent implements OnInit {

  public mineState = MineState;
  mines: Mine[] = [];

  constructor(private mineService: MineService) {

  }

  ngOnInit() {
    this.mines = this.mineService.getMines();

    this.mines.forEach(m => {
      if (m.status.time) {
        setTimeout(() => {
          this.timer(m);
        }, 1000);
      }
    })
  }

  async timer(mine: Mine) {
    if (mine.status.time) {
      mine.status.time--;
      mine.status.timeString = `${Math.floor(mine.status.time / 60)}:${mine.status.time % 60}`
      await setTimeout(() => {
        this.timer(mine);
      }, 1000);
    }
  }
}
