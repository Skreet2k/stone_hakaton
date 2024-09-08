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
  todayLimitShort: string | undefined;

  constructor(
    private clickCounterService: ClickCounterService,
    private telegramService: TelegramService
  ) {}

  ngOnInit() {
    this.clickCounterService.clicks$.subscribe((r) => {
      if (r) {
        this.todayLimitShort = this.shortNumber(r!.todayLimit);
      }
      this.userScore = r;
    });

    this.user = this.telegramService.getUserData();
  }

  private shortNumber(value: number) {
    const suffixes = ['', 'k', 'M', 'B', 'T']; // Суффиксы для тысяч, миллионов и т.д.
    let suffixIndex = 0;

    // Увеличиваем суффикс по мере деления числа на 1000
    while (Math.abs(value) >= 1000 && suffixIndex < suffixes.length - 1) {
      value /= 1000;
      suffixIndex++;
    }

    // Если число больше 100, оставляем только целую часть (например, 150k)
    if (value >= 100) {
      return Math.round(value) + suffixes[suffixIndex];
    }

    // Если число от 10 до 100, округляем до одного знака после запятой (например, 15.3k)
    if (value >= 10) {
      return value.toFixed(1).replace(/\.0$/, '') + suffixes[suffixIndex];
    }

    // Если число меньше 10, показываем два знака после запятой (например, 9.87M)
    return (
      value
        .toFixed(2)
        .replace(/\.00$/, '')
        .replace(/(\.\d)0$/, '$1') + suffixes[suffixIndex]
    );
  }
}
