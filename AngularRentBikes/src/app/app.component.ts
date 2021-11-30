import { Component } from '@angular/core';
import { MainLoaderService } from './pages/shared/services/main-loader.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  showLoading!: boolean;

  constructor(private mainLoaderService: MainLoaderService) {
    this.mainLoaderService.showLoader.subscribe(
      (res: boolean) => {
        this.showLoading = res;
      }
    );
  }

}
