import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Settings } from '../helpers/Settings';
import { WarehouseDetailModel } from '../models/Warehouse/WarehouseDetailModel';
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

  getWarehouseById(id): Observable<WarehouseDetailModel> {
    return this.httpClient.get<WarehouseDetailModel>(this.path + "warehouses/detail/"+id);
  }
  
  
  add(Warehouse): Observable<any> {
    return  this.httpClient.post(this.path + 'warehouses/add',Warehouse,{ observe: 'response' });
   }
  
   update(Warehouse): Observable<any> {
    return  this.httpClient.put(this.path + 'warehouses/update',Warehouse,{ observe: 'response' });
   }
  
   delete(Warehouse): Observable<any> {
    return  this.httpClient.delete(this.path + 'warehouses/delete/'+Warehouse["id"],{ observe: 'response' });
   }
  
   deleteselected(ids): Observable<any> {
    return  this.httpClient.post(this.path + 'warehouses/deleteselected' ,ids,{ observe: 'response' });
   }

}
