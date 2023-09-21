import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public books?: Book[];

  constructor(http: HttpClient) {
    http.get<Book[]>('https://localhost:5001/api/v1/books').subscribe(result => {
      this.books = result;
    }, error => console.error(error));
  }

  title = 'BookCatalogWebUI';
}

interface Book {
  id: string;
  title: string;
  publicationDate: string;
  description: string;
  pageCount: number;
}
