import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SupplierDetailModel } from 'src/app/models/Supplier/SupplierDetailModel';
import { SupplierListModel } from 'src/app/models/Supplier/SupplierListModel';

@Component({
  selector: 'app-supplier-dialog',
  templateUrl: './supplier-dialog.component.html',
  styleUrls: ['./supplier-dialog.component.css']
})
export class SupplierDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<SupplierDialogComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: SupplierDetailModel, private formBuilder: FormBuilder,) {
  
    this.local_data = {...data};
    this.action = this.local_data.action;
    this.createForm();
    this.dialogRef.disableClose = true;
  
    
  }

  action:string;
  local_data:any;
  supplierAddForm: FormGroup;


  createForm() {
    this.supplierAddForm = new FormGroup({
      supplierName: new FormControl(this.local_data.supplierName, [
        Validators.required,      
      ]),
      taxId: new FormControl(this.local_data.taxId, [
        Validators.required, 
        Validators.minLength(10)     
      ]),
      taxOffice: new FormControl(this.local_data.taxOffice, [
        Validators.required,         
      ]),
      address: new FormControl(this.local_data.address, [
          
      ]),
      phoneNumber: new FormControl(this.local_data.phoneNumber, [
          
      ]),
      email: new FormControl(this.local_data.email, [
          
      ]),
    });

  }

  doAction(){
    if(this.action === "Ekle" || this.action==="Güncelle"){
      if(this.supplierAddForm.valid){
         this.dialogRef.close({event:this.action,data:this.local_data});
      }else{
       
        this.supplierAddForm.get("supplierName").markAsTouched({onlySelf:true});
        this.supplierAddForm.get("taxId").markAsTouched({onlySelf:true});
        this.supplierAddForm.get("taxOffice").markAsTouched({onlySelf:true});
  
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
