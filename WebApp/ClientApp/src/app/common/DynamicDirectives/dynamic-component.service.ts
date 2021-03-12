import { Injectable } from '@angular/core';

// import { HeroJobAdComponent } from './hero-job-ad.component';
// import { HeroProfileComponent } from './hero-profile.component';
// import { DynamicComponent} from './dynamic-component';

import { ClientListComponent } from '../../components/client/client-list/client-list.component';
import { ProductListComponent } from '../../components/product/product-list/product-list.component';
import { PurchaseListComponent } from '../../components/purchase/purchase-list/purchase-list.component';
import { SaleListComponent } from '../../components/sale/sale-list/sale-list.component';


@Injectable()
export class DynamicComponentService {

  private AppComponents = [
    { path: 'ClientList', component: ClientListComponent },
    { path: 'PurchaseList', component: PurchaseListComponent },
    { path: 'ProductList', component: ProductListComponent },
    { path: 'SaleList', component: SaleListComponent }
  ];

  getComponent(path: string)
  {
    return this.AppComponents.find(e => e.path == path).component;
  }

}


/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/
