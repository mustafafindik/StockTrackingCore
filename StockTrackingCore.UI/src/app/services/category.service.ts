import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Settings } from '../helpers/Settings';
import { CategoryListModel } from '../models/Category/CategoryListModel';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpClient: HttpClient) { }
  path = Settings.ApiBaseUrl;
  getCategories(): Observable<CategoryListModel[]> {
    return this.httpClient.get<CategoryListModel[]>(this.path + "categories/getcategories");
  }

  

}
