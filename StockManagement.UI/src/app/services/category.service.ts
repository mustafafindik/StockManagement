import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Settings } from '../helpers/Settings';
import { Category } from '../models/Category/Category';
import { CategoryListModel } from '../models/Category/CategoryListModel';
import { SubCategory } from '../models/Category/SubCategory';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpClient: HttpClient) { }
  path = Settings.ApiBaseUrl;
  getCategories(): Observable<CategoryListModel[]> {
    return this.httpClient.get<CategoryListModel[]>(this.path + "categories/getcategories");
  }

  addCategory(category: Category): Observable<any> {
    return this.httpClient.post(this.path + 'categories/addCategory', category, { observe: 'response' });
  }

  updateCategory(category: Category): Observable<any> {
    return this.httpClient.put(this.path + 'categories/updateCategory', category, { observe: 'response' });
  }

  deleteCategory(category: Category): Observable<any> {
    return this.httpClient.delete(this.path + 'categories/deleteCategory/' + category["id"], { observe: 'response' });
  }
  addSubCategory(subCategory: SubCategory ): Observable<any> {
    return this.httpClient.post(this.path + 'categories/addSubCategory', subCategory, { observe: 'response' });
  }

  updateSubCategory(subCategory: SubCategory): Observable<any> {
    return this.httpClient.put(this.path + 'categories/updateSubCategory', subCategory, { observe: 'response' });
  }

  deleteSubCategory(csubCategory: SubCategory): Observable<any> {
    return this.httpClient.delete(this.path + 'categories/deleteSubCategory/' + csubCategory["id"], { observe: 'response' });
  }

}
