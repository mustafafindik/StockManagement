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
import { UnitListModel } from 'src/app/models/Unit/UnitListModel';
import { UnitService } from 'src/app/services/unit.service';
import { CitiesDialogComponent } from '../cities/cities-dialog/cities-dialog.component';
import { UnitsDialogComponent } from './units-dialog/units-dialog.component';

@Component({
  selector: 'app-unit',
  templateUrl: './unit.component.html',
  styleUrls: ['./unit.component.scss']
})
export class UnitComponent implements OnInit {

  dataSource = new MatTableDataSource<UnitListModel>();
  displayedColumns = ['select', 'id', 'unitName',"actions"];
  selection = new SelectionModel<UnitListModel>(true, []);


  @ViewChild(MatPaginator ) paginator: MatPaginator;
  @ViewChild(MatSort   ) sort: MatSort;
  
  constructor(private titleService: Title,private unitService: UnitService,public dialog: MatDialog,private _snackBar: MatSnackBar) {}
  
  ngOnInit(): void {
    this.titleService.setTitle("Birimler");
    this.LoadData();
  }

  LoadData() {
    this.unitService.getUnits().subscribe(data => {  
      this.dataSource = new MatTableDataSource<UnitListModel>(data);
      console.log(data);
      this.dataSource.paginator = this.paginator;    
      setTimeout(() => this.dataSource.sort = this.sort);   
      this.dataSource.filterPredicate = (data:UnitListModel, filterValue: string) => 
                    data.unitName.toLocaleLowerCase().indexOf(filterValue.toLocaleLowerCase()) !== -1
                    || data.id.toString().toLocaleLowerCase().indexOf(filterValue.toLocaleLowerCase()) !== -1;
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
        this.unitService.getUnitById(obj.id).subscribe(data => {
          this.openDialog(action,data);
        });

      } else {
          this.openDialog(action,obj);
      }  
    }


    openDialog(action,obj) {
      obj.action = action;  
      const dialogRef = this.dialog.open(UnitsDialogComponent,  {             
        data:obj
      });
  
      dialogRef.afterClosed().subscribe(result => {
        if(result.event == 'Ekle'){
          console.log(result.data);
          this.unitService.add(result.data).subscribe(data => {           
              console.log(data.status);
              console.log(data.body);  
              this._snackBar.open(data.body.unitName + " Başarıyla Eklendi.", "Tamam", {duration: 5000,});   
              this.LoadData();           
         }, error => {
             console.log(error.status);
             console.log(error.error);  
             this._snackBar.open("Hata : " +error.error, "Tamam", {duration: 8000,});  
         });
         
         
        }else if(result.event == 'Güncelle'){
          console.log(result.data);
          this.unitService.update(result.data).subscribe(data => {           
              console.log(data.status);
              console.log(data.body);  
              this._snackBar.open(data.body.unitName + " Başarıyla Düzenlendi.", "Tamam", {duration: 5000,});   
              this.LoadData();           
         }, error => {
             console.log(error.status);
             console.log(error.error);  
             this._snackBar.open("Hata : " +error.error, "Tamam", {duration: 8000,});  
         });

        }else if(result.event == 'Sil'){
          console.log(result.data);
          this.unitService.delete(result.data).subscribe(data => {           
              console.log(data.status);
              console.log(data.body);  
              this._snackBar.open(data.body.unitName + " Başarıyla Silindi.", "Tamam", {duration: 5000,});   
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
   

 

    
    deleteUnits(): void {
      const selectedIds:Number[] = [];
      const dialogRef = this.dialog.open(MyDialogComponent, {
        data: new DataDialog ( "Seçili Birimleri Sil" , "Seçili Birimleri Silmek İstediğinizden Emin Misiniz ? ", "Kapat","Sil")
      });     
      dialogRef.afterClosed().subscribe(result => {
        
        if(result =="Yes" ){
          this.selection.selected.forEach(function (value) {
            selectedIds.push(value.id);
          }); 
          this.unitService.deleteselected(selectedIds).subscribe(data => {           
            console.log(data.status); 
            this._snackBar.open("Seçilen Birimler Başarıyla Silindi.", "Tamam", {duration: 5000,});   
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
 
 


 