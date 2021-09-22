import { Component } from '@angular/core';
import { Observable} from 'rxjs';

import { IDynamicComponent } from '../../../common/DynamicDirectives/dynamic-component.interface';

import { ComponentState } from '../../../common/ComponentTypes';
import { UserViewParams, UserView } from '../user-entity';
import { UserService } from '../user.service';
import { FormActionType } from '../../../common/FormActionTypes';

@Component({
    selector: 'app-user-list',
    templateUrl: './user-list.component.html',
    styleUrls: ['./user-list.component.scss']
})
/** UsertList component*/
export class UserListComponent implements IDynamicComponent {
    inputParams: any;
    userContext: any;

    userViewParams: UserViewParams;

    public tackSize: number =200;

    public debugMesssage: string;

    public CompStateEnum = ComponentState; 
    public compState = ComponentState.ShowData;

    public formCRUActionType: FormActionType;
    public currentID: number = -1;
    public currentIndex: number = -1;

    public sampleProducts;

    public gridData: UserView[];

  constructor(private userService: UserService) {
    this.userViewParams = new UserViewParams();
    this.userService.getUserView(this.userViewParams).subscribe(r => { this.gridData = r });
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
    this.userService.getUserView(this.userViewParams).subscribe(r => { this.gridData = r });;
    this.compState = ComponentState.ShowData;
  }

  onFetchDataEnd(e) {
    var result = JSON.parse(e);
    this.debugMesssage = result.Action;

    if (result.Action == "OK") {

      this.userViewParams = JSON.parse(e).Params;
      this.userService.getUserView(this.userViewParams).subscribe(r => { this.gridData = r });
      this.compState = ComponentState.ShowData;
    }
    else {
      this.compState = ComponentState.ShowData;
    }

  }

  onChangeUserEnd(e) {
    this.debugMesssage = JSON.stringify(e.Params);

    if (this.formCRUActionType == FormActionType.EditItem) {
      var p = new UserViewParams();
      p.id = this.currentID;
      console.log("refreshparam:" + JSON.stringify(p));
      this.userService.getUserView(p).subscribe(r =>
      {
        console.log("this.currentIndex:" + this.currentIndex);
        console.log("refreshValue:" + JSON.stringify(r[0]));
        this.gridData[this.currentIndex] = r[0];
      });
    }



    this.compState = ComponentState.ShowData;
  }

  onDeleteUserEnd() {

  }

  public onSelect($event) {
    if ($event.selectedRows.length == 0) this.currentID = -1
    else {
      this.currentID = $event.selectedRows[0].dataItem.user.id;
      this.currentIndex = $event.selectedRows[0].index;
      console.log(JSON.stringify($event.selectedRows));
      console.log(this.currentIndex);
    }

//    this.debugMesssage = "row selected:" + JSON.stringify(this.currentID);
  }

}
