import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RentalType } from '../interfaces/rental-type.interface';

@Injectable({
  providedIn: 'root'
})
export class RentalTypeService {

  private baseUrl: string = `${environment.API_URL}/RentalType`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<RentalType[]> {
    return this.http.get<RentalType[]>(`${this.baseUrl}`);
  }
}
