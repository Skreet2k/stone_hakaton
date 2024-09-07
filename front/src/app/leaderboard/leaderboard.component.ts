import { Component, OnInit } from '@angular/core';
import { LeaderboardService, Leader } from '../leaderboard.service';
import { NgClass, NgForOf } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-leaderboard',
  templateUrl: './leaderboard.component.html',
  styleUrls: ['./leaderboard.component.scss'],
  imports: [NgClass, NgForOf],
})
export class LeaderboardComponent implements OnInit {

  leaders: Leader[] = [];

  constructor(private leaderboardService: LeaderboardService) { }

  ngOnInit(): void {
    this.leaders = this.leaderboardService.getLeaders();
  }
}