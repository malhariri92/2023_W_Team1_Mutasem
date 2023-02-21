import { reactive } from 'vue';
import $ from 'jquery'

const user = reactive([{"firstName": "John", "lastName" : "Smith"}, {"firstName": "Jane", "lastName" : "Doe"}]);
const products = reactive([]);

const methods = {
    loadProducts() {
        $.ajax({
            url: 'https://localhost:44310/api/Products',
            method: 'get'
        }).done(data => {
            products.value = data;
        })    
    }
    
};

export default {
 user,
 methods,
 products
}
