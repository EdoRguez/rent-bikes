import { AfterContentChecked, AfterViewInit, Component, Input, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Bike } from '../../shared/interfaces/bike.interface';
import { OrderBikesTable } from './order-bikes-table.interface';

@Component({
  selector: 'app-order-bikes-table',
  templateUrl: './order-bikes-table.component.html',
  styleUrls: ['./order-bikes-table.component.scss']
})
export class OrderBikesTableComponent implements OnInit, AfterViewInit, OnChanges  {

  @Input() listOrderBikes: OrderBikesTable[] = [];

  displayedColumns: string[] = ['initDate', 'endDate', 'discount', 'total', 'totalWithDiscount', 'id_RentalType', 'listBikes'];
  dataSource!: MatTableDataSource<OrderBikesTable>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor() { }
  
  ngOnInit(): void { 
    this.dataSource = new MatTableDataSource(this.listOrderBikes);
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.updateTableData(changes['listOrderBikes'].currentValue);
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(value: string): void {
    const filterValue = value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  private updateTableData(orderBikesTable: OrderBikesTable[]): void {
    this.dataSource = new MatTableDataSource(orderBikesTable);
    this.refreshTable();
  }

  private refreshTable(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}