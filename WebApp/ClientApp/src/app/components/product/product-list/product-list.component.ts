import { Component } from '@angular/core';

import { IDynamicComponent } from '../../../common/DynamicDirectives/dynamic-component.interface';

@Component({
    selector: 'app-product-list',
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.scss']
})

/** ProductList component*/
export class ProductListComponent implements IDynamicComponent {
  inputParams: any;
  userContext: any;

/** ProductList ctor */
    constructor() {

    }
}
