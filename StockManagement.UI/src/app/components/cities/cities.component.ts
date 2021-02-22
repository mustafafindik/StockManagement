import { SelectionModel } from '@angular/cdk/collections';
import {AfterViewChecked, AfterViewInit, Component,Inject,OnInit, ViewChild} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { MyDialogComponent } from 'src/app/extensions/dialog/Mydialog.component';
import { City } from 'src/app/models/City/City';
import { CityListModel } from 'src/app/models/City/CityListModel';
import { DataDialog } from 'src/app/models/DataDialog';
import { CityService } from 'src/app/services/city.service';
import { CitiesDialogComponent } from './cities-dialog/cities-dialog.component';
 
@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent  implements OnInit{
 
 
  
  dataSource = new MatTableDataSource<CityListModel>();
  displayedColumns = ['select', 'id', 'cityName',"actions"];
  selection = new SelectionModel<CityListModel>(true, []);


  @ViewChild(MatPaginator ) paginator: MatPaginator;
  @ViewChild(MatSort   ) sort: MatSort;
  
  constructor(private titleService: Title,private cityService: CityService,public dialog: MatDialog,private _snackBar: MatSnackBar) {}
  
  ngOnInit(): void {
    this.titleService.setTitle("Şehirler");
    this.LoadData();
  }

  LoadData() {
    this.cityService.getCities().subscribe(data => {  
      this.dataSource = new MatTableDataSource<CityListModel>(data);
      console.log(data);
      this.dataSource.paginator = this.paginator;    
      setTimeout(() => this.dataSource.sort = this.sort);   
      this.dataSource.filterPredicate = (data:CityListModel, filterValue: string) => 
                    data.cityName.toLocaleLowerCase().indexOf(filterValue.toLocaleLowerCase()) !== -1
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
        this.cityService.getCityById(obj.id).subscribe(data => {
          this.openDialog(action,data);
        });

      } else {
          this.openDialog(action,obj);
      }  
    }


    openDialog(action,obj) {
      obj.action = action;  
      const dialogRef = this.dialog.open(CitiesDialogComponent,  {             
        data:obj
      });
  
      dialogRef.afterClosed().subscribe(result => {
        if(result.event == 'Ekle'){
          console.log(result.data);
          this.cityService.add(result.data).subscribe(data => {           
              console.log(data.status);
              console.log(data.body);  
              this._snackBar.open(data.body.cityName + " Başarıyla Eklendi.", "Tamam", {duration: 5000,});   
              this.LoadData();           
         }, error => {
             console.log(error.status);
             console.log(error.error);  
             this._snackBar.open("Hata : " +error.error, "Tamam", {duration: 8000,});  
         });
         
         
        }else if(result.event == 'Güncelle'){
          console.log(result.data);
          this.cityService.update(result.data).subscribe(data => {           
              console.log(data.status);
              console.log(data.body);  
              this._snackBar.open(data.body.cityName + " Başarıyla Düzenlendi.", "Tamam", {duration: 5000,});   
              this.LoadData();           
         }, error => {
             console.log(error.status);
             console.log(error.error);  
             this._snackBar.open("Hata : " +error.error, "Tamam", {duration: 8000,});  
         });

        }else if(result.event == 'Sil'){
          console.log(result.data);
          this.cityService.delete(result.data).subscribe(data => {           
              console.log(data.status);
              console.log(data.body);  
              this._snackBar.open(data.body.cityName + " Başarıyla Silindi.", "Tamam", {duration: 5000,});   
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
   

 

    
    deleteCities(): void {
      const selectedIds:Number[] = [];
      const dialogRef = this.dialog.open(MyDialogComponent, {
        data: new DataDialog ( "Seçili Ürünleri Sil" , "Seçili Ürünleri Silmek İstediğinizden Emin Misiniz ? ", "Kapat","Sil")
      });     
      dialogRef.afterClosed().subscribe(result => {
        
        if(result =="Yes" ){
          this.selection.selected.forEach(function (value) {
            selectedIds.push(value.id);
          }); 
          this.cityService.deleteselected(selectedIds).subscribe(data => {           
            console.log(data.status); 
            this._snackBar.open("Seçilen Şehirler Başarıyla Silindi.", "Tamam", {duration: 5000,});   
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
 
 


 