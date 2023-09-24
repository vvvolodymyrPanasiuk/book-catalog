import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookExportBottomSheetComponent } from './book-export-bottom-sheet.component';

describe('BookExportBottomSheetComponent', () => {
  let component: BookExportBottomSheetComponent;
  let fixture: ComponentFixture<BookExportBottomSheetComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BookExportBottomSheetComponent]
    });
    fixture = TestBed.createComponent(BookExportBottomSheetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
