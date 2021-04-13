import { Component, Output, Input, EventEmitter, OnInit} from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { ClientService } from '../../client/client.service';
import { ClientTypeService } from '../../clientType/clientType.service';

import { Client } from '../../client/client-entity';
import { ClientType } from '../../clientType/clientType-entity';
import { FormActionType } from '../../../common/FormActionTypes';

@Component({
    selector: 'app-client-cru',
    templateUrl: './client-cru.component.html',
    styleUrls: ['./client-cru.component.scss']
})
/** ClientCRU component*/
export class ClientCruComponent {
    @Input() public _id: number=0;
    @Input() public formActionType: FormActionType;
    public _FormActionType = FormActionType;;


    @Output() changeActionEndEvent = new EventEmitter;
  
    public client: Client;
    public debugMesssage: string;

    public clientTypes: Array<ClientType>;

    public registerForm: FormGroup;

    constructor(private clientService: ClientService, private clientTypeService: ClientTypeService) {
    }

  ngOnInit(): void {

    this.client = new Client();
    this.initForm(this.client);

    this.clientTypeService.getClientTypes().subscribe(r => { this.clientTypes = r });

    if (this.formActionType == FormActionType.AddItem) {
      this.client = new Client();
      this.client.id = 0;

      this.initForm(this.client);
    }
    else
    {

      this.clientService.getClient(this._id).subscribe(r => {
        this.client = r;
        this.client.birthDate = new Date(r.birthDate);
        this.debugMesssage = "aaaa: " + JSON.stringify(this.client);

        this.initForm(this.client);
      });
    }

    }

  initForm(_client: Client) {


    this.registerForm = new FormGroup({
      id: new FormControl(_client.id),
        firstName: new FormControl(_client.firstName),
        lastName: new FormControl(_client.lastName),
        personalId: new FormControl(_client.personalId),
        birthDate: new FormControl(_client.birthDate),
        mobile: new FormControl(_client.mobile),
        address: new FormControl(_client.address),
        clientTypeID: new FormControl(_client.clientTypeId) //new FormControl(this.client.clientTypeId)
      });
    }

   saveClicked() {

     for (let i in this.registerForm.controls)
      this.registerForm.controls[i].markAsTouched();

     this.debugMesssage = "aaaa: " + JSON.stringify(this.registerForm.value);

     console.log("save:" + this.formActionType);

     if (this.formActionType == FormActionType.AddItem) {
       console.log('add');
       this.clientService.createClient(this.registerForm.value).subscribe(
         r => {
                console.log("add result:" + JSON.stringify(r));
                this.changeActionEndEvent.emit('doOk');
             }
         );
     }

     if (this.formActionType == FormActionType.EditItem) {
       console.log('edit');

       this.clientService.editClient(this._id, this.registerForm.value).subscribe(
         r => {
           console.log("edit result:" + JSON.stringify(r))
           this.changeActionEndEvent.emit('doOk');
         }
       );
     }

//     this.debugMesssage = "fff: " + JSON.stringify(this.fff);


   }

    cancelClicked() {
      this.changeActionEndEvent.emit('doCancel');
    }

  handleOrderChange(value) {
    this.debugMesssage = "OnChange: " + JSON.stringify(value);
   }
}
