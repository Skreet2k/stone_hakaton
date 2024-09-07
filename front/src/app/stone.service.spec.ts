import { TestBed } from '@angular/core/testing';

import { StoneService } from './stone.service';

describe('StoneService', () => {
  let service: StoneService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StoneService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
