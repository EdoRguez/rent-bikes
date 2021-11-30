import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { OrderBike } from '../interfaces/order-bike.interface';

@Injectable({
  providedIn: 'root'
})
export class OrderBikeService {

  private baseUrl: string = `${environment.API_URL}/OrderBike`;

  constructor(private http: HttpClient) { }

  create(orderBike: OrderBike): Observable<OrderBike[]> {
    return this.http.post<OrderBike[]>(`${this.baseUrl}`, orderBike);
  }

  getAll(): Observable<OrderBike[]> {
    return this.http.get<OrderBike[]>(`${this.baseUrl}`);
  }
}
