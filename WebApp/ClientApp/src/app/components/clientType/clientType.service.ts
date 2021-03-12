import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClientType} from './clientType-entity';
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ClientTypeService {

  baseUrl = environment.apiURL + '/clientTypes';

  constructor(private http: HttpClient) {
    // this.http = new HttpClientType();
  }

  createClientType(clientType: ClientType) {
    return this.http.post(this.baseUrl, clientType);
  }

  editClientType(clientType: ClientType) {
    return this.http.put(this.baseUrl, clientType);
  }

  deleteClientType(clientTypeID: number) {
    return this.http.delete(this.baseUrl + '/' + clientTypeID);
  }

  /*
  postClientType(clientTypeID: number) {
    return this.http.put(this.baseUrl + '/' + clientTypeID + "/post", "");
  }

  unpostClientType(clientTypeID: number) {
    return this.http.put(this.baseUrl + '/' + clientTypeID + "/unpost", "");
  }
  */

  getClientTypes() {
    return this.http.get<ClientType[]>(this.baseUrl + '');
  }

}
