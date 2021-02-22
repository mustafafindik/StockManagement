import { Component, Inject, Optional } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CustomerDetailModel } from 'src/app/models/Customer/CustomerDetailModel';
import { SupplierDetailModel } from 'src/app/models/Supplier/SupplierDetailModel';

@Component({
  selector: 'app-customer-dialog',
  templateUrl: './customer-dialog.component.html',
  styleUrls: ['./customer-dialog.component.css']
})
export class CustomerDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<CustomerDialogComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: CustomerDetailModel, private formBuilder: FormBuilder,) {
  
    this.local_data = {...data};
    this.action = this.local_data.action;
    this.createForm();
    this.dialogRef.disableClose = true;
  
    
  }

  action:string;
  local_data:any;
  customerAddForm: FormGroup;


  createForm() {
    this.customerAddForm = new FormGroup({
      customerName: new FormControl(this.local_data.customerName, [
        Validators.required,      
      ]),
      taxId: new FormControl(this.local_data.taxId, [
        
      ]),
      taxOffice: new FormControl(this.local_data.taxOffice, [

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
      if(this.customerAddForm.valid){
         this.dialogRef.close({event:this.action,data:this.local_data});
      }else{
       
        this.customerAddForm.get("customerName").markAsTouched({onlySelf:true}); 
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
