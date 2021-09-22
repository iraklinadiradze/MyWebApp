import { Component } from '@angular/core';
import { Observable} from 'rxjs';

import { IDynamicComponent } from '../../../common/DynamicDirectives/dynamic-component.interface';

import { ComponentState } from '../../../common/ComponentTypes';
import { BrandViewParams, BrandView } from '../brand-entity';
import { BrandService } from '../brand.service';
import { FormActionType } from '../../../common/FormActionTypes';

@Component({
    selector: 'app-brand-list',
    templateUrl: './brand-list.component.html',
    styleUrls: ['./brand-list.component.scss']
})
/** BrandtList component*/
export class BrandListComponent implements IDynamicComponent {
    inputParams: any;
    userContext: any;

    brandViewParams: BrandViewParams;

    public tackSize: number =200;

    public debugMesssage: string;

    public CompStateEnum = ComponentState; 
    public compState = ComponentState.ShowData;

    public formCRUActionType: FormActionType;
    public currentID: number = -1;
    public currentIndex: number = -1;

    public sampleProducts;

    public gridData: BrandView[];

  constructor(private brandService: BrandService) {
    this.brandViewParams = new BrandViewParams();
    this.brandService.getBrandView(this.brandViewParams).subscribe(r => { this.gridData = r });
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
    this.brandService.getBrandView(this.brandViewParams).subscribe(r => { this.gridData = r });;
    this.compState = ComponentState.ShowData;
  }

  onFetchDataEnd(e) {
    var result = JSON.parse(e);
    this.debugMesssage = result.Action;

    if (result.Action == "OK") {

      this.brandViewParams = JSON.parse(e).Params;
      this.brandService.getBrandView(this.brandViewParams).subscribe(r => { this.gridData = r });
      this.compState = ComponentState.ShowData;
    }
    else {
      this.compState = ComponentState.ShowData;
    }

  }

  onChangeBrandEnd(e) {
    this.debugMesssage = JSON.stringify(e.Params);

    if (this.formCRUActionType == FormActionType.EditItem) {
      var p = new BrandViewParams();
      p.id = this.currentID;
      console.log("refreshparam:" + JSON.stringify(p));
      this.brandService.getBrandView(p).subscribe(r =>
      {
        console.log("this.currentIndex:" + this.currentIndex);
        console.log("refreshValue:" + JSON.stringify(r[0]));
        this.gridData[this.currentIndex] = r[0];
      });
    }



    this.compState = ComponentState.ShowData;
  }

  onDeleteBrandEnd() {

  }

  public onSelect($event) {
    if ($event.selectedRows.length == 0) this.currentID = -1
    else {
      this.currentID = $event.selectedRows[0].dataItem.brand.id;
      this.currentIndex = $event.selectedRows[0].index;
      console.log(JSON.stringify($event.selectedRows));
      console.log(this.currentIndex);
    }

//    this.debugMesssage = "row selected:" + JSON.stringify(this.currentID);
  }

}
