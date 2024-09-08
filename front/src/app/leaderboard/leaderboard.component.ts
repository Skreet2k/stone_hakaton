import { Component, OnInit } from '@angular/core';
import { LeaderboardService } from '../leaderboard.service';
import { NgClass, NgForOf } from '@angular/common';
import { Leaderboard } from '../http-service.service';

@Component({
  standalone: true,
  selector: 'app-leaderboard',
  templateUrl: './leaderboard.component.html',
  styleUrls: ['./leaderboard.component.scss'],
  imports: [NgClass, NgForOf],
})
export class LeaderboardComponent implements OnInit {

  leaderBoard: Leaderboard | undefined;
  Math: Math = Math;

  constructor(private leaderboardService: LeaderboardService) { }

  ngOnInit(): void {
     this.leaderboardService.getLeaders().subscribe(r => {
      this.leaderBoard = r;
    });
  }
}