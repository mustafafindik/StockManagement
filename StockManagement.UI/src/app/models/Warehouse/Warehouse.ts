import { City } from '../City/City';

export class Warehouse {
    id:number;
    warehouseName :string;
    address:string;
    cityid:number;
    city : City;
    createDate:Date;
    createdBy:string;
    modifiedBy:string;
    modifiedDate:Date;

}
