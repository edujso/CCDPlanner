export class Category {
    constructor(
        public id: number,
        public name: string,
        public hasSubCategories: boolean,
        public isSubCategory: boolean,
        public subCategories: Category[]
    ) { }
}