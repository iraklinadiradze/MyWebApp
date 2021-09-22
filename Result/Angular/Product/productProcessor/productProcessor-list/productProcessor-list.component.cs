import { Component } from '@angular/core';
import { Observable} from 'rxjs';

import { IDynamicComponent } from '../../../common/DynamicDirectives/dynamic-component.interface';

import { ComponentState } from '../../../common/ComponentTypes';
import { ProductProcessorViewParams, ProductProcessorView } from '../productProcessor-entity';
import { ProductProcessorService } from '../productProcessor.service';
import { FormActionType } from '../../../common/FormActionTypes';

@Component({
    selector: 'app-productProcessor-list',
    templateUrl: './productProcessor-list.component.html',
    styleUrls: ['./productProcessor-list.component.scss']
})
/** ProductProcessortList component*/
export class ProductProcessorListComponent implements IDynamicComponent {
    inputParams: any;
    userContext: any;

    productProcessorViewParams: ProductProcessorViewParams;

    public tackSize: number =200;

    public debugMesssage: string;

    public CompStateEnum = ComponentState; 
    public compState = ComponentState.ShowData;

    public formCRUActionType: FormActionType;
    public currentID: number = -1;
    public currentIndex: number = -1;

    public sampleProducts;

    public gridData: ProductProcessorView[];

  constructor(private productProcessorService: ProductProcessorService) {
    this.productProcessorViewParams = new ProductProcessorViewParams();
    this.productProcessorService.getProductProcessorView(this.productProcessorViewParams).subscribe(r => { this.gridData = r });
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
    this.productProcessorService.getProductProcessorView(this.productProcessorViewParams).subscribe(r => { this.gridData = r });;
    this.compState = ComponentState.ShowData;
  }

  onFetchDataEnd(e) {
    var result = JSON.parse(e);
    this.debugMesssage = result.Action;

    if (result.Action == "OK") {

      this.productProcessorViewParams = JSON.parse(e).Params;
      this.productProcessorService.getProductProcessorView(this.productProcessorViewParams).subscribe(r => { this.gridData = r });
      this.compState = ComponentState.ShowData;
    }
    else {
      this.compState = ComponentState.ShowData;
    }

  }

  onChangeProductProcessorEnd(e) {
    this.debugMesssage = JSON.stringify(e.Params);

    if (this.formCRUActionType == FormActionType.EditItem) {
      var p = new ProductProcessorViewParams();
      p.id = this.currentID;
      console.log("refreshparam:" + JSON.stringify(p));
      this.productProcessorService.getProductProcessorView(p).subscribe(r =>
      {
        console.log("this.currentIndex:" + this.currentIndex);
        console.log("refreshValue:" + JSON.stringify(r[0]));
        this.gridData[this.currentIndex] = r[0];
      });
    }



    this.compState = ComponentState.ShowData;
  }

  onDeleteProductProcessorEnd() {

  }

  public onSelect($event) {
    if ($event.selectedRows.length == 0) this.currentID = -1
    else {
      this.currentID = $event.selectedRows[0].dataItem.productProcessor.id;
      this.currentIndex = $event.selectedRows[0].index;
      console.log(JSON.stringify($event.selectedRows));
      console.log(this.currentIndex);
    }

//    this.debugMesssage = "row selected:" + JSON.stringify(this.currentID);
  }

}
