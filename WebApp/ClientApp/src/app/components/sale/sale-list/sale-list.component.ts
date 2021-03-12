import { Component } from '@angular/core';

import { IDynamicComponent } from '../../../common/DynamicDirectives/dynamic-component.interface';

@Component({
    selector: 'app-sale-list',
    templateUrl: './sale-list.component.html',
    styleUrls: ['./sale-list.component.scss']
})
/** SaleList component*/
export class SaleListComponent implements IDynamicComponent {
  inputParams: any;
  userContext: any;

   constructor() {

    }
}
