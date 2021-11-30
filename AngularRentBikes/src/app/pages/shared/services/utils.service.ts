import { Injectable } from '@angular/core';
import { OrderBikesTable } from '../../home/order-bikes-table/order-bikes-table.interface';
import { Bike } from '../interfaces/bike.interface';
import { OrderBike } from '../interfaces/order-bike.interface';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class UtilsService {

  constructor() { }

  convertOrderBikesToTable(orderBikes: OrderBike[]): OrderBikesTable[] {
    let orderBikeTable: OrderBikesTable[] = [];

    let uniques: OrderBike[] = orderBikes.filter((thing, index, self) =>
                                      index === self.findIndex((t) => (
                                        t.id_Order === thing.id_Order
                                      ))
                                    );

    for(let i = 0; i < uniques.length; i++) {
      let newTable: OrderBikesTable = {
        id_Order: uniques[i].id_Order,
        initDate: moment(uniques[i].order.initDate).format('MM/DD/YYYY - HH:mm'),
        endDate: moment(uniques[i].order.endDate).format('MM/DD/YYYY - HH:mm'),
        discount: uniques[i].order.discount,
        total: uniques[i].order.total,
        totalWithDiscount: uniques[i].order.totalWithDiscount,
        id_RentalType: uniques[i].order.id_RentalType,
        listBikes: orderBikes.reduce((filtered: Bike[], option: any) => {
                                      if (option.id_Order === uniques[i].id_Order) {
                                        var newValue: Bike = { id: option.id_Bike, serialNumber: option.bike.serialNumber, isAvailable: option.bike.isAvailable }
                                        filtered.push(newValue);
                                      }
                                      return filtered;
                                    }, [])
      }
      
      orderBikeTable.push(newTable);
    }

    return orderBikeTable;
  }
}
