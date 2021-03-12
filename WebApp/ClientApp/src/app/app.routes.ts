import { Routes } from '@angular/router';

import { ClientListComponent } from './components/client/client-list/client-list.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { PurchaseListComponent } from './components/purchase/purchase-list/purchase-list.component';
import { SaleListComponent } from './components/sale/sale-list/sale-list.component';

/**
 * Define app module routes here, e.g., to lazily load a module
 * (do not place feature module routes here, use an own -routing.module.ts in the feature instead)
 */
export const AppRoutes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '' },
  { path: 'ClientList', component: ClientListComponent },
  { path: 'PurchaseList', component: PurchaseListComponent },
  { path: 'ProductList', component: ProductListComponent },
  { path: 'SaleList', component: SaleListComponent }
];
