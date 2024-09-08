import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { TelegramService } from './telegram.service';
import { HttpService, UserScore } from './http-service.service';

@Injectable({
  providedIn: 'root'
})
export class ClickCounterService {
  private clicksSubject = new BehaviorSubject<UserScore | undefined>(undefined);
  private incrementCount = 1;
  clicks$ = this.clicksSubject.asObservable();
  userId: any;

  constructor(private http: HttpService, private telegramService: TelegramService) {
    this.actualScore();
  }

  incrementClicks() {
    this.http.click(this.userId).subscribe(r => {
      this.clicksSubject.next(r);
    })
  }

  clickCountSubscription(): Observable<UserScore | undefined> {
    return this.clicksSubject.asObservable();
  }

  getIncrementCount(): number {
    return this.incrementCount;
  }

  actualScore() {
    this.userId = this.telegramService.getUserData()?.userId;
    this.http.getUserScore(this.userId).subscribe(r => {
      this.clicksSubject.next(r);
    })
  }
}