import { Component, Inject } from '@angular/core';
import { MAT_BOTTOM_SHEET_DATA, MatBottomSheetRef } from '@angular/material/bottom-sheet';

import { Book } from 'src/app/core/models/book';
import { BooksExportService } from 'src/app/core/services/books-export/books-export.service';

@Component({
  selector: 'app-book-export-bottom-sheet',
  templateUrl: './book-export-bottom-sheet.component.html',
  styleUrls: ['./book-export-bottom-sheet.component.css']
})
export class BookExportBottomSheetComponent {

  selectedBooks: Book[] = [];

  constructor(
    private bottomSheetRef: MatBottomSheetRef<BookExportBottomSheetComponent>,
    private bookExportService: BooksExportService,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: any
  ) { }

  exportToExcel(): void {
    const selectedBooks: any[] = this.data.books;

    this.bookExportService.exportToExcel(selectedBooks).subscribe((response) => {
      const blob = new Blob([response], { type: 'application/xlsx' });
      const url = window.URL.createObjectURL(blob);
      const anchor = document.createElement('a');
      anchor.href = url;
      anchor.download = 'books.xlsx';
      anchor.click();
      window.URL.revokeObjectURL(url);
      this.bottomSheetRef.dismiss();
    });
  }

  exportToPdf(): void {
    const selectedBooks: any[] = this.data.books;

    this.bookExportService.exportToPdf(selectedBooks).subscribe((response) => {
      const blob = new Blob([response], { type: 'application/pdf' });
      const url = window.URL.createObjectURL(blob);
      const anchor = document.createElement('a');
      anchor.href = url;
      anchor.download = 'books.pdf';
      anchor.click();
      window.URL.revokeObjectURL(url);
      this.bottomSheetRef.dismiss();
    });
  }
}
