import { ClientType } from "../clientType/clientType-entity"

export class Client {
  id : number;
  firstName: string;
  lastName: string;
  mobile: string;
  personalId: string;
  birthDate: Date;
  address: string;
  clientTypeId: number;
};

export class ClientView {
  client: Client;
  clientType: ClientType;
};

export class ClientViewParams {
  id : number;
  topRecords: number;
  firstName : string;
  lastName  : string;
  pid: string;
  bodFrom: Date;
  bodTo: Date;
  clientTypeID: number;
};
