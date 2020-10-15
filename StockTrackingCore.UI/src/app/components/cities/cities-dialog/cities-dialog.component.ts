import { Component, Inject, OnInit, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { City } from 'src/app/models/city';
import {
  FormGroup,FormControl,Validators, FormBuilder} from "@angular/forms";
@Component({
  selector: 'app-cities-dialog',
  templateUrl: './cities-dialog.component.html',
  styleUrls: ['./cities-dialog.component.css']
})
export class CitiesDialogComponent  {

 
  
  
  constructor(
    public dialogRef: MatDialogRef<CitiesDialogComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: City, private formBuilder: FormBuilder,) {
  
    this.local_data = {...data};
    this.action = this.local_data.action;
    this.createCityForm();
  }

  action:string;
  local_data:any;
  cityAddForm: FormGroup;


  createCityForm() {
    this.cityAddForm = new FormGroup({
      cityName: new FormControl(this.local_data.cityName, [
        Validators.required,      
      ])
    });

  }

  doAction(){
    if(this.cityAddForm.valid){
    this.dialogRef.close({event:this.action,data:this.local_data});
    }else{
      console.log("Not Valid")
    }
  }

  closeDialog(){
    this.dialogRef.close({event:'Vazgeç'});
  }

 

}
