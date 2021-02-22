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
  subCategories: CategoryListModel[]
}

const categoryDATA: CategoryListModel[] = [
  {
    id: 1,
    categoryName: 'Alkolsüz İçecekler',
    subCategories: [
      { id: 1, parentCategoryid: 1, categoryName: 'Gazlı İçecekler' },
      { id: 2, parentCategoryid: 1, categoryName: 'Meyve Suları' },

    ]
  }, {
    id: 2,
    categoryName: 'Atıştırmalık Gıdalar',
    subCategories: [
      { id: 3, parentCategoryid: 2, categoryName: 'Dondurmalar', },
      { id: 4, parentCategoryid: 2, categoryName: 'Şekerlemeler' },
      { id: 5, parentCategoryid: 2, categoryName: 'Sağlıklı Atıştırmalıklar' },
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
      emptyMain: (node.subCategories && node.subCategories.length === 0) && node.parentCategoryid === undefined,
      categoryName: node.categoryName,
      id: node.id,
      parentCategoryid: node.parentCategoryid,
      level: level,
      subCategories: node.subCategories
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
    var node: CategoryListModel = obj;
    obj.action = action;
    const dialogRef = this.dialog.open(CategoriesDialogComponent, {
      data: obj
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      if (result.event == 'Kategori Ekle') {
        this.addCategoryNode(result);
      } else if (result.event === 'Kategori Düzenle') {
        this.updateCategoryNode(result, node)
      } else if (result.event === "Kategori Sil") {
        this.deleteCategoryNode(result, node)
      } else if (result.event === "Alt Kategori Ekle") {
        this.addSubCategoryNode(result, node);
      } else if (result.event === "Alt Kategori Düzenle") {
        this.updateSubCategoryNode(result, node);
      } else if (result.event === "Alt Kategori Sil") {
        this.deleteSubCategoryNode(result, node);
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
        parentCategoryid: undefined,
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

  updateCategoryNode(result: any, node: CategoryListModel) {
    console.log(result.data);
    delete result.data["subCategories"]
    var position = this.findMainPosition(node.id, this.dataSource.data)
    console.log(position)
    this.categoryService.updateCategory(result.data).subscribe(data => {
      console.log(data.status);
      console.log(data.body);
      const editedCategory: CategoryListModel = {
        id: node.id,
        categoryName: data.body.categoryName,
        parentCategoryid: node.parentCategoryid,
        subCategories: node.subCategories
      };
      this._snackBar.open(data.body.categoryName + " Başarıyla Düzenlendi.", "Tamam", { duration: 5000, });
      this.dataSource.data[position] = editedCategory;
      this.refreshTreeData();
      this.restoreExpandedNodes();
    }, error => {
      console.log(error.status);
      console.log(error.error);
      this._snackBar.open("Hata : " + error.error, "Tamam", { duration: 8000, });
      this.restoreExpandedNodes();
    });

  }

  deleteCategoryNode(result: any, node: CategoryListModel) {
    console.log(result.data);
    var position = this.findMainPosition(node.id, this.dataSource.data)
    console.log(position);
    this.categoryService.deleteCategory(result.data).subscribe(data => {
      console.log(data.status);
      console.log(data.body);

      this._snackBar.open(data.body.categoryName + " Başarıyla Silindi.", "Tamam", { duration: 5000, });
      delete this.dataSource.data[position];
      this.refreshTreeData();
      this.restoreExpandedNodes();
    }, error => {
      console.log(error.status);
      console.log(error.error);
      this._snackBar.open("Hata : " + error.error, "Tamam", { duration: 8000, });
      this.restoreExpandedNodes();
    });

  }

  addSubCategoryNode(result: any, node: CategoryListModel) {
    var position = this.findMainPosition(node.id, this.dataSource.data)
    result.data["CategoryId"] = result.data["id"];
    result.data["SubCategoryName"] = result.data["categoryName"];
    delete result.data["parentCategoryid"];
    delete result.data["categoryName"];
    delete result.data["id"];
    console.log(result.data);

    this.categoryService.addSubCategory(result.data).subscribe(data => {
      console.log(data.status);
      console.log(data.body);

      const addData: CategoryListModel = {
        id: data.body.id,
        categoryName: data.body.subCategoryName,
        parentCategoryid: data.body.categoryId,
        subCategories: []
      };
      node.subCategories.push(addData);



      this._snackBar.open(data.body.subCategoryName + " Başarıyla Eklendi.", "Tamam", { duration: 5000, });
      console.log(addData)
      this.dataSource.data[position] = node;
      this.refreshTreeData();
      this.restoreExpandedNodes();
    }, error => {
      console.log(error.status);
      console.log(error.error);
      this._snackBar.open("Hata : " + error.error, "Tamam", { duration: 8000, });
      this.restoreExpandedNodes();
    });

  }

   updateSubCategoryNode(result: any, node: CategoryListModel) {
    var position = this.findMainPosition(node.parentCategoryid, this.dataSource.data)
    var positionChield = this.findsubPosition(node.id,node.parentCategoryid, this.dataSource.data);
    result.data["CategoryId"] = result.data["parentCategoryid"];
    result.data["SubCategoryName"] = result.data["categoryName"];
    delete result.data["parentCategoryid"];
    delete result.data["categoryName"];

    console.log(result.data);
    this.categoryService.updateSubCategory(result.data).subscribe(data => {
      console.log(data.status);
      console.log(data.body);
      node.categoryName = data.body.subCategoryName;  
      var parentNode = this.dataSource.data[position]; 
      parentNode.subCategories[positionChield] = node;
      this._snackBar.open(data.body.subCategoryName + " Başarıyla Düzenlendi.", "Tamam", { duration: 5000, });
      console.log(node)
      this.dataSource.data[position] = parentNode;
      this.refreshTreeData();
      this.restoreExpandedNodes();
    }, error => {
      console.log(error.status);
      console.log(error.error);
      this._snackBar.open("Hata : " + error.error, "Tamam", { duration: 8000, });
      this.restoreExpandedNodes();
    });

  }

  deleteSubCategoryNode(result: any, node: CategoryListModel) {
    var positionChield = this.findsubPosition(node.id,node.parentCategoryid, this.dataSource.data);
    var position = this.findMainPosition(node.parentCategoryid, this.dataSource.data)
    result.data["CategoryId"] = result.data["parentCategoryid"];
    result.data["SubCategoryName"] = result.data["categoryName"];
    delete result.data["parentCategoryid"];
    delete result.data["categoryName"];

    console.log(result.data);
    this.categoryService.deleteSubCategory(result.data).subscribe(data => {
      console.log(data.status);
      console.log(data.body);

      var parentNode = this.dataSource.data[position]; 
      console.log(parentNode);
      delete parentNode.subCategories[positionChield]  
      console.log(parentNode);
      this._snackBar.open(data.body.subCategoryName + " Başarıyla Silindi.", "Tamam", { duration: 5000, });
      this.refreshTreeData();
      this.restoreExpandedNodes();
    }, error => {
      console.log(error.status);
      console.log(error.error);
      this._snackBar.open("Hata : " + error.error, "Tamam", { duration: 8000, });
      this.restoreExpandedNodes();
    });

  }






  // Bir Kategorinin Pozisyonu için
  findMainPosition(id: number, data: CategoryListModel[]) {
    console.log(data);
    for (let i = 0; i < data.length; i += 1) {
      if(data[i] !== undefined){
        if (id === data[i].id) {
          return i;
        }
      }
     
    }
  }

  findsubPosition(id: number,parentid:number, data: CategoryListModel[]) {
    console.log("sub");
    console.log(data);
    console.log(id);
    console.log(parentid);
    var filtered = data.filter(function (el) {
      return el != null;
    });

    for (let i = 0; i < filtered.find(d=>d.id==parentid).subCategories.length; i += 1) {
      if( filtered.find(d=>d.id==parentid) !== undefined){
        if (id === filtered.find(d=>d.id==parentid).subCategories[i].id) {
          return i;
        }
      }
     
    }
  }

  // Açık olan Kategorileri kayıt altında utmak için
  saveExpandedNodes() {
    this.expandedNodes = new Array<ExampleFlatNode>();
    this.treeControl.dataNodes.forEach(node => {
      if (node.expandable && this.treeControl.isExpanded(node)) {
        this.expandedNodes.push(node);
      }
    });
  }


  //Açık olan posisyonları işlem sonrası tekrar açık hale getirmek için
  restoreExpandedNodes() {
    this.expandedNodes.forEach(node => {
      this.treeControl.expand(this.treeControl.dataNodes.find(n => n.id === node.id));
    });
  }

}
