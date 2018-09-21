import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Horario } from '../../Models/horario';

/*
  Generated class for the HorarioServiceProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class HorarioServiceProvider {

  constructor(private _http: HttpClient) {
    
  }

  lista(dia){
    return this._http.get<Horario[]>("http://localhost:55077/api/consultas/?data="+dia)
  }
}
