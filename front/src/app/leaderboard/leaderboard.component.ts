import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

export interface Leader {
  position: number;
  name: string;
  points: number;
}

@Component({
  selector: 'app-leaderboard',
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule, MatSortModule],
  templateUrl: './leaderboard.component.html',
  styleUrl: './leaderboard.component.scss',
})
export class LeaderboardComponent implements OnInit {
  displayedColumns: string[] = ['position', 'name', 'points'];
  dataSource = new MatTableDataSource<Leader>(ELEMENT_DATA);

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator | null = null;
  @ViewChild(MatSort, { static: false }) sort: MatSort | null = null;

  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}

const ELEMENT_DATA: Leader[] = [
  { position: 1, name: 'Alice', points: 1200 },
  { position: 2, name: 'Bob', points: 1100 },
  { position: 3, name: 'Charlie', points: 1000 },
  // Добавь больше данных по необходимости
];
