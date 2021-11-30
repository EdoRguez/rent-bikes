import { Bike } from "../../shared/interfaces/bike.interface";

export interface OrderBikesTable {
    id_Order: string,
    initDate: string,
    endDate: string,
    discount: number,
    total: number,
    totalWithDiscount: number,
    id_RentalType: string,
    listBikes: Bike[]
}