import { NgForOf, NgStyle } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ClickCounterService } from '../click-counter.service';
import { LevelComponent } from '../level/level.component';
import { Skin } from '../http-service.service';
import { SkinService } from '../skin.service';

@Component({
  selector: 'app-clicker',
  standalone: true,
  imports: [NgStyle, NgForOf, LevelComponent],
  templateUrl: './clicker.component.html',
  styleUrl: './clicker.component.scss',
})
export class ClickerComponent implements OnInit {
  title = 'stone';
  clicks: { x: number; y: number }[] = [];
  points: { x: number; y: number }[] = [];
  isAnimating = false;
  incrementCount = 1;
  userSkin: Skin | undefined;
  private timeout: any;
  private activeTouches: Set<number> = new Set(); // Множество для отслеживания уникальных касаний

  constructor(
    private clickCounterService: ClickCounterService,
    private skinService: SkinService
  ) {}

  ngOnInit(): void {
    this.incrementCount = this.clickCounterService.getIncrementCount();
    this.skinService.getCurrentSkin().subscribe(r => {
      this.userSkin = r;
    })
  }

  onTouch(event: TouchEvent) {
    event.preventDefault();

    for (let i = 0; i < event.touches.length && i < 4; i++) {
      const touch = event.touches[i];
      // Проверим, есть ли касание с этим идентификатором
      if (!this.activeTouches.has(touch.identifier)) {
        // Если нет, добавляем в множество и увеличиваем счетчик
        this.activeTouches.add(touch.identifier);
        const x = event.touches[i].clientX - 25;
        const y = event.touches[i].clientY - 25;

        this.onGameAreaClick(x, y);
      }
    }
  }

  onClick(event: MouseEvent) {
    const x = event.clientX - 25;
    const y = event.clientY - 25;
    this.onGameAreaClick(x, y);
  }

  // Очистим множество касаний, когда пальцы убираются с экрана
  onTouchEnd(event: TouchEvent) {
    for (let i = 0; i < event.changedTouches.length; i++) {
      const touch = event.changedTouches[i];
      this.activeTouches.delete(touch.identifier); // Убираем касания из множества
    }
  }

  private onGameAreaClick(x: number, y: number) {
    this.clickCounterService.incrementClicks();

    // Добавляем эффект +1
    this.points.push({ x, y });

    setTimeout(() => {
      this.points.shift();
    }, 1000); // +1 исчезает через 1 секунду

    // Если анимация ещё не запущена, запускаем её
    if (!this.isAnimating) {
      this.isAnimating = true;
    }

    // Если существует предыдущий таймер, сбрасываем его
    if (this.timeout) {
      clearTimeout(this.timeout);
    }

    // Устанавливаем новый таймер на 1 секунду после последнего клика
    this.timeout = setTimeout(() => {
      this.isAnimating = false; // Останавливаем анимацию через 1 секунду после последнего клика
    }, 200); // 1 секунда после последнего клика
  }
}
