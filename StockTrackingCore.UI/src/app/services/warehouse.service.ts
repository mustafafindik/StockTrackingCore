import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Settings } from '../helpers/Settings';
import { WarehouseListModel } from '../models/Warehouse/WarehouseListModel';

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {
  
  constructor(private httpClient: HttpClient) { }
  path = Settings.ApiBaseUrl;

  getWarehouses(): Observable<WarehouseListModel[]> {
    return this.httpClient.get<WarehouseListModel[]>(this.path + "warehouses/getwarehouses");
  }

}
