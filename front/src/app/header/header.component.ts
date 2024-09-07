import { Component, OnInit } from '@angular/core';
import { ClickCounterService } from '../click-counter.service';
import { TelegramService } from '../telegram.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent implements OnInit {
  clicks: number = 0;
  userName: string = "Имя из телеграмма";

  constructor(
    private clickCounterService: ClickCounterService,
    private telegramService: TelegramService) {}

  ngOnInit() {
    this.clickCounterService.clicks$.subscribe((clicks) => {
      this.clicks = clicks;
    });

    const user = this.telegramService.getUserData();

    if(user) {
      this.userName = user?.username;
    }
  }
}
