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



}


