import { Inject, Optional } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UnitListModel } from 'src/app/models/Unit/UnitListModel';

@Component({
  selector: 'app-units-dialog',
  templateUrl: './units-dialog.component.html',
  styleUrls: ['./units-dialog.component.css']
})
export class UnitsDialogComponent  {

  constructor(
    public dialogRef: MatDialogRef<UnitsDialogComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: UnitListModel, private formBuilder: FormBuilder,) {
  
    this.local_data = {...data};
    this.action = this.local_data.action;
    this.createForm();
    this.dialogRef.disableClose = true;
  
    
  }

  action:string;
  local_data:any;
  unitAddForm: FormGroup;


  createForm() {
    this.unitAddForm = new FormGroup({
      unitName: new FormControl(this.local_data.unitName, [
        Validators.required,      
      ])
    });

  }

  doAction(){
    if(this.unitAddForm.valid){
    this.dialogRef.close({event:this.action,data:this.local_data});
    }else{
      console.log("Not Valid")
    }
  }

  closeDialog(){
    this.dialogRef.close({event:'Vazgeç'});
  }

}
