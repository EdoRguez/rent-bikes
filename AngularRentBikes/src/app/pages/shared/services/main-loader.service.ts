import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MainLoaderService {

  showLoader: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor() { }

  startLoading(): void {
    this.showLoader.next(true);
  }

  endLoading(): void {
    this.showLoader.next(false);
  }
}
