import { Component, Inject, OnInit, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { City } from 'src/app/models/city';

@Component({
  selector: 'app-cities-dialog',
  templateUrl: './cities-dialog.component.html',
  styleUrls: ['./cities-dialog.component.css']
})
export class CitiesDialogComponent  {

  action:string;
  local_data:any;
  
  
  constructor(
    public dialogRef: MatDialogRef<CitiesDialogComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: City) {
  
    this.local_data = {...data};
    this.action = this.local_data.action;
  
  }

  doAction(){
    this.dialogRef.close({event:this.action,data:this.local_data});
  }

  closeDialog(){
    this.dialogRef.close({event:'Vazgeç'});
  }

 

}
