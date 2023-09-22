import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Book } from '../../models/book';

@Injectable({
  providedIn: 'root'
})
export class FilteringService {

  private url = `https://localhost:5001/api/v1/Filtering`;

  constructor(private http: HttpClient) { }

  filterBooksByDateRange(startDate: string, endDate: string): Observable<Book[]> {
    return this.http.get<Book[]>(this.url + `/custom-date?startDate=${startDate}&endDate=${endDate}`);
  }

  filterBooksThisMonth(): Observable<Book[]> {
    return this.http.get<Book[]>(this.url + `/this-month`);
  }

  filterBooksThisYear(): Observable<Book[]> {
    return this.http.get<Book[]>(this.url + `/this-year`);
  }
}
