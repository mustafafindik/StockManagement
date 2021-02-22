import { Inject } from '@angular/core';
import { Optional } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { VatRateListModel } from 'src/app/models/VatRate/VatRateListModel';

@Component({
  selector: 'app-vatrate-dialog',
  templateUrl: './vatrate-dialog.component.html',
  styleUrls: ['./vatrate-dialog.component.css']
})
export class VatrateDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<VatRateListModel>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: VatRateListModel, private formBuilder: FormBuilder,) {
  
    this.local_data = {...data};
    this.action = this.local_data.action;
    this.createForm();
    this.dialogRef.disableClose = true;
  
    
  }

  action:string;
  local_data:any;
  vatRateAddForm: FormGroup;


  createForm() {
    this.vatRateAddForm = new FormGroup({
      vatRateName: new FormControl(this.local_data.vatRateName, [
        Validators.required,      
      ]),
      vatRateValue: new FormControl(this.local_data.vatRateValue, [
        Validators.required,  
        Validators.max(1),
        Validators.min(0),
      ])
    });

  }

  doAction(){
    if(this.action === "Ekle" || this.action==="Güncelle"){
      if(this.vatRateAddForm.valid){
         this.dialogRef.close({event:this.action,data:this.local_data});
      }else{
       
        this.vatRateAddForm.get("vatRateName").markAsTouched({onlySelf:true});
        this.vatRateAddForm.get("vatRateValue").markAsTouched({onlySelf:true});  
        console.log("Not Valid")
      }
    }else{
      this.dialogRef.close({event:this.action,data:this.local_data});
    }
      
    }
  
    closeDialog(){
      this.dialogRef.close({event:'Vazgeç'});
    }

}
