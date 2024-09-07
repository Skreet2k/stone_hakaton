import { Routes } from '@angular/router';
import { ClickerComponent } from './clicker/clicker.component';
import { ShopComponent } from './shop/shop.component';
import { MiningComponent } from './mining/mining.component';
import { LeaderboardComponent } from './leaderboard/leaderboard.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'clicker',
    pathMatch: 'full',
  },
  { path: 'clicker', component: ClickerComponent },
  { path: 'shop', component: ShopComponent },
  { path: 'mining', component: MiningComponent },
  { path: 'lead', component: LeaderboardComponent },
];
