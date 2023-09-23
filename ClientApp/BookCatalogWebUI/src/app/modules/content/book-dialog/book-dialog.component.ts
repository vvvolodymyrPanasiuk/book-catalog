import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription } from 'rxjs';

import { Book } from 'src/app/core/models/book';
import { BookRequest } from 'src/app/core/models/bookRequest';
import { BooksService } from 'src/app/core/services/books/books.service';
import { LocalStorageService } from 'src/app/core/services/storage/local-storage.service';

@Component({
  selector: 'app-book-dialog',
  templateUrl: './book-dialog.component.html',
  styleUrls: ['./book-dialog.component.css']
})
export class BookDialogComponent {
  bookForm: FormGroup;
  dialogTitle: string;
  private localStorageKey = 'bookDialogFormData';
  private localStorageSubscription: Subscription;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<BookDialogComponent>,
    private bookService: BooksService,
    private localStorageService: LocalStorageService,
    @Inject(MAT_DIALOG_DATA) private data: { book: Book, isEdit: boolean }) {
    this.dialogTitle = data.isEdit ? 'Edit book' : 'Add a new';

    this.bookForm = this.fb.group({
      id: [data.book ? data.book.id : null],
      title: [data.book ? data.book.title : '', Validators.required],
      publicationDate: [data.book ? data.book.publicationDate : '', Validators.required],
      description: [data.book ? data.book.description : '', Validators.required],
      pageCount: [data.book ? data.book.pageCount : '', Validators.required]
    });

    this.localStorageSubscription = this.bookForm.valueChanges.subscribe(formData => {
      this.localStorageService.saveFormData(this.localStorageKey, formData);
    });
  }

  ngOnInit(): void {
    const formData = this.localStorageService.getFormData(this.localStorageKey);
    if (formData) {
      this.bookForm.patchValue(formData);
    }
  }

  ngOnDestroy(): void {
    this.localStorageSubscription.unsubscribe();
    this.localStorageService.clearFormData(this.localStorageKey);
    this.dialogRef.close();
  }

  saveBook() {
    if (this.bookForm.valid) {
      const formData = this.bookForm.value;

      const bookRequest: BookRequest = {
        title: formData.title,
        publicationDate: formData.publicationDate,
        description: formData.description,
        pageCount: formData.pageCount
      };

      if (this.data.isEdit && this.data.book.id != null) {
        this.bookService.updateBook(this.data.book.id, bookRequest).subscribe(
          updatedBook => {
            this.dialogRef.close(updatedBook);
          },
          error => {
            console.error(error);
          }
        );
      } else {
        this.bookService.addBook(bookRequest).subscribe(
          newBook => {
            this.dialogRef.close(newBook);
          },
          error => {
            console.error(error);
          }
        );
      }
    }
  }

  cancel() {
    this.localStorageSubscription.unsubscribe();
    this.localStorageService.clearFormData(this.localStorageKey);
    this.dialogRef.close();
  }
}
