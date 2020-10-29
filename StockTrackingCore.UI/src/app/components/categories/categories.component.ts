import { SelectionModel } from '@angular/cdk/collections';
import { FlatTreeControl, NestedTreeControl } from '@angular/cdk/tree';
import { Component, Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { Title } from '@angular/platform-browser';
import { CategoryListModel } from 'src/app/models/Category/CategoryListModel';
import { CategoryService } from 'src/app/services/category.service';
import { CategoriesDialogComponent } from './categories-dialog/categories-dialog.component';


/** Flat node with expandable and level information */
interface ExampleFlatNode {
  expandable: boolean;
  emptyMain: boolean;
  categoryName: string;
  id: number;
  parentCategoryid: number;
  level: number;
}

const categoryDATA: CategoryListModel[] = [
  {
    id: 1,
    categoryName: 'Alkolsüz İçecekler',
    subCategories: [
      { id: 1, parentCategoryId: 1, categoryName: 'Gazlı İçecekler' },
      { id: 2, parentCategoryId: 1, categoryName: 'Meyve Suları' },

    ]
  }, {
    id: 2,
    categoryName: 'Atıştırmalık Gıdalar',
    subCategories: [
      { id: 3, parentCategoryId: 2, categoryName: 'Dondurmalar', },
      { id: 4, parentCategoryId: 2, categoryName: 'Şekerlemeler' },
      { id: 5, parentCategoryId: 2, categoryName: 'Sağlıklı Atıştırmalıklar' },
    ]
  },
];

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent {

  private _transformer = (node: CategoryListModel, level: number) => {
    return {
      expandable: !!node.subCategories && node.subCategories.length > 0,
      emptyMain: (node.subCategories && node.subCategories.length === 0) && node.parentCategoryId === undefined,
      categoryName: node.categoryName,
      id: node.id,
      parentCategoryid: node.parentCategoryId,
      level: level,
    };
  }

  expandedNodes: ExampleFlatNode[];
  treeControl = new FlatTreeControl<ExampleFlatNode>(node => node.level, node => node.expandable);
  treeFlattener = new MatTreeFlattener(this._transformer, node => node.level, node => node.expandable, node => node.subCategories);
  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

  constructor(private titleService: Title, private categoryService: CategoryService, public dialog: MatDialog, private _snackBar: MatSnackBar) {
    this.titleService.setTitle("Kategoriler");
    this.loadData();

  }

  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;
  hasEmptyMain = (_: number, node: ExampleFlatNode) => node.emptyMain;


  loadData() {
    this.categoryService.getCategories().subscribe(data => {
      this.dataSource.data = data;
      console.log(data)
    });


  }

  refreshTreeData() {
    const data = this.dataSource.data;
    this.dataSource.data = data;

  }

  openDialog(action, obj) {
    this.saveExpandedNodes();
    console.log(action);
    console.log(obj);

    obj.action = action;
    const dialogRef = this.dialog.open(CategoriesDialogComponent, {
      data: obj
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      if (result.event == 'Kategori Ekle') {
        this.addCategoryNode(result);

      }

    });

  }


  addCategoryNode(result: any) {
    console.log(result.data);
    this.categoryService.addCategory(result.data).subscribe(data => {
      console.log(data.status);
      console.log(data.body);
      const node: CategoryListModel = {
        id: data.body.id,
        categoryName: data.body.categoryName,
        parentCategoryId: undefined,
        subCategories: []
      };
      this._snackBar.open(data.body.categoryName + " Başarıyla Eklendi.", "Tamam", { duration: 5000, });
      this.dataSource.data.push(node);
      this.refreshTreeData();
      this.restoreExpandedNodes();
    }, error => {
      console.log(error.status);
      console.log(error.error);
      this._snackBar.open("Hata : " + error.error, "Tamam", { duration: 8000, });
      this.restoreExpandedNodes();
    });
   
  }




  saveExpandedNodes() {
    this.expandedNodes = new Array<ExampleFlatNode>();
    this.treeControl.dataNodes.forEach(node => {
      if (node.expandable && this.treeControl.isExpanded(node)) {
        this.expandedNodes.push(node);
      }
    });
    console.log(this.expandedNodes);
  }

  restoreExpandedNodes() {
    this.expandedNodes.forEach(node => {
      console.log(node.id);
      console.log((this.treeControl.dataNodes.find(n => n.id === node.id)));
      this.treeControl.expand(this.treeControl.dataNodes.find(n => n.id === node.id));
    });
  }

}
