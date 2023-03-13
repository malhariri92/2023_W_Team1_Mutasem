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
                    "cvc": "",
                    "exprDate": null 
                },
        }
        this.subtotal = 0.00,
        this.tax = 0.00,
        this.total = 0.00,
        this.lineItems = [],
        this.status = ""
    }
}