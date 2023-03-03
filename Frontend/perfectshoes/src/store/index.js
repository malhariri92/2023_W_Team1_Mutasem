import { reactive } from 'vue';
import $ from 'jquery';

const userState = reactive({
    user: JSON.parse(sessionStorage.getItem('user')),
});
const categories = reactive([]);
const products = reactive([]);
const currentProduct = reactive({});
const cart = reactive({ order: JSON.parse(sessionStorage.getItem('order'))});
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
            categories.value = data;
          })
    },
    persistCart() {
        sessionStorage.setItem('order', JSON.stringify(cart.order));
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
