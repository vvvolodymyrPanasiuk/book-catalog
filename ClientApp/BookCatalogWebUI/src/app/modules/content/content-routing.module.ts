import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BooksComponent } from './books/books.component';
import { BookChartComponent } from './book-chart/book-chart.component';

const routes: Routes = [
  { path: '', component: BooksComponent },
  { path: 'chart', component: BookChartComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContentRoutingModule { }
