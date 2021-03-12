import { Component, Output, EventEmitter, OnInit} from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { ClientService } from '../../client/client.service';
import { ClientTypeService } from '../../clientType/clientType.service';

import { Client } from '../../client/client-entity';
import { ClientType } from '../../clientType/clientType-entity';

@Component({
    selector: 'app-client-cru',
    templateUrl: './client-cru.component.html',
    styleUrls: ['./client-cru.component.scss']
})
/** ClientCRU component*/
export class ClientCruComponent {

    @Output() changeActionEndEvent = new EventEmitter

    public client: Client;
    public debugMesssage: string;
    public a: any;

    public clientTypes: Array<ClientType>;

    public registerForm: FormGroup;

    constructor(private clientService: ClientService, private clientTypeService: ClientTypeService) {
    }

  ngOnInit() {
    this.client = new Client();
    this.clientTypeService.getClientTypes().subscribe(r => { this.clientTypes = r });
    this.a = new Object();

      //    this.debugMesssage = JSON.stringify(this.clientViewParams) + "_init";
      this.registerForm = new FormGroup({
        Id: new FormControl(this.client.id),
        firstName: new FormControl(this.client.firstName),
        lastName: new FormControl(this.client.lastName),
        personalId: new FormControl(this.client.personalId),
        birthDate: new FormControl(this.client.birthDate),
        mobile: new FormControl(this.client.mobile),
        address: new FormControl(this.client.address),
        clientTypeId: new FormControl(this.client.clientTypeId) //new FormControl(this.client.clientTypeId)
      });

    }

   saveClicked() {

     for (let i in this.registerForm.controls)
      this.registerForm.controls[i].markAsTouched();

     this.debugMesssage = "aaaa: " + JSON.stringify(this.client);

//    this.changeActionEndEvent.emit('doOk');

   }

    cancelClicked() {
      this.changeActionEndEvent.emit('doCancel');
    }

}
