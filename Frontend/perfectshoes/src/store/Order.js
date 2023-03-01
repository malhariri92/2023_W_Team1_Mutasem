export default class Order {
    constructor() {
        this.customer = {
            "firstName": "",
            "lastName": "",
            "email": "",
            "address": {
                    "addressLine1": "",
                    "addressLine2": "",
                    "city": "",
                    "state": "",
                    "zip": ""
                },
            "creditCard": {
                    "nameOnCard": "",
                    "cardNumber": "",
                    "cvc": "str",
                    "exprDate": "" 
                },
        }
        this.subtotal = 0.00,
        this.tax = 0.00,
        this.total = 0.00,
        this.lineItems = [
            {
                "unitPrice": 89.99,
                "quantity": 1,
                "productId": 0,
                "product": {
                    "id": 0,
                    "name": "Shoe1",
                    "description": "Fancy Shoes",
                    "price": 89.99,
                    "categoryId": 0,
                },
            },
            {
                "unitPrice": 45.99,
                "quantity": 2,
                "productId": 0,
                "product": {
                    "id": 0,
                    "name": "Shoe2",
                    "description": "Crocs",
                    "price": 45.99,
                    "categoryId": 0,
                },
            }
        ]
    }
}