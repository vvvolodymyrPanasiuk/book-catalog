import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { debounceTime, switchMap } from 'rxjs';


import { Book } from 'src/app/core/models/book';
import { FilteringService } from 'src/app/core/services/filtering/filtering.service';
import { SearchService } from 'src/app/core/services/search/search.service';
import { SortingService } from 'src/app/core/services/sorting/sorting.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  public books?: Book[];
  private searchTerms = new Subject<string>();
  public selectedSortOption: any = 7; // Store the selected sorting (default = NO SORT)
  public selectedDateRange: string = ''; // Store the selected date range

  customStartDate: string = '';
  customEndDate: string = '';


  constructor(
    private http: HttpClient,
    private searchService: SearchService,
    private sortingService: SortingService,
    private filteringService: FilteringService
  ) {
    http.get<Book[]>('https://localhost:5001/api/v1/books').subscribe(result => {
      this.books = result;
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

  sort(): void {
    const sortOptions: { [id: number]: RequestParam } = {
      1: { field: 'title', ascending: true },
      2: { field: 'title', ascending: false },
      3: { field: 'publicationdate', ascending: true },
      4: { field: 'publicationdate', ascending: false },
      5: { field: 'pagecount', ascending: true },
      6: { field: 'pagecount', ascending: false },
      7: { field: '', ascending: true } //
    };

    const selectedOption = sortOptions[this.selectedSortOption];

    if (selectedOption && this.selectedSortOption != 7) {
      this.sortingService
        .sortBooks(selectedOption.field, selectedOption.ascending)
        .subscribe(
          (result: Book[]) => {
            this.books = result;
          },
          (error) => console.error(error)
        );
    } else {
      this.http.get<Book[]>('https://localhost:5001/api/v1/books').subscribe(result => {
        this.books = result;
      }, error => console.error(error));
    }
  }

  selectDateRange(range: string): void {
    this.selectedDateRange = range;

    switch (range) {
      case 'custom':
        this.applyCustomDateFilter();
        break;
      case 'thisMonth':
        this.filterBooksThisMonth();
        break;
      case 'thisYear':
        this.filterBooksThisYear();
        break;
      default:
        this.http.get<Book[]>('https://localhost:5001/api/v1/books').subscribe(result => {
          this.books = result;
        }, error => console.error(error));
        break;
    }
  }

  private filterBooksThisMonth(): void {
    this.filteringService.filterBooksThisMonth().subscribe(
      (result: Book[]) => {
        this.books = result;
      },
      (error) => console.error(error)
    );
  }

  private filterBooksThisYear(): void {
    this.filteringService.filterBooksThisYear().subscribe(
      (result: Book[]) => {
        this.books = result;
      },
      (error) => console.error(error)
    );
  }


  dateRangeChange(dateRangeStart: HTMLInputElement, dateRangeEnd: HTMLInputElement) {

    const startDateParts = dateRangeStart.value.split('/');
    const endDateParts = dateRangeEnd.value.split('/');

    if (startDateParts.length === 3 && endDateParts.length === 3) {
      const formattedStartDate = `${startDateParts[0]}.${startDateParts[1]}.${startDateParts[2]}`;
      const formattedEndDate = `${endDateParts[0]}.${endDateParts[1]}.${endDateParts[2]}`;

      this.customStartDate = formattedStartDate;
      this.customEndDate = formattedEndDate;

    } else {
      console.error('Invalid date format');
    }
  }


  applyCustomDateFilter(): void {
    if (this.customStartDate && this.customEndDate) {
      this.filteringService
        .filterBooksByDateRange(this.customStartDate, this.customEndDate)
        .subscribe(
          (result: Book[]) => {
            this.books = result;
          },
          (error) => console.error(error)
        );
    }
  }
}

interface RequestParam {
  field: string;
  ascending: boolean;
}
