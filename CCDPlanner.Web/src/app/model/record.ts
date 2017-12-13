import { Sponsor } from '../model/sponsor';
import { Category } from '../model/category';

export class Record {

    constructor(
        public id: number,
        public name: string,
        public category: Category,
        public unit: string,
        public numberOfUnits: number,
        public valuePerUnit: number,
        public total: number,
        public sponsors: Sponsor[]        
    ) { }
}