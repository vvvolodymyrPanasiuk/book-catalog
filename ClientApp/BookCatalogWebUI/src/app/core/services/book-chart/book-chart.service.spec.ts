import { TestBed } from '@angular/core/testing';

import { BookChartService } from './book-chart.service';

describe('BookChartService', () => {
  let service: BookChartService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookChartService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
