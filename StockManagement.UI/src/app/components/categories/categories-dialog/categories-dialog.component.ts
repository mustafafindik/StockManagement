import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-categories-dialog',
  templateUrl: './categories-dialog.component.html',
  styleUrls: ['./categories-dialog.component.scss']
})
export class CategoriesDialogComponent  {

  constructor(
    public dialogRef: MatDialogRef<CategoriesDialogComponent>,  @Inject(MAT_DIALOG_DATA) public data: any, private formBuilder: FormBuilder) {
  
    this.local_data = {...data};
    this.action = this.local_data.action;
    this.dialogRef.disableClose = true;
    if(this.action==="Alt Kategori Ekle"){
      this.local_data.categoryName=null;
    }
    
  }

  action:string;
  local_data:any;
  

  doAction(){
  
    this.dialogRef.close({event:this.action,data:this.local_data});
   
  }

  closeDialog(){
    this.dialogRef.close({event:'Vazgeç'});
  }

}
