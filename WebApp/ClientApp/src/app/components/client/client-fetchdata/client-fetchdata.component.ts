import { Component, EventEmitter, Output, Input , OnInit} from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { ClientViewParams, ClientView } from '../client-entity';

@Component({
  selector: 'app-client-fetchdata',
  templateUrl: './client-fetchdata.component.html',
  styleUrls: ['./client-fetchdata.component.scss']
})
/** ClientFilter component*/
export class ClientFetchDataComponent {
  @Input() public clientViewParams: ClientViewParams;
  @Output() fetchDataEndAction = new EventEmitter();

  public debugMesssage: string;

  public registerForm: FormGroup;

  constructor() {
//    this.debugMesssage = JSON.stringify(this.clientViewParams)  +"_constr";
  }

  ngOnInit(): void {
    //    this.debugMesssage = JSON.stringify(this.clientViewParams) + "_init";
    this.registerForm = new FormGroup({
      topRecords: new FormControl(this.clientViewParams.topRecords),
      id: new FormControl(this.clientViewParams.id),
      firstName: new FormControl(this.clientViewParams.firstName),
      lastName: new FormControl(this.clientViewParams.lastName),
      pid: new FormControl(this.clientViewParams.pid),
      bodFrom: new FormControl(this.clientViewParams.bodFrom),
      bodTo: new FormControl(this.clientViewParams.bodTo)
    });
  }

  public dataFetchClicked() {
//    this.clientViewParams.topRecords = 1111111;
//    this.registerForm.markAllAsTouched();

//    for (let i in this.registerForm.controls)
//      this.registerForm.controls[i].markAsTouched();

//    this.debugMesssage = "On Close: " + JSON.stringify(this.registerForm.value); //JSON.stringify(this.clientViewParams);
    this.fetchDataEndAction.emit(JSON.stringify({ "Action": "OK", "Params": this.registerForm.value }) );
  }

  public dataFetchCancelClicked() {

    this.fetchDataEndAction.emit(JSON.stringify({ "Action": "CANCEL"}));

  }

}
