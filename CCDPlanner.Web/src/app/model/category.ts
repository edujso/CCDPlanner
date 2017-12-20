export class Category {
    constructor(
      public budgetCategoryId: string,
      public description: string,
      public parentCategoryId: boolean,
      public parentCategory: Category,
      public childrenCategories: Category[],
      public expanded: boolean = false,
      public checked: boolean = false,
    ) { }
}
