import {Component} from '@angular/core';
import { Title } from '@angular/platform-browser';
 


export interface DialogData {
  animal: string;
  name: string;
}

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent  {
 
  animal: string;
  name: string;

  constructor(private titleService: Title) { 
    this.titleService.setTitle("Şehirler");
  }

  
   

}



 