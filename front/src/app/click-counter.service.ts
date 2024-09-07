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

  constructor(private http: HttpService, telegramService: TelegramService) {
    this.userId = telegramService.getUserData()?.userId;
    this.http.getUserScore(this.userId).subscribe(r => {
      this.clicksSubject.next(r);
    })
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
}