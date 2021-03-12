import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client, ClientView, ClientViewParams } from './client-entity';
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  baseUrl = environment.apiURL + '/clients';

  constructor(private http: HttpClient) {
    // this.http = new HttpClient();
  }

  createClient(client: Client) {
    return this.http.post(this.baseUrl, client);
  }

  editClient(client: Client) {
    return this.http.put(this.baseUrl, client);
  }

  deleteClient(clientID: number) {
    return this.http.delete(this.baseUrl + '/' + clientID);
  }

  /*
  postClient(clientID: number) {
    return this.http.put(this.baseUrl + '/' + clientID + "/post", "");
  }

  unpostClient(clientID: number) {
    return this.http.put(this.baseUrl + '/' + clientID + "/unpost", "");
  }
  */

  getClientView(clientViewParams: ClientViewParams) {
    var queryStr="";

//      queryStr = Object.keys(clientViewParams).map(
//        (el) => (`if (clientViewParams[el] ${el}=${clientViewParams[el]}`)
//      ).join("&");

//    Object.keys(clientViewParams).foreach((item, index) => (if ());

    for (var key in clientViewParams) {
      if (clientViewParams[key] != null) {
        if (queryStr != "") queryStr = queryStr  + "&"
        queryStr = queryStr + key + "=" + clientViewParams[key];
      }
    }

    console.log(queryStr);

    //    return this.http.get<ClientView[]>(this.baseUrl + '/ClientView?' + queryStr );

    return this.http.get<ClientView[]>(this.baseUrl + '/ClientView?' + queryStr );

  }

}
