import { Component, OnInit } from '@angular/core';
import { MineService } from '../mine.service';
import { NgClass, NgForOf, NgIf, NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';
import { Mine, MineState } from '../http-service.service';

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
    this.mineService.getMines().subscribe((allMines) => {
      this.mines = allMines.sort((a, b) => (a.price > b.price) ? 1 : (a.price < b.price) ? -1 : 0);

      this.mineService.getUserMines().subscribe((ownedMines) => {
        this.mines.forEach(mine => {
          const ownedMine = ownedMines.find(x => x.id == mine.id);
          if (!ownedMine) {
            mine.status = {
              state: MineState.Available
            }
          }

          if (ownedMine) {
            mine.status = {
              state: MineState.Owned
            }
          }
        })
      });
    });



    // this.mines.forEach(m => {
    //   if (m.status.time) {
    //     setTimeout(() => {
    //       this.timer(m);
    //     }, 1000);
    //   }
    // })
  }

  // async timer(mine: Mine) {
  //   if (mine.status.time) {
  //     mine.status.time--;
  //     mine.status.timeString = `${Math.floor(mine.status.time / 60)}:${mine.status.time % 60}`
  //     await setTimeout(() => {
  //       this.timer(mine);
  //     }, 1000);
  //   }
  // }

  async purchaseMine(mine: Mine) {
    this.mineService.purchaseMine(mine).subscribe(r => { });
  }

  async startMining(mine: Mine) {
    this.mineService.startMining(mine);
  }

  async getReward(mine: Mine) {
    this.mineService.getReward(mine);
  }
}
