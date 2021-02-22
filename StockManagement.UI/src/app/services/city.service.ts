import { Injectable } from '@angular/core';
import { Settings } from '../helpers/Settings';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { City } from '../models/City/City';
import { CityListModel } from '../models/City/CityListModel';
import { CityDetailModel } from '../models/City/CityDetailModel';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private httpClient: HttpClient) { }
  path = Settings.ApiBaseUrl;
  getCities(): Observable<CityListModel[]> {
    return this.httpClient.get<CityListModel[]>(this.path + "cities/getcities");
  }

  getCityById(cityId: number): Observable<CityDetailModel> {
    return this.httpClient.get<CityDetailModel>(this.path + "cities/detail/" + cityId);
  }


  add(city: City): Observable<any> {
    return this.httpClient.post(this.path + 'cities/add', city, { observe: 'response' });
  }

  update(city: City): Observable<any> {
    return this.httpClient.put(this.path + 'cities/update', city, { observe: 'response' });
  }

  delete(city: City): Observable<any> {
    return this.httpClient.delete(this.path + 'cities/delete/' + city["id"], { observe: 'response' });
  }

  deleteselected(ids: Number[]): Observable<any> {
    return this.httpClient.post(this.path + 'cities/deleteselected', ids, { observe: 'response' });
  }
}








