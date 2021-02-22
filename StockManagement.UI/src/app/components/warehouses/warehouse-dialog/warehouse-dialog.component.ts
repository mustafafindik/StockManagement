import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CityDetailModel } from 'src/app/models/City/CityDetailModel';
import { CityListModel } from 'src/app/models/City/CityListModel';
import { WarehouseListModel } from 'src/app/models/Warehouse/WarehouseListModel';
import { CityService } from 'src/app/services/city.service';

@Component({
  selector: 'app-warehouse-dialog',
  templateUrl: './warehouse-dialog.component.html',
  styleUrls: ['./warehouse-dialog.component.css']
})
export class WarehouseDialogComponent  {

  action:string;
  local_data:any;
  warehouseAddForm: FormGroup;
  citySelectList : CityListModel[];
  selectedOption = '1';
  
  constructor(
    public dialogRef: MatDialogRef<WarehouseDialogComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: WarehouseListModel,private cityservice:CityService, private formBuilder: FormBuilder,) {
    this.local_data = {...data};
    console.log(this.local_data)
    this.action = this.local_data.action;
    if(this.action == "Ekle" || this.action =="Güncelle"){
      this.cityservice.getCities().subscribe(data=>{
        console.log(data)
        this.citySelectList = data;   
      });
    }
    this.createForm();
    this.dialogRef.disableClose = true;
    this.warehouseAddForm.controls['city'].setValue(this.local_data.cityId)

    console.log(this.warehouseAddForm.get('address').touched)
  }


  createForm() {
    this.warehouseAddForm = new FormGroup({
      warehouseName: new FormControl(this.local_data.warehoseName, [
        Validators.required,      
      ]),
      address: new FormControl(this.local_data.address, [
        Validators.minLength(10), 
        Validators.required,
        Validators.maxLength(100)     
      ]),
      city: new FormControl(this.local_data.city, [
        Validators.required,  
      ]),
    });

  }

  doAction(){
  if(this.action === "Ekle" || this.action==="Güncelle"){
    if(this.warehouseAddForm.valid){
      delete  this.local_data["city"]
      this.dialogRef.close({event:this.action,data:this.local_data});
    }else{
     
      this.warehouseAddForm.get("address").markAsTouched({onlySelf:true});
      this.warehouseAddForm.get("warehouseName").markAsTouched({onlySelf:true});
      this.warehouseAddForm.get("city").markAsTouched({onlySelf:true});

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


