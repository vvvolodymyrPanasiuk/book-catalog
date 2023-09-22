import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Book } from '../../models/book';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(private http: HttpClient) { }

  searchBooks(query: string): Observable<Book[]> {
    return this.http.get<Book[]>(`https://localhost:5001/api/v1/Search/title?query=${query}`);
  }
}
