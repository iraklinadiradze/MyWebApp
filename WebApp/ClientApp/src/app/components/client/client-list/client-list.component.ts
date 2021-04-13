import { Component } from '@angular/core';
import { Observable} from 'rxjs';

import { IDynamicComponent } from '../../../common/DynamicDirectives/dynamic-component.interface';
// import { KendoGridColumnDateFormatDirective } from '../../../common/KendoGridColumnDateFormatDirective';
// import { ClientCruComponent } from '../client-cru/client-cru.component';
// import { ClientFetchDataComponent } from '../client-fetchdata/client-fetchdata.component';

import { ComponentState } from '../../../common/ComponentTypes';
import { ClientViewParams, ClientView } from '../client-entity';
// import { stringify } from '@angular/compiler/src/util';
import { ClientService } from '../client.service';
import { FormActionType } from '../../../common/FormActionTypes';

@Component({
    selector: 'app-client-list',
    templateUrl: './client-list.component.html',
    styleUrls: ['./client-list.component.scss']
})
/** ClientList component*/
export class ClientListComponent implements IDynamicComponent {
    inputParams: any;
    userContext: any;

    clientViewParams: ClientViewParams;

    public tackSize: number =200;

    public debugMesssage: string;

    public CompStateEnum = ComponentState; 
    public compState = ComponentState.ShowData;

//    public FormCRUActionEnum: FormActionType;
    public formCRUActionType: FormActionType;
    public currentID: number = -1;
    public currentIndex: number = -1;

    public sampleProducts;

    public gridData: ClientView[];

  constructor(private clientService: ClientService) {
    //    this.gridData = this.sampleProducts;
    //    this.gridData = this.clientService.getClientView(null);


//    this.debugMesssage = JSON.stringify(ttt);
    this.clientViewParams = new ClientViewParams();
    this.clientService.getClientView(this.clientViewParams).subscribe(r => { this.gridData = r });;
//    this.clientViewParams.topRecords = 555555;
//    this.clientViewParams.id = 22222;
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
    this.clientService.getClientView(this.clientViewParams).subscribe(r => { this.gridData = r });;
    this.compState = ComponentState.ShowData;
  }

  onFetchDataEnd(e) {
    var result = JSON.parse(e);
    this.debugMesssage = result.Action;

    if (result.Action == "OK") {

//      this.debugMesssage = "OK " + JSON.stringify(JSON.parse(e).Params);
      this.clientViewParams = JSON.parse(e).Params;
      this.clientService.getClientView(this.clientViewParams).subscribe(r => { this.gridData = r });
      this.compState = ComponentState.ShowData;
    }
    else {
      this.compState = ComponentState.ShowData;
    }

  }

  onChangeClientEnd(e) {
    this.debugMesssage = JSON.stringify(e.Params);

    if (this.formCRUActionType == FormActionType.EditItem) {
      var p = new ClientViewParams();
      p.id = this.currentID;
      console.log("refreshparam:" + JSON.stringify(p));
      this.clientService.getClientView(p).subscribe(r =>
      {
        console.log("this.currentIndex:" + this.currentIndex);
        console.log("refreshValue:" + JSON.stringify(r[0]));
        this.gridData[this.currentIndex] = r[0];
      });
    }



    this.compState = ComponentState.ShowData;
  }

  onDeleteClientEnd() {

  }

  public onSelect($event) {
    if ($event.selectedRows.length == 0) this.currentID = -1
    else {
      this.currentID = $event.selectedRows[0].dataItem.client.id;
      this.currentIndex = $event.selectedRows[0].index;
      console.log(JSON.stringify($event.selectedRows));
      console.log(this.currentIndex);
    }

//    this.debugMesssage = "row selected:" + JSON.stringify(this.currentID);
  }

}
