import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { WarehouseListModel } from 'src/app/models/Warehouse/WarehouseListModel';

@Component({
  selector: 'app-warehouse-dialog',
  templateUrl: './warehouse-dialog.component.html',
  styleUrls: ['./warehouse-dialog.component.css']
})
export class WarehouseDialogComponent  {

  constructor(
    public dialogRef: MatDialogRef<WarehouseDialogComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: WarehouseListModel, private formBuilder: FormBuilder,) {
  
    this.local_data = {...data};
    this.action = this.local_data.action;
    this.createForm();
    this.dialogRef.disableClose = true;
  
    
  }


  action:string;
  local_data:any;
  warehouseAddForm: FormGroup;


  createForm() {
    this.warehouseAddForm = new FormGroup({
      warehouseName: new FormControl(this.local_data.warehoseName, [
        Validators.required,      
      ]),
      address: new FormControl(this.local_data.warehoseName, [
        Validators.minLength(10),      
      ]),
      city: new FormControl(this.local_data.warehoseName, [
        Validators.required,      
      ]),
    });

  }

  doAction(){
    if(this.warehouseAddForm.valid){
    this.dialogRef.close({event:this.action,data:this.local_data});
    }else{
      console.log("Not Valid")
    }
  }

  closeDialog(){
    this.dialogRef.close({event:'Vazgeç'});
  }

 

}


