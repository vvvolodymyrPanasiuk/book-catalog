import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookChartService {

  private baseUrl = 'https://localhost:5001/api/v1/BookChart';

  constructor(private http: HttpClient) { }

  // Метод для отримання кількості книг за роком публікації
  getBooksCountByPublicationYear(): Observable<{ [year: number]: number }> {
    return this.http.get<{ [year: number]: number }>(`${this.baseUrl}/books-count-by-year`);
  }
}
