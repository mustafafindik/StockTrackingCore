import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef,MAT_DIALOG_DATA  } from '@angular/material/dialog';

export interface DataDialog {
  Title: string;
}

@Component({
  selector: 'app-mydialog',
  templateUrl: './mydialog.component.html',
  styleUrls: ['./mydialog.component.css']
})
export class MyDialogComponent{

   
  constructor(
    public dialogRef: MatDialogRef<MyDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DataDialog) {
      console.log(data);
    }

  onNoClick(): void {
    this.dialogRef.close("No");
  }

  onYesClick(): void {
    this.dialogRef.close("yes");
  }
  
}
