import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { TelegramService } from './telegram.service';
import { HttpService } from './http-service.service';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FooterComponent, HeaderComponent, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  title = 'stone';
  loaded = false;

  constructor(private telegramService: TelegramService, private httpService: HttpService) {}

  ngOnInit() {
    const user = this.telegramService.getUserData();

    this.httpService.initUser(user).subscribe(() => {
      this.loaded = true
    });
  }
}
