import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClickCounterService {
  private clicksSubject = new BehaviorSubject<number>(1000);
  private incrementCount = 2;
  clicks$ = this.clicksSubject.asObservable();


  incrementClicks() {
    this.clicksSubject.next(this.clicksSubject.value + this.incrementCount);
  }

  getClickCount() {
    return this.clicksSubject.value;
  }

  getIncrementCount(): number {
    return this.incrementCount;
  }
}