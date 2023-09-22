import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Book } from '../../models/book';

@Injectable({
  providedIn: 'root'
})
export class SortingService {

  private apiUrl = 'https://localhost:5001/api/v1/Sorting';

  constructor(private http: HttpClient) { }

  sortBooks(field: string, ascending: boolean): Observable<Book[]> {
    const params = new HttpParams()
      .set('field', field)
      .set('ascending', ascending.toString());

    return this.http.get<Book[]>(`${this.apiUrl}`, { params });
  }
}
