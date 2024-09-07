import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { TelegramService } from './telegram.service';
import { HttpService } from './http-service.service';

@Injectable({
  providedIn: 'root'
})
export class ClickCounterService {
  private clicksSubject = new BehaviorSubject<number>(1000);
  private incrementCount = 2;
  clicks$ = this.clicksSubject.asObservable();
  userId: any;

  constructor(private http: HttpService, telegramService: TelegramService) {
    this.userId = telegramService.getUserData()?.id ?? 267575209;
    this.http.getUserScore(this.userId).subscribe(r => {
      this.clicksSubject.next(r.totalScore);
    })
  }

  incrementClicks() {
    this.clicksSubject.next(this.clicksSubject.value + this.incrementCount);
  }

  getClickCount(): Observable<number> {
    return this.clicksSubject.asObservable();
  }

  getIncrementCount(): number {
    return this.incrementCount;
  }
}