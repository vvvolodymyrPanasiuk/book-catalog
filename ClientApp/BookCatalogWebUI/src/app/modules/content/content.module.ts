import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { BooksComponent } from './books/books.component';
import { ContentRoutingModule } from './content-routing.module';


@NgModule({
  declarations: [
    BooksComponent
  ],
  imports: [
    CommonModule,
    ContentRoutingModule,
    RouterModule
  ],
  providers: [],
  exports: [
    BooksComponent,
    ContentRoutingModule
  ]
})
export class ContentModule { }
