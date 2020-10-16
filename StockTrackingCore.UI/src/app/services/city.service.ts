import { Injectable } from '@angular/core';
import { Settings } from '../helpers/Settings';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { City } from '../models/city';

@Injectable({
  providedIn: 'root'
})
export class CityService {

constructor(private httpClient: HttpClient) { }
path = Settings.ApiBaseUrl;
getCities(): Observable<City[]> {
  return this.httpClient.get<City[]>(this.path + "cities/getcities");
}

add(city): Observable<any> {
  return  this.httpClient.post(this.path + 'cities/add',city,{ observe: 'response' });
 }

 update(city): Observable<any> {
  return  this.httpClient.put(this.path + 'cities/update',city,{ observe: 'response' });
 }

 delete(city): Observable<any> {
  return  this.httpClient.delete(this.path + 'cities/delete/'+city["id"],{ observe: 'response' });
 }

 deleteselected(ids): Observable<any> {
  return  this.httpClient.post(this.path + 'cities/deleteselected' ,ids,{ observe: 'response' });
 }
}








