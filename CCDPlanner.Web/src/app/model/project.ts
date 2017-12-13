import { Record } from '../model/record';

export class Project {

    constructor(
        public id: number,
        public name: string,
        public account: string,
        public budget: string,
        public sponsor: string,
        public startDate: Date,
        public endDate: Date,
        public records: Record[]
    ) { }

}