import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Datacheia } from '../../Models/datacheia';

/*
  Generated class for the DirecionaconexaoServiceProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class DirecionaconexaoServiceProvider {

  constructor(private _http: HttpClient) {  
  }

  dias(){
    return this._http.get<Datacheia[]>("http://localhost:55077/api/consultas")
  }

}
