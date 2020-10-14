import { SelectionModel } from '@angular/cdk/collections';
import {AfterViewInit, Component,OnInit, ViewChild} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { MyDialogComponent } from 'src/app/extensions/dialog/Mydialog.component';
import { City } from 'src/app/models/city';
import { CityService } from 'src/app/services/city.service';
 
 


export interface DialogData {
  animal: string;
  name: string;
}

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent  implements OnInit{
 
 
  dataSource = new MatTableDataSource<City>();
  constructor(private titleService: Title,private cityService: CityService,public dialog: MatDialog,private _snackBar: MatSnackBar) {    
  }
  ngOnInit(): void {
    this.titleService.setTitle("Şehirler");
    this.cityService.getCities().subscribe(data => {  
      this.dataSource = new MatTableDataSource<City>(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      this.dataSource.filterPredicate = (data:{ cityName: string}, filterValue: string) => data.cityName.toLowerCase().indexOf(filterValue.toLowerCase()) !== -1;
    });
  }
  
    displayedColumns = ['select', 'id', 'cityName',"actions"];
    selection = new SelectionModel<City>(true, []);

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

     /** Whether the number of selected elements matches the total number of rows. */
     isAllSelected() {
      const numSelected = this.selection.selected.length;
      const numRows = this.dataSource.data.length;
      return numSelected === numRows;
    }
  
    /** Selects all rows if they are not all selected; otherwise clear selection. */
   
    masterToggle() {
      this.isAllSelected() ?
      this.selection.clear() : this.dataSource.data.length
      this.dataSource.data.forEach(row => this.selection.select(row));
    }
    
  
    applyFilter(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
     
      this.dataSource.filter = filterValue.trim().toLowerCase();
  
      if (this.dataSource.paginator) {
        this.dataSource.paginator.firstPage();
      }
    }

    
    openDialog(): void {
      const dialogRef = this.dialog.open(MyDialogComponent, {
        data: {Title: "Ürün Sil"}
      });
       
      dialogRef.afterClosed().subscribe(result => {
        this._snackBar.open("Silme Kapatıldı.", "Tamam", {duration: 2000,});
        this.selection.selected.forEach(function (value) {
          console.log(value.id);
        }); 

        console.log(result);
      });
      
    }

}

 
export interface DataDialog {
  Title: string;
}
   
 


 