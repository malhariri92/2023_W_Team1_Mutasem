import { reactive } from 'vue';
import $ from 'jquery';

const userState = reactive({
    user: JSON.parse(sessionStorage.getItem('user')),
});
const categories = reactive([]);
const products = reactive([]);
const currentProduct = reactive({});
const cart = reactive({ order: null});
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
            methods: 'get',
            success: (data) => {
                userState.user = data;
                sessionStorage.setItem('user', JSON.stringify(userState.user));
                console.log(userState.user);
            },
            error: (jqXHR) => {
                if(jqXHR.status == 404)
                userState.user = null;
            }
        });
    },
    setCurrentProduct(product) {
        currentProduct.value = product;
        console.log(currentProduct.value)
    },
    logout()
    {
        userState.user = null;
        sessionStorage.removeItem('user');
    },
    loadCategories() {
        $.ajax({
            url: 'https://localhost:44310/api/categories',
            method: 'get'
          }).done(data => {
            console.log(data);
            categories.value = data;
            console.log(categories);
          })
    }
};

export default {
 userState,
 methods,
 products,
 currentProduct,
 cart,
 categories
}
