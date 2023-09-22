import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

import { Book } from 'src/app/core/models/book';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent {

  public books?: Book[];

  constructor(http: HttpClient) {
    http.get<Book[]>('https://localhost:5001/api/v1/books').subscribe(result => {
      this.books = result;
      console.log(this.books);
    }, error => console.error(error));
  }
}
