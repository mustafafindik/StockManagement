import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Settings } from '../helpers/Settings';
import { Unit } from '../models/Unit/Unit';
import { UnitDetailModel } from '../models/Unit/UnitDetailModel';
import { UnitListModel } from '../models/Unit/UnitListModel';

@Injectable({
  providedIn: 'root'
})
export class UnitService {

  constructor(private httpClient: HttpClient) { }
  path = Settings.ApiBaseUrl;
  getUnits(): Observable<UnitListModel[]> {
    return this.httpClient.get<UnitListModel[]>(this.path + "units/getunits");
  }

  getUnitById(unitId: number): Observable<UnitDetailModel> {
    return this.httpClient.get<UnitDetailModel>(this.path + "units/detail/" + unitId);
  }


  add(unit: Unit): Observable<any> {
    return this.httpClient.post(this.path + 'units/add', unit, { observe: 'response' });
  }

  update(unit: Unit): Observable<any> {
    return this.httpClient.put(this.path + 'units/update', unit, { observe: 'response' });
  }

  delete(unit: Unit): Observable<any> {
    return this.httpClient.delete(this.path + 'units/delete/' + unit["id"], { observe: 'response' });
  }

  deleteselected(ids: Number[]): Observable<any> {
    return this.httpClient.post(this.path + 'units/deleteselected', ids, { observe: 'response' });
  }




}
