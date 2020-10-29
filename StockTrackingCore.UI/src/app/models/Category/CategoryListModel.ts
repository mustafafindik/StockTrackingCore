export class CategoryListModel {
    id:number;
    categoryName: string;
    parentCategoryId?:number;
    subCategories?: CategoryListModel[];
}
