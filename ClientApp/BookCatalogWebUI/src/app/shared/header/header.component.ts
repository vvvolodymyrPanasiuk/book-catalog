import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs';

import { Book } from 'src/app/core/models/book';
import { SearchService } from 'src/app/core/services/search.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  query?: string = "";
  private searchTerms = new Subject<string>();
  books$: Observable<Book[]> | undefined;
  //showBooksDropdown = false;
  booksList: Book[] = [];


  constructor(private searchService: SearchService) { }

  ngOnInit(): void {
    this.books$ = this.searchTerms.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((event: string) => {
        if (event.trim() === '') {
          // Повернення порожнього списку, якщо поле пошуку порожнє
          return [];
        } else {
          console.log(this.searchService.searchBooks(event));
          return this.searchService.searchBooks(event);
        }
      })
    );
  }

  search(event: Event): void {
    console.log((event.target as HTMLInputElement).value);
    this.query = (event.target as HTMLInputElement).value;
    //this.showBooksDropdown = this.query.length > 0;
    this.searchTerms.next(this.query);
  }

  selectBook(book: Book): void {
    // Виконайте дії, коли обраний певний елемент
    console.log('Selected Book:', book);
    this.query = book.title; // Встановіть вибраний текст у полі пошуку
    this.booksList = []; // Очистіть список книжок

    //this.showBooksDropdown = false; // Сховайте випадаючий список
  }
}
