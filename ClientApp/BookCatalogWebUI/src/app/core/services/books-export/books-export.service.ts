import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BooksExportService {

  private baseUrl = 'https://localhost:5001/api/v1/BookExport';

  constructor(private http: HttpClient) { }

  exportToExcel(books: any[]): Observable<Blob> {
    return this.http.post<Blob>(`${this.baseUrl}/export-to-excel`, books, { responseType: 'blob' as 'json' });
  }

  exportToPdf(books: any[]): Observable<Blob> {
    return this.http.post<Blob>(`${this.baseUrl}/export-to-pdf`, books, { responseType: 'blob' as 'json' });
  }
}
