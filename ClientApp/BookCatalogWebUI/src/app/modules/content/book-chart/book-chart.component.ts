import { Component, OnInit } from '@angular/core';
import { BookChartService } from 'src/app/core/services/book-chart/book-chart.service';

@Component({
  selector: 'app-book-chart',
  templateUrl: './book-chart.component.html',
  styleUrls: ['./book-chart.component.css']
})
export class BookChartComponent implements OnInit {
  public barChartOptions: any = {
    scaleShowVerticalLines: false,
    responsive: true
  };

  public barChartLabels: number[] = []; // Роки
  public barChartType = 'bar';
  public barChartLegend = true;

  public barChartData: any[] = [
    {
      data: [],
      label: 'Count of books per year',
      backgroundColor: 'rgb(64, 38, 233)'
    }];

  constructor(private bookChartService: BookChartService) { }

  ngOnInit() {
    this.loadData();
  }

  refreshData(): void {
    this.loadData();
  }

  private loadData(): void {
    this.bookChartService.getBooksCountByPublicationYear().subscribe(data => {
      this.barChartLabels = Object.keys(data).map(Number);
      this.barChartData[0].data = Object.values(data);

      const maxCount = Math.max(...Object.values(data));
      this.barChartOptions.scales = {
        y: {
          beginAtZero: true,
          max: maxCount + 5
        }
      };
    });
  }

}
