import { Component } from '@angular/core';
import { Observable} from 'rxjs';

import { IDynamicComponent } from '../../../common/DynamicDirectives/dynamic-component.interface';

import { ComponentState } from '../../../common/ComponentTypes';
import { ProductProcessorSalePriceViewParams, ProductProcessorSalePriceView } from '../productProcessorSalePrice-entity';
import { ProductProcessorSalePriceService } from '../productProcessorSalePrice.service';
import { FormActionType } from '../../../common/FormActionTypes';

@Component({
    selector: 'app-productProcessorSalePrice-list',
    templateUrl: './productProcessorSalePrice-list.component.html',
    styleUrls: ['./productProcessorSalePrice-list.component.scss']
})
/** ProductProcessorSalePricetList component*/
export class ProductProcessorSalePriceListComponent implements IDynamicComponent {
    inputParams: any;
    userContext: any;

    productProcessorSalePriceViewParams: ProductProcessorSalePriceViewParams;

    public tackSize: number =200;

    public debugMesssage: string;

    public CompStateEnum = ComponentState; 
    public compState = ComponentState.ShowData;

    public formCRUActionType: FormActionType;
    public currentID: number = -1;
    public currentIndex: number = -1;

    public sampleProducts;

    public gridData: ProductProcessorSalePriceView[];

  constructor(private productProcessorSalePriceService: ProductProcessorSalePriceService) {
    this.productProcessorSalePriceViewParams = new ProductProcessorSalePriceViewParams();
    this.productProcessorSalePriceService.getProductProcessorSalePriceView(this.productProcessorSalePriceViewParams).subscribe(r => { this.gridData = r });
  }

  btnFetchDataClicked() {
    this.compState = ComponentState.FetchData;
  }

  btnAddClicked() {
    this.compState = ComponentState.AddItem;

    this.formCRUActionType = FormActionType.AddItem;
  }

  btnEditClicked() {

    if (this.currentID < 0) return;

    this.compState = ComponentState.EditItem;

    this.formCRUActionType = FormActionType.EditItem;
//    this.currentID = 2;
  }

  btnDeleteClicked() {
//    this.compState = ComponentState.EditItem;
  }

  btnRefreshClicked() {
    this.productProcessorSalePriceService.getProductProcessorSalePriceView(this.productProcessorSalePriceViewParams).subscribe(r => { this.gridData = r });;
    this.compState = ComponentState.ShowData;
  }

  onFetchDataEnd(e) {
    var result = JSON.parse(e);
    this.debugMesssage = result.Action;

    if (result.Action == "OK") {

      this.productProcessorSalePriceViewParams = JSON.parse(e).Params;
      this.productProcessorSalePriceService.getProductProcessorSalePriceView(this.productProcessorSalePriceViewParams).subscribe(r => { this.gridData = r });
      this.compState = ComponentState.ShowData;
    }
    else {
      this.compState = ComponentState.ShowData;
    }

  }

  onChangeProductProcessorSalePriceEnd(e) {
    this.debugMesssage = JSON.stringify(e.Params);

    if (this.formCRUActionType == FormActionType.EditItem) {
      var p = new ProductProcessorSalePriceViewParams();
      p.id = this.currentID;
      console.log("refreshparam:" + JSON.stringify(p));
      this.productProcessorSalePriceService.getProductProcessorSalePriceView(p).subscribe(r =>
      {
        console.log("this.currentIndex:" + this.currentIndex);
        console.log("refreshValue:" + JSON.stringify(r[0]));
        this.gridData[this.currentIndex] = r[0];
      });
    }



    this.compState = ComponentState.ShowData;
  }

  onDeleteProductProcessorSalePriceEnd() {

  }

  public onSelect($event) {
    if ($event.selectedRows.length == 0) this.currentID = -1
    else {
      this.currentID = $event.selectedRows[0].dataItem.productProcessorSalePrice.id;
      this.currentIndex = $event.selectedRows[0].index;
      console.log(JSON.stringify($event.selectedRows));
      console.log(this.currentIndex);
    }

//    this.debugMesssage = "row selected:" + JSON.stringify(this.currentID);
  }

}