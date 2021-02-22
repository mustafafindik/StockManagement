import { Injectable } from '@angular/core';
import { Settings } from '../helpers/Settings';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { City } from '../models/City/City';
 

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private httpClient: HttpClient) { }
  path = Settings.ApiBaseUrl;
  getCities(): Observable<City[]> {
    return this.httpClient.get<City[]>(this.path + "cities");
  }

  getCityById(cityId: number): Observable<City> {
    return this.httpClient.get<City>(this.path + "cities/" + cityId);
  }


  add(city: City): Observable<any> {
    return this.httpClient.post(this.path + 'cities/add', city, { observe: 'response' });
  }

  update(city: City): Observable<any> {
    return this.httpClient.post(this.path + 'cities/update', city, { observe: 'response' });
  }

  delete(city: City): Observable<any> {
    return this.httpClient.post(this.path + 'cities/delete/' + city["id"], { observe: 'response' });
  }

  deleteselected(ids: Number[]): Observable<any> {
    return this.httpClient.post(this.path + 'cities/deleteselected', ids, { observe: 'response' });
  }
}








