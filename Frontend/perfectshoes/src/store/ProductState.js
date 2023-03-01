export default class ProductState {
        constructor() {
            this.specs = [],
            this.categories = [],
            this.categoryId= "",
            this.price= '',
            this.qty= '',
            this.product=
                {
                "id": 0,    
                "name": "",
                "description": "",
                "price": 0.00,
                "categoryId": 0,
                "imageUrl": "",
                "specs": [],
                "isActive": true,
                "quantity": 0
            }
        }
}