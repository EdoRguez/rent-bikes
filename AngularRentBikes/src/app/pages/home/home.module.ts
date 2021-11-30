import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { BikesComponent } from './bikes/bikes.component';
import { OrderBikesTableComponent } from './order-bikes-table/order-bikes-table.component';
import { MaterialModule } from '../shared/modules/material/material.module';
import { OrderBikesDialogComponent } from './order-bikes-dialog/order-bikes-dialog.component';
import { LoaderModule } from '../shared/components/loader/loader.module';
import { GlobalPipesModule } from '../shared/modules/global-pipes/global-pipes.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    HomeComponent,
    BikesComponent,
    OrderBikesTableComponent,
    OrderBikesDialogComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MaterialModule,
    LoaderModule,
    GlobalPipesModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class HomeModule { }
