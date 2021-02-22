import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { MyDialogComponent } from 'src/app/extensions/dialog/Mydialog.component';
import { DataDialog } from 'src/app/models/DataDialog';
import { WarehouseListModel } from 'src/app/models/Warehouse/WarehouseListModel';
import { WarehouseService } from 'src/app/services/warehouse.service';
import { WarehouseDialogComponent } from './warehouse-dialog/warehouse-dialog.component';

@Component({
  selector: 'app-warehouses',
  templateUrl: './warehouses.component.html',
  styleUrls: ['./warehouses.component.css']
})
export class WarehousesComponent implements OnInit {

  dataSource = new MatTableDataSource<WarehouseListModel>();
  displayedColumns = ['select', 'id', 'warehouseName','address','city',"actions"];
  selection = new SelectionModel<WarehouseListModel>(true, []);


  @ViewChild(MatPaginator ) paginator: MatPaginator;
  @ViewChild(MatSort   ) sort: MatSort;
  
  constructor(private titleService: Title,private warehouseservice: WarehouseService,public dialog: MatDialog,private _snackBar: MatSnackBar) {}
  
  ngOnInit(): void {
    this.titleService.setTitle("Depolar");
    this.LoadData();
  }

  LoadData() {
    this.warehouseservice.getWarehouses().subscribe(data => {  
      this.dataSource = new MatTableDataSource<WarehouseListModel>(data);
      console.log(data);
      this.dataSource.paginator = this.paginator;    
      setTimeout(() => this.dataSource.sort = this.sort);   
      this.dataSource.filterPredicate = (data: WarehouseListModel, filterValue: string) => (
        data.warehouseName.toLocaleLowerCase().indexOf(filterValue.toLocaleLowerCase()) !== -1) 
          || (data.address.toLocaleLowerCase().indexOf(filterValue.toLocaleLowerCase()) !== -1) 
          || (data.city.toLocaleLowerCase().indexOf(filterValue.toLocaleLowerCase()) !== -1) 
          || (data.id.toString().toLocaleLowerCase().indexOf(filterValue.toLocaleLowerCase()) !== -1) ;
      this.selection.clear();
    });
  }
  

     /** Whether the number of selected elements matches the total number of rows. */
     isAllSelected() {
      const numSelected = this.selection.selected.length;
      const numRows = this.dataSource.data.length;
      return numSelected === numRows;
    }
  
    /** Selects all rows if they are not all selected; otherwise clear selection. */
   
    masterToggle() {
      this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));
    }
    
  
    applyFilter(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
     
      this.dataSource.filter = filterValue.trim().toLocaleLowerCase();
  
      if (this.dataSource.paginator) {
        this.dataSource.paginator.firstPage();
      }
    }


    actions(action,obj){
      if (action ==="Güncelle" || action ==="Detaylar"){
        this.warehouseservice.getWarehouseById(obj.id).subscribe(data => {
          console.log(data);
          this.openDialog(action,data);
        });

      } else {
          this.openDialog(action,obj);
      }  
    }


    openDialog(action,obj) {
      obj.action = action;  
      const dialogRef = this.dialog.open(WarehouseDialogComponent,  {             
        data:obj
      });
  
      dialogRef.afterClosed().subscribe(result => {
        if(result.event == 'Ekle'){
          console.log(result.data);

          this.warehouseservice.add(result.data).subscribe(data => {           
              console.log(data.status);
              console.log(data.body);  
              this._snackBar.open(data.body.warehouseName + " Başarıyla Eklendi.", "Tamam", {duration: 5000,});   
              this.LoadData();           
         }, error => {
             console.log(error.status);
             console.log(error.error);  
             this._snackBar.open("Hata : " +error.error, "Tamam", {duration: 8000,});  
         });
         
         
        }else if(result.event == 'Güncelle'){        
          console.log(result.data);
          this.warehouseservice.update(result.data).subscribe(data => {           
              console.log(data.status);
              console.log(data.body);  
              this._snackBar.open(data.body.warehouseName + " Başarıyla Düzenlendi.", "Tamam", {duration: 5000,});   
              this.LoadData();           
         }, error => {
             console.log(error.status);
             console.log(error.error);  
             this._snackBar.open("Hata : " +error.error, "Tamam", {duration: 8000,});  
         });

        }else if(result.event == 'Sil'){
          console.log(result.data);
          this.warehouseservice.delete(result.data).subscribe(data => {           
              console.log(data.status);
              console.log(data.body);  
              this._snackBar.open(data.body.warehouseName + " Başarıyla Silindi.", "Tamam", {duration: 5000,});   
              this.LoadData();           
         }, error => {
             console.log(error.status);
             console.log(error.error);  
             this._snackBar.open("Hata : " +error.error, "Tamam", {duration: 8000,});  
         });
        }else  if(result.event == 'Vazgeç'){
          this._snackBar.open("Vazgeçildi", "Tamam", {duration: 2000,});
        }
      });
    }
   

 

    
    deleteWarehouses(): void {
      const selectedIds:Number[] = [];
      const dialogRef = this.dialog.open(MyDialogComponent, {
        data: new DataDialog ( "Seçili Depoları Sil" , "Seçili Depolaro Silmek İstediğinizden Emin Misiniz ? ", "Kapat","Sil")
      });     
      dialogRef.afterClosed().subscribe(result => {
        
        if(result =="Yes" ){
          this.selection.selected.forEach(function (value) {
            selectedIds.push(value.id);
          }); 
          this.warehouseservice.deleteselected(selectedIds).subscribe(data => {           
            console.log(data.status); 
            this._snackBar.open("Seçilen Depolar Başarıyla Silindi.", "Tamam", {duration: 5000,});   
            this.LoadData();           
       }, error => {
           console.log(error.status);
           console.log(error.error);  
           this._snackBar.open("Hata : " +error.error, "Tamam", {duration: 8000,});  
       });
          //Silme Gönderme Servis ile Eğğer Ok gelirse
          this._snackBar.open("Silme İşlemi Tamamlandı.", "Tamam", {duration: 2000,});
        }else {
          this._snackBar.open("Silme İşleminden Vazgeçildi.", "Tamam", {duration: 2000,});
        }         
      }); 
    }


}
