import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MiningComponent } from './mining.component';
import { NgFor, NgForOf, NgIf, NgSwitch, NgSwitchCase } from '@angular/common';

describe('MiningComponent', () => {
  let component: MiningComponent;
  let fixture: ComponentFixture<MiningComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MiningComponent, NgFor, NgForOf, NgSwitch, NgSwitchCase]
    })
      .compileComponents();

    fixture = TestBed.createComponent(MiningComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
