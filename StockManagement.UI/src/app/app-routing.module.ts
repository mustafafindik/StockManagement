import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CitiesComponent } from './components/cities/cities.component';
import { UnitComponent } from './components/unit/unit.component';
import { DashboardComponent } from './components/Dashboard/Dashboard.component';
import { WarehousesComponent } from './components/warehouses/warehouses.component';
import { VatratesComponent } from './components/vatrates/vatrates.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { CustomersComponent } from './components/customers/customers.component';
import { SuppliersComponent } from './components/suppliers/suppliers.component';
import { ProductsComponent } from './components/products/products.component';

 
const routes: Routes = [ 
  { path: "dashboard", component: DashboardComponent },
  { path: "cities", component: CitiesComponent },
  { path: "warehouses", component: WarehousesComponent },
  { path: "products", component: ProductsComponent },
  { path: "units", component: UnitComponent },
  { path: "vatrates", component: VatratesComponent },
  { path: "categories", component: CategoriesComponent },
  { path: "customers", component: CustomersComponent },
  { path: "suppliers", component: SuppliersComponent },
  { path: '',   redirectTo: 'dashboard', pathMatch: 'full' },
  { path: "**", redirectTo: "dashboard", pathMatch: "full" }];
 

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule { }
