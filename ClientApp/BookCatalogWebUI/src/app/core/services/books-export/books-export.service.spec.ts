import { TestBed } from '@angular/core/testing';

import { BooksExportService } from './books-export.service';

describe('BooksExportService', () => {
  let service: BooksExportService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BooksExportService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
