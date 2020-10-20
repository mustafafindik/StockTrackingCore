import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { WarehouseListModel } from 'src/app/models/Warehouse/WarehouseListModel';
import { WarehouseService } from 'src/app/services/warehouse.service';

@Component({
  selector: 'app-warehouses',
  templateUrl: './warehouses.component.html',
  styleUrls: ['./warehouses.component.css']
})
export class WarehousesComponent implements OnInit {

  dataSource = new MatTableDataSource<WarehouseListModel>();
  displayedColumns = ['select', 'id', 'warehouseName','address','city',"actions"];
  selection = new SelectionModel<WarehouseListModel>(true, []);


  @ViewChild(MatPaginator ) paginator: MatPaginator;
  @ViewChild(MatSort   ) sort: MatSort;
  
  constructor(private titleService: Title,private warehouseservice: WarehouseService,public dialog: MatDialog,private _snackBar: MatSnackBar) {}
  
  ngOnInit(): void {
    this.titleService.setTitle("Depolar");
    this.LoadData();
  }

  LoadData() {
    this.warehouseservice.getWarehouses().subscribe(data => {  
      this.dataSource = new MatTableDataSource<WarehouseListModel>(data);
      console.log(data);
      this.dataSource.paginator = this.paginator;    
      setTimeout(() => this.dataSource.sort = this.sort);   
      this.dataSource.filterPredicate = (data:{ warehouseName: string}, filterValue: string) => data.warehouseName.toLocaleLowerCase().indexOf(filterValue.toLocaleLowerCase()) !== -1;
      this.selection.clear();
    });
  }
  

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


    actions(action,obj){
     
    }
  
    deleteCities(): void {
 
    }


}
