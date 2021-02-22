import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyDialogComponent } from './Mydialog.component';
import {MatDialogModule} from '@angular/material/dialog';

@NgModule({
  imports: [
    CommonModule,MatDialogModule
  ],
  declarations: [MyDialogComponent]
})
export class MyDialogModule { }
