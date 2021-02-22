export class CategoryListModel {
    id:number;
    categoryName: string;
    parentCategoryid?:number;
    subCategories?: CategoryListModel[] = [];
}
