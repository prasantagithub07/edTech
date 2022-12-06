
import { Guid } from 'guid-typescript';
import { CART_ID } from '../app.constant';

export class Cart{
    id: string;
    items: any;
    total: number;
    tax: number;
    grandTotal: number;
    userId: number = 0;
    createdDate: string | any;
    constructor(){
        this.id="0";
        this.items = [];
        this.total = 0;
        this.grandTotal = 0;
        this.tax = 0;
    }

    getCartId(){
        let id = undefined;
        let cid = localStorage.getItem(CART_ID);
        if(cid ==  undefined){
            id =  Guid.create().toString();
            localStorage.setItem(CART_ID, id);
        }
        else{
            id = cid;
        }
        return id;
    }
}