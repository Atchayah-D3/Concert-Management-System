import { TestBed } from '@angular/core/testing';

import { AddConcertService } from './auto-refresh.service';

describe('AddConcertService', () => {
  let service: AddConcertService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddConcertService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
