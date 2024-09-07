import { Component, OnInit } from '@angular/core';
import { MineService, Mine, MineStatus, MineState } from '../mine.service';
import { NgClass, NgForOf, NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';

@Component({
  selector: 'app-mining',
  standalone: true,
  imports: [NgClass, NgForOf, NgSwitch, NgSwitchCase],
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
  }
}
