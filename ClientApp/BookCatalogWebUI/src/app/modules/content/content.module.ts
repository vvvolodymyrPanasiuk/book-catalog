import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';

import { BooksComponent } from './books/books.component';
import { ContentRoutingModule } from './content-routing.module';
import { BookDialogComponent } from './book-dialog/book-dialog.component';
import { LocalStorageService } from 'src/app/core/services/storage/local-storage.service';


@NgModule({
  declarations: [
    BooksComponent,
    BookDialogComponent
  ],
  imports: [
    CommonModule,
    ContentRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatDividerModule,
    MatIconModule,
    MatDialogModule
  ],
  providers:
    [
      LocalStorageService
    ],
  exports: [
    BooksComponent,
    ContentRoutingModule
  ]
})
export class ContentModule { }
