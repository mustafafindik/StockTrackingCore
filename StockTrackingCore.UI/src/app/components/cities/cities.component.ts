import { SelectionModel } from '@angular/cdk/collections';
import {AfterViewInit, Component,Inject,OnInit, ViewChild} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { title } from 'process';
import { MyDialogComponent } from 'src/app/extensions/dialog/Mydialog.component';
import { City } from 'src/app/models/city';
import { DataDialog } from 'src/app/models/DataDialog';
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
      this.dataSource.filterPredicate = (data:{ cityName: string}, filterValue: string) => data.cityName.toLocaleLowerCase().indexOf(filterValue.toLocaleLowerCase()) !== -1;
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
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));
    }
    
  
    applyFilter(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
     
      this.dataSource.filter = filterValue.trim().toLocaleLowerCase();
  
      if (this.dataSource.paginator) {
        this.dataSource.paginator.firstPage();
      }
    }

    
    deleteCities(): void {
      const selectedIds:Number[] = [];
      const dialogRef = this.dialog.open(MyDialogComponent, {
        data: new DataDialog ( "Ürün Sil" , "Seçili Ürünleri Silmek İstediğinizden Emin Misiniz ? ", "Hayır","Sil")
      });     
      dialogRef.afterClosed().subscribe(result => {
        
        if(result =="Yes" ){
          this.selection.selected.forEach(function (value) {
            selectedIds.push(value.id);
          }); 
          //Silme Gönderme Servis ile Eğğer Ok gelirse
          this._snackBar.open("Silme İşlemi Tamamlandı.", "Tamam", {duration: 2000,});
        }else {
          this._snackBar.open("Silme İşleminden Vazgeçildi.", "Tamam", {duration: 2000,});
        }         
      }); 
    }

    deleteCity(id:number,cityName:string): void {
      const selectedIds:Number[] = [];
      const dialogRef = this.dialog.open(MyDialogComponent, {
        data: new DataDialog ( "Şehir Sil" ,"<strong> " + cityName + "</strong> Şehrini  Silmek İstediğinizden Emin Misiniz ? ", "Hayır","Sil")
      });     
      dialogRef.afterClosed().subscribe(result => {
        
        if(result =="Yes" ){
          this.selection.selected.forEach(function (value) {
            selectedIds.push(value.id);
          }); 
          //Silme Gönderme Servis ile Eğğer Ok gelirse
          this._snackBar.open("Silme İşlemi Tamamlandı.", "Tamam", {duration: 2000,});
        }else {
          this._snackBar.open("Silme İşleminden Vazgeçildi.", "Tamam", {duration: 2000,});
        }         
      }); 
    }

}
 
 


 