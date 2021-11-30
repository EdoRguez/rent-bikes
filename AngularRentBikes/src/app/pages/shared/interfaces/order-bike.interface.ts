import { Order } from "./order.interface";

export interface OrderBike {
    listIdBikes: string[],
    id_Order: string,
    order: Order,
    id_RentalType: string,
    rentTime: number
}