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
    async login(email, password) {
        await $.ajax({
            url: 'https://localhost:44310/api/Employee?email=' + email + '&password=' + password,
            methods: 'get'}).then((data) => {
                console.log(data);
                user.value = data;
            }).catch((error) => {
                user.value = {};
                console.log(error);
            })
    },
    setCurrentProduct(product) {
        currentProduct.value = product;
        console.log(currentProduct.value)
    },
    logout() {
        user.value = {};
    }
};

export default {
 user,
 methods,
 products,
 currentProduct
}
