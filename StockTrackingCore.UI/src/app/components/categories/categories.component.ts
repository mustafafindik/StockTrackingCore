import {SelectionModel} from '@angular/cdk/collections';
import {FlatTreeControl, NestedTreeControl} from '@angular/cdk/tree';
import {Component, Injectable} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import {MatTreeFlatDataSource, MatTreeFlattener} from '@angular/material/tree';
import { Title } from '@angular/platform-browser';
import { CategoryListModel } from 'src/app/models/Category/CategoryListModel';
import { CategoryService } from 'src/app/services/category.service';
import { CategoriesDialogComponent } from './categories-dialog/categories-dialog.component';
 

/** Flat node with expandable and level information */
interface ExampleFlatNode {
  expandable: boolean;
  categoryName: string;
  id:number;
  parentCategoryid:number;
  level: number;
}

const categoryDATA: CategoryListModel[] = [
  {
    id:1,
    categoryName: 'Alkolsüz İçecekler',
    subCategories: [
      {id :1, parentCategoryId:1 ,categoryName: 'Gazlı İçecekler'},
      {id :2 ,parentCategoryId:1, categoryName: 'Meyve Suları'},
 
    ]
  }, {
    id:2,
    categoryName: 'Atıştırmalık Gıdalar',
    subCategories: [
      { id :3 ,parentCategoryId:2,categoryName: 'Dondurmalar',}, 
      { id :4 ,parentCategoryId:2,categoryName: 'Şekerlemeler' },
      { id :5 ,parentCategoryId:2,categoryName: 'Sağlıklı Atıştırmalıklar' },
    ]
  },
];

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent  {

  private _transformer = (node: CategoryListModel, level: number) => {
    return {
      expandable: !!node.subCategories && node.subCategories.length > 0,
      categoryName: node.categoryName,
      id:node.id,
      parentCategoryid : node.parentCategoryId,
      level: level,
    };
  }

  treeControl = new FlatTreeControl<ExampleFlatNode>( node => node.level, node => node.expandable);
  treeFlattener = new MatTreeFlattener(this._transformer, node => node.level, node => node.expandable, node => node.subCategories);
  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

  constructor(private titleService: Title,private categoryService: CategoryService,public dialog: MatDialog) {
    this.titleService.setTitle("Kategoriler");
    this.categoryService.getCategories().subscribe(data => {  
      this.dataSource.data = data;
      console.log(data)
    });
   
  }

  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;

  openDialog(action,obj) {
    console.log(action);
    console.log(obj);
    
    obj.action = action;  
    const dialogRef = this.dialog.open(CategoriesDialogComponent,  {             
      data:obj
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
    });
  }



  

 }


