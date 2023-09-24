import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgChartsModule } from 'ng2-charts';

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
import { MatSelectModule } from '@angular/material/select';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatListModule } from '@angular/material/list';
import { MatSortModule } from '@angular/material/sort';

import { BooksComponent } from './books/books.component';
import { ContentRoutingModule } from './content-routing.module';
import { BookDialogComponent } from './book-dialog/book-dialog.component';
import { LocalStorageService } from 'src/app/core/services/storage/local-storage.service';
import { BookChartComponent } from './book-chart/book-chart.component';
import { BookExportBottomSheetComponent } from './book-export-bottom-sheet/book-export-bottom-sheet.component';


@NgModule({
  declarations: [
    BooksComponent,
    BookDialogComponent,
    BookChartComponent,
    BookExportBottomSheetComponent
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
    MatSortModule,
    MatNativeDateModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatListModule,
    MatBottomSheetModule,
    MatDividerModule,
    MatIconModule,
    MatSelectModule,
    MatDialogModule,
    NgChartsModule
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
