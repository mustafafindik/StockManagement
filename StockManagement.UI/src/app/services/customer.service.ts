import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Settings } from '../helpers/Settings';
import { Customer } from '../models/Customer/Customer';
import { CustomerDetailModel } from '../models/Customer/CustomerDetailModel';
import { CustomerListModel } from '../models/Customer/CustomerListModel';
import { Supplier } from '../models/Supplier/Supplier';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private httpClient: HttpClient) { }
  path = Settings.ApiBaseUrl;
  getCustomers(): Observable<CustomerListModel[]> {
    return this.httpClient.get<CustomerListModel[]>(this.path + "customers/getcustomers");
  }

  getCustomerById(customerId: number): Observable<CustomerDetailModel> {
    return this.httpClient.get<CustomerDetailModel>(this.path + "customers/detail/" + customerId);
  }


  add(customer: Customer): Observable<any> {
    return this.httpClient.post(this.path + 'customers/add', customer, { observe: 'response' });
  }

  update(customer: Customer): Observable<any> {
    return this.httpClient.put(this.path + 'customers/update', customer, { observe: 'response' });
  }

  delete(customer: Customer): Observable<any> {
    return this.httpClient.delete(this.path + 'customers/delete/' + customer["id"], { observe: 'response' });
  }

  deleteselected(ids: Number[]): Observable<any> {
    return this.httpClient.post(this.path + 'customers/deleteselected', ids, { observe: 'response' });
  }
}