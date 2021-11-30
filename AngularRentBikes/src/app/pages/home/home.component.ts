import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { catchError, forkJoin, of } from 'rxjs';
import { Bike } from '../shared/interfaces/bike.interface';
import { OrderBike } from '../shared/interfaces/order-bike.interface';
import { RentalType } from '../shared/interfaces/rental-type.interface';
import { BikeService } from '../shared/services/bike.service';
import { MainLoaderService } from '../shared/services/main-loader.service';
import { OrderBikeService } from '../shared/services/order-bike.service';
import { RentalTypeService } from '../shared/services/rental-type.service';
import { UtilsService } from '../shared/services/utils.service';
import { OrderBikesDialogComponent } from './order-bikes-dialog/order-bikes-dialog.component';
import { OrderBikesTable } from './order-bikes-table/order-bikes-table.interface';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  bikes: Bike[] = [];
  rentalTypes: RentalType[] = [];
  orderBikesTable: OrderBikesTable[] = [];

  isPageLoading: boolean = true;

  constructor(private bikeService: BikeService,
              private rentalTypeService: RentalTypeService,
              private orderBikeService: OrderBikeService,
              private utilsService: UtilsService,
              private mainLoaderService: MainLoaderService,
              public dialog: MatDialog) { }

  ngOnInit(): void {
    forkJoin([
      this.bikeService.getAll().pipe(
        catchError((err) => {
          return of({error: err});
        })
      ),
      this.rentalTypeService.getAll().pipe(
        catchError((err) => {
          return of({error: err});
        })
      ),
      this.orderBikeService.getAll().pipe(
        catchError((err) => {
          return of({error: err});
        })
      )
    ]).subscribe(
      (res: any[]) => {
        this.bikes = res[0];
        this.rentalTypes = res[1].sort((n1: RentalType, n2: RentalType)=> n1.price > n2.price);
        this.orderBikesTable = this.utilsService.convertOrderBikesToTable(res[2]);        

        this.isPageLoading = false;
      }
    );
  }
  
  onRentBike(): void {
    this.openDialog();
  }

  private openDialog(orderBike?: OrderBike): void {
    const dialogRef = this.dialog.open(OrderBikesDialogComponent, {
      width: '450px',
      autoFocus: false,
      data: { 
        orderBike: orderBike,
        listBikes: this.bikes.filter(x => x.isAvailable),
        listRentalTypes: this.rentalTypes
      }
    });

    dialogRef.afterClosed().subscribe((result) => {
      if(result) {
        this.orderBikeService.create(result).subscribe(
          (res: OrderBike[]) => {
            let filteredArray = this.bikes.filter((x: Bike) => result.listIdBikes.includes(x.id));
            filteredArray.forEach(x => x.isAvailable = false);
            
            let newOrderBikesTable = this.utilsService.convertOrderBikesToTable(res);
            this.orderBikesTable = this.orderBikesTable.concat(newOrderBikesTable);    
            
            this.mainLoaderService.endLoading();
          },
          err => {
            console.log('Error');
            console.log(err);

            this.mainLoaderService.endLoading();
          }
        );
      }
    });
  }

}
