import { NgStyle } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ClickCounterService } from '../click-counter.service';

@Component({
  selector: 'app-level',
  standalone: true,
  imports: [NgStyle],
  templateUrl: './level.component.html',
  styleUrl: './level.component.scss'
})
export class LevelComponent implements OnInit {
  progress: number = 0
  level: number = 0;

  constructor(private clickService: ClickCounterService) { }

  ngOnInit() {
    this.clickService.clickCountSubscription().subscribe(r => {
      this.progress = (r?.todayScore ?? 0) % 100;
      this.level = Math.floor((r?.todayScore ?? 0) / 100) + 1;
    });
  }

}
