import { reactive } from 'vue';
import $ from 'jquery'

const user = reactive({});
const products = reactive([]);
const currentProduct = reactive({});

const methods = {
    loadProducts() {
        $.ajax({
            url: 'https://localhost:44310/api/Products',
            method: 'get'
        }).done(data => {
            products.value = data;
        })    
    },
    login(email, password) {
        $.ajax({
            url: 'https://localhost:44310/api/Employee?email=' + email + '&password=' + password,
            methods: 'get',
            success: (data) => {
                user.value = data;
            },
            })
    },
    setCurrentProduct(product) {
        currentProduct.value = product;
        console.log(currentProduct.value)
    }
    
};

export default {
 user,
 methods,
 products,
 currentProduct
}
