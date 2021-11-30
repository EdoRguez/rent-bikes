import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MainLoaderService } from '../../shared/services/main-loader.service';

@Component({
  selector: 'app-order-bikes-dialog',
  templateUrl: './order-bikes-dialog.component.html',
  styleUrls: ['./order-bikes-dialog.component.scss']
})
export class OrderBikesDialogComponent implements OnInit {

  form: FormGroup =  new FormGroup({
    id: new FormControl(null),
    listIdBikes: new FormControl(null, [Validators.required, this.validateSelectedBikesLength]),
    id_RentalType: new FormControl(null, [Validators.required]),
    rentTime: new FormControl(null, [Validators.required])
  });

  orderResult: any;

  constructor(public dialogRef: MatDialogRef<OrderBikesDialogComponent>,
              private mainLoaderService: MainLoaderService,
              @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.form.statusChanges.subscribe(
        (result) => {
          if(this.form.valid) {
            this.orderResult = {};
            this.orderResult.total = this.calculateTotal();
            this.orderResult.discount = this.calculateDiscount(this.orderResult!.total, 30);
            this.orderResult.totalWithDiscount = this.orderResult!.total - this.orderResult!.discount;
          } else {
            this.orderResult = null;
          }
        }
    );
  }

  onSaveForm(): void {
    if(this.form.valid) {
      this.mainLoaderService.startLoading();
      this.dialogRef.close(this.form.value);
    }
  }

  onCancelForm(): void {
    this.dialogRef.close();
  }

  private calculateTotal(): number {
    this.orderResult.rentalTypePrice = this.data.listRentalTypes.find( (x: any) => x.id === this.form.controls['id_RentalType'].value).price;
    this.orderResult.totalBikes = this.form.controls['listIdBikes'].value.length;
    this.orderResult.rentTime = this.form.controls['rentTime'].value;

    return this.orderResult.rentalTypePrice * this.orderResult.totalBikes * this.orderResult.rentTime;
  }

  private calculateDiscount(total: number, discountPercentage: number): number {
    return (total * discountPercentage) / 100;
  }

  private validateSelectedBikesLength(control: AbstractControl): any | null {
    if (control.value && control.value.length > 5) {
      return { invalidBikesSelected: true };
    }

    return null;
  }

}
