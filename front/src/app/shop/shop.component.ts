import { Component, OnInit } from '@angular/core';
import { SkinService } from '../skin.service';
import { NgClass, NgIf } from '@angular/common';
import { Skin } from '../http-service.service';
import { combineLatest } from 'rxjs';
import { ShopService } from '../shop.service';
import { ClickCounterService } from '../click-counter.service';

export interface Stone extends Skin {
  isPurchased: boolean;
  isApplied: boolean;
  noMoney: boolean;
}

@Component({
  selector: 'app-shop',
  standalone: true,
  imports: [NgClass, NgIf],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss',
})
export class ShopComponent implements OnInit {
  skins: Skin[] = [];
  selectedSkin: Stone | undefined;
  index: number = 0;
  private userSkins: Skin[] = [];
  private currentSkin: Skin | undefined;
  money: number | undefined;

  constructor(
    private skinService: SkinService,
    private shopService: ShopService,
    private clickService: ClickCounterService
  ) {}

  ngOnInit() {
    const skins$ = this.skinService.getSkins();
    const userSkins$ = this.skinService.getUserSkins();
    const currentSkin$ = this.skinService.getCurrentSkin();

    combineLatest([skins$, userSkins$, currentSkin$]).subscribe(
      ([s, us, cs]) => {
        this.skins = s;
        this.userSkins = us;
        this.currentSkin = cs;
        this.fillCurrentStone();
      }
    );
    this.clickService.clickCountSubscription().subscribe(r => {
      this.money = r?.currentScore;
    })
  }

  clickRight() {
    if (this.index + 1 == this.skins.length) {
      this.index = 0;
    } else {
      this.index++;
    }
    this.fillCurrentStone();
  }

  clickLeft() {
    if (this.index - 1 < 0) {
      this.index = this.skins.length - 1;
    } else {
      this.index--;
    }
    this.fillCurrentStone();
  }

  clickBuy(skinId: number) {
    if(this.selectedSkin?.isPurchased) {
      return;
    }

    this.shopService.buySkin(skinId).subscribe(() => {
      this.skinService.getUserSkins().subscribe((r) => {
        this.userSkins = r;
        this.fillCurrentStone();
        this.clickService.actualScore();
      });
    });
  }

  clickApply(skinId: number) {
    if(this.selectedSkin?.isApplied) {
      return;
    }

    this.skinService.applySkin(skinId).subscribe(() => {
      this.skinService.getCurrentSkin().subscribe(r => {
        this.currentSkin = r;
        this.fillCurrentStone();
      })
    })
  }

  private fillCurrentStone() {
    const currentSkin = this.skins[this.index];

    const isPurchased = !!this.userSkins.filter(
      (s) => s.id === currentSkin.id
    )[0];

    const isApplied = this.currentSkin?.id === currentSkin.id;

    this.selectedSkin = {
      ...currentSkin,
      isPurchased: isPurchased,
      isApplied: isApplied,
      noMoney: currentSkin.price > (this.money ?? 0)
    };
  }
}
