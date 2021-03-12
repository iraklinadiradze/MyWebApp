import { Component } from '@angular/core';

import { IDynamicComponent } from '../../../common/DynamicDirectives/dynamic-component.interface';

@Component({
    selector: 'app-purchase-list',
    templateUrl: './purchase-list.component.html',
    styleUrls: ['./purchase-list.component.scss']
})
/** PurchaseList component*/
export class PurchaseListComponent implements IDynamicComponent {
  inputParams: any;
  userContext: any;

    constructor() {

    }
}
