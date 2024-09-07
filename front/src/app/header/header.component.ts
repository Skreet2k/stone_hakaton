import { Component, OnInit } from '@angular/core';
import { ClickCounterService } from '../click-counter.service';
import { TelegramService, User } from '../telegram.service';
import { UserScore } from '../http-service.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent implements OnInit {
  user: User | undefined;
  userScore: UserScore | undefined;

  constructor(
    private clickCounterService: ClickCounterService,
    private telegramService: TelegramService) {}

  ngOnInit() {
    this.clickCounterService.clicks$.subscribe((r) => {
      this.userScore = r;
    });

    this.user = this.telegramService.getUserData();
  }
}
