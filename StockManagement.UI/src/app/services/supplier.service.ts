import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Settings } from '../helpers/Settings';
import { Supplier } from '../models/Supplier/Supplier';
import { SupplierDetailModel } from '../models/Supplier/SupplierDetailModel';
import { SupplierListModel } from '../models/Supplier/SupplierListModel';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  constructor(private httpClient: HttpClient) { }
  path = Settings.ApiBaseUrl;
  getSuppliers(): Observable<SupplierListModel[]> {
    return this.httpClient.get<SupplierListModel[]>(this.path + "suppliers/getsuppliers");
  }

  getSupplierById(supplierId: number): Observable<SupplierDetailModel> {
    return this.httpClient.get<SupplierDetailModel>(this.path + "suppliers/detail/" + supplierId);
  }


  add(supplier: Supplier): Observable<any> {
    return this.httpClient.post(this.path + 'suppliers/add', supplier, { observe: 'response' });
  }

  update(supplier: Supplier): Observable<any> {
    return this.httpClient.put(this.path + 'suppliers/update', supplier, { observe: 'response' });
  }

  delete(supplier: Supplier): Observable<any> {
    return this.httpClient.delete(this.path + 'suppliers/delete/' + supplier["id"], { observe: 'response' });
  }

  deleteselected(ids: Number[]): Observable<any> {
    return this.httpClient.post(this.path + 'suppliers/deleteselected', ids, { observe: 'response' });
  }
}


