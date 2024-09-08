import { TestBed } from '@angular/core/testing';

import { SkinService } from './skin.service';

describe('StoneService', () => {
  let service: SkinService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SkinService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
