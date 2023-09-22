import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { debounceTime, switchMap } from 'rxjs';

import { Book } from 'src/app/core/models/book';
import { SearchService } from 'src/app/core/services/search/search.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  public books?: Book[];
  private searchTerms = new Subject<string>();

  constructor(private http: HttpClient, private searchService: SearchService) {
    http.get<Book[]>('https://localhost:5001/api/v1/books').subscribe(result => {
      this.books = result;
      console.log(this.books);
    }, error => console.error(error));
  }

  ngOnInit(): void {
    this.searchTerms.pipe(
      debounceTime(300),
      switchMap((term: string) => {
        if (term.trim() === '') {
          return this.http.get<Book[]>('https://localhost:5001/api/v1/books');
        } else {
          return this.searchService.searchBooks(term);
        }
      })
    ).subscribe((result: Book[]) => {
      this.books = result;
    }, error => console.error(error));
  }

  search(event: Event): void {
    const term = (event.target as HTMLInputElement).value;
    this.searchTerms.next(term);
  }
}
