import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Settings } from '../helpers/Settings';
import { VatRate } from '../models/VatRate/VatRate';
import { VatRateListModel } from '../models/VatRate/VatRateListModel';

@Injectable({
  providedIn: 'root'
})
export class VatRateService {

  constructor(private httpClient: HttpClient) { }
  path = Settings.ApiBaseUrl;
  getVatRates(): Observable<VatRateListModel[]> {
    return this.httpClient.get<VatRateListModel[]>(this.path + "vatrates/getvatrates");
  }

  getVateRateById(id: number): Observable<VatRateListModel> {
    return this.httpClient.get<VatRateListModel>(this.path + "vatrates/detail/" + id);
  }


  add(vatrate: VatRate): Observable<any> {
    return this.httpClient.post(this.path + 'vatrates/add', vatrate, { observe: 'response' });
  }

  update(vatrate: VatRate): Observable<any> {
    return this.httpClient.put(this.path + 'vatrates/update', vatrate, { observe: 'response' });
  }

  delete(vatrate: VatRate): Observable<any> {
    return this.httpClient.delete(this.path + 'vatrates/delete/' + vatrate["id"], { observe: 'response' });
  }

  deleteselected(ids: Number[]): Observable<any> {
    return this.httpClient.post(this.path + 'vatrates/deleteselected', ids, { observe: 'response' });
  }

}
