import { reactive } from 'vue';
import $ from 'jquery'

const user = reactive({});
const products = reactive([]);

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
    }
    
};

export default {
 user,
 methods,
 products
}
