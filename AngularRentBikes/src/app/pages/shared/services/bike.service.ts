import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Bike } from '../interfaces/bike.interface';

@Injectable({
  providedIn: 'root'
})
export class BikeService {

  private baseUrl: string = `${environment.API_URL}/Bike`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Bike[]> {
    return this.http.get<Bike[]>(`${this.baseUrl}`);
  }
}
