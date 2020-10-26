import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CitiesComponent } from './components/cities/cities.component';
import { UnitComponent } from './components/unit/unit.component';
import { DashboardComponent } from './components/Dashboard/Dashboard.component';
import { ProductComponent } from './components/product/product.component';
import { WarehousesComponent } from './components/warehouses/warehouses.component';
import { VatratesComponent } from './components/vatrates/vatrates.component';

 
const routes: Routes = [ 
  { path: "dashboard", component: DashboardComponent },
  { path: "cities", component: CitiesComponent },
  { path: "warehouses", component: WarehousesComponent },
  { path: "products", component: ProductComponent },
  { path: "units", component: UnitComponent },
  { path: "vatrates", component: VatratesComponent },
  { path: '',   redirectTo: 'dashboard', pathMatch: 'full' },
  { path: "**", redirectTo: "dashboard", pathMatch: "full" }];
 

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule { }
