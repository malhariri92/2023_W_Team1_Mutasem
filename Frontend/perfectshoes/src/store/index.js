import { reactive } from 'vue';
import $ from 'jquery';

const userState = reactive({
    user: JSON.parse(sessionStorage.getItem('user')),
});
let isLoggingInAndCheckingOut = false;
const categories = reactive([]);
const products = reactive([]);
const currentProduct = reactive({});
const orders = reactive([]);
const cart = reactive({ order: JSON.parse(sessionStorage.getItem('order'))});
const  usStates = ['AL','AK','AS','AZ','AR','CA','CO','CT','DE','DC','FM','FL','GA','GU','HI','ID','IL','IN','IA',
    'KS','KY','LA','ME','MH','MD','MA','MI','MN','MS','MO','MT','NE','NV','NH','NJ','NM','NY','NC','ND','MP','OH',
    'OK','OR','PW','PA','PR','RI','SC','SD','TN','TX','UT','VT','VI','VA','WA','WV', 'WI','WY'
];
const methods = {
    async loadProducts() {
        await $.ajax({
            url: 'https://localhost:44310/api/Products',
            method: 'get'
        }).done(data => {
            products.value = data;
        })    
    },

    async loadOrders() {
        await $.ajax({
            url: 'https://localhost:44310/api/Order',
            method: 'get'
        }).done(data => {
            orders.value = data;
        })
    },

    async login(email, password) {
        isLoggingInAndCheckingOut = true;
        await $.ajax({
            headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
                },
            url: 'https://localhost:44310/api/Users',
            type: 'post',
            data: JSON.stringify({Email: email, Password: password}),
            success: (data) => {
                userState.user = data;
                sessionStorage.setItem('user', JSON.stringify(userState.user));
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
        isLoggingInAndCheckingOut = false;
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
          });
    },
    persistCart() {
        sessionStorage.setItem('order', JSON.stringify(cart.order));
    },
};

export default {
 userState,
 methods,
 products,
 orders,
 currentProduct,
 cart,
 categories,
 isLoggingInAndCheckingOut,
 usStates
}
