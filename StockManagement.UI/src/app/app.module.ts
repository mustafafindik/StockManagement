import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CitiesComponent } from './components/cities/cities.component';
import { DashboardComponent } from './components/Dashboard/Dashboard.component';
import { MobileHeaderComponent } from './modules/mobile-header/mobile-header.component';
import { FooterComponent } from './modules/footer/footer.component';
import { HeaderComponent } from './modules/header/header.component';
import { SidebarComponent } from './modules/sidebar/sidebar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from "@angular/material/table";
import { MatSortModule } from "@angular/material/sort";
import { MatProgressSpinnerModule, } from "@angular/material/progress-spinner";
import { MatPaginatorIntl, MatPaginatorModule } from "@angular/material/paginator";
import { MatInputModule, } from "@angular/material/input";
import { CustomPaginator } from './helpers/CustomPaginatorConfiguration';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar/';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MyDialogComponent } from './extensions/dialog/Mydialog.component';
import { CitiesDialogComponent } from './components/cities/cities-dialog/cities-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { WarehousesComponent } from './components/warehouses/warehouses.component';
import { WarehouseDialogComponent } from './components/warehouses/warehouse-dialog/warehouse-dialog.component';
import { MatSelectModule } from '@angular/material/select';
import { UnitComponent } from './components/unit/unit.component';
import { UnitsDialogComponent } from './components/unit/units-dialog/units-dialog.component';
import { VatratesComponent } from './components/vatrates/vatrates.component';
import { VatrateDialogComponent } from './components/vatrates/vatrate-dialog/vatrate-dialog.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { MatTreeModule } from '@angular/material/tree';
import { CategoriesDialogComponent } from './components/categories/categories-dialog/categories-dialog.component';
import { SuppliersComponent } from './components/suppliers/suppliers.component';
import { CustomersComponent } from './components/customers/customers.component';
import { SupplierDialogComponent } from './components/suppliers/supplier-dialog/supplier-dialog.component';
import { CustomerDialogComponent } from './components/customers/customer-dialog/customer-dialog.component';
import { ProductsComponent } from './components/products/products.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    CitiesComponent,
    MobileHeaderComponent,
    FooterComponent,
    SidebarComponent,
    HeaderComponent,
    ProductsComponent,
    MyDialogComponent,
    CitiesDialogComponent,
    WarehousesComponent,
    WarehouseDialogComponent,
    UnitComponent,
    UnitsDialogComponent,
    VatratesComponent,
    VatrateDialogComponent,
    CategoriesComponent,
    CategoriesDialogComponent,
    SuppliersComponent,
    SupplierDialogComponent,
    CustomersComponent,
    CustomerDialogComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatProgressSpinnerModule,
    MatCheckboxModule,
    MatIconModule,
    MatButtonModule,
    MatMenuModule,
    MatTooltipModule,
    MatDialogModule,
    MatFormFieldModule,
    MatSnackBarModule,
    FormsModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),
    MatSelectModule,
    MatTreeModule,
    
    

  ],
  providers: [
    { provide: MatPaginatorIntl, useValue: CustomPaginator() },
    Title,
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    MyDialogComponent, 
    CitiesDialogComponent, 
    WarehouseDialogComponent, 
    UnitsDialogComponent, 
    VatrateDialogComponent,
    CategoriesDialogComponent,
    SupplierDialogComponent,
    CustomerDialogComponent
  ]
})
export class AppModule {


}
