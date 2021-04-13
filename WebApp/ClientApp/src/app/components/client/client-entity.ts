import { ClientType } from "../clientType/clientType-entity"

export class Client {
  id : number;
  firstName: string;
  lastName: string;
  personalId: string;
  clientTypeId: number;
  birthDate: Date;
  address: string;
  mobile: string;
  clientType: ClientType;
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
