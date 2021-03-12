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

    public debugMesssage: string;

    public CompStateEnum = ComponentState; 
    public compState = ComponentState.ShowData;

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
  }

  btnEditClicked() {
    this.compState = ComponentState.EditItem;
  }

  btnDeleteClicked() {
//    this.compState = ComponentState.EditItem;
  }

  onFetchDataEnd(e) {
    var result = JSON.parse(e);
    this.debugMesssage = result.Action;

    if (result.Action == "OK") {

      this.debugMesssage = "OK " + JSON.stringify(JSON.parse(e).Params);
      this.clientViewParams = JSON.parse(e).Params;
      this.clientService.getClientView(this.clientViewParams).subscribe(r => { this.gridData = r });;
      this.compState = ComponentState.ShowData;
    }
    else {
      this.compState = ComponentState.ShowData;
    }

  }

  onChangeClientEnd(e) {
    this.debugMesssage = JSON.stringify(e.Params);
    this.compState = ComponentState.ShowData;
  }

  onDeleteClientEnd() {

  }

}
