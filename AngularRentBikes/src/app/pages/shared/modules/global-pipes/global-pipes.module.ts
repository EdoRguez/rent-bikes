import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PadLeftPipe } from '../../pipes/pad-left.pipe';

@NgModule({
  declarations: [
    PadLeftPipe
  ],
  exports: [
    PadLeftPipe
  ]
})
export class GlobalPipesModule { }
