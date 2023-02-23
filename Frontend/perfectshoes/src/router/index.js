import { createRouter, createWebHistory } from 'vue-router';
import HelloWorld from '../components/HelloWorld.vue';
import HomePage from '../components/HomePage.vue';
import ProductsPage from '../components/ProductsPage.vue';
import AddProduct from '../components/AddProduct.vue';
import TestDialog from '../components/TestDialog.vue';
import LoginPage from '../components/LoginPage.vue';
import AdminPage from '../components/AdminPage.vue';
import ProductDetails from '../components/ProductDetails.vue';
import InventoryPage from '../components/InventoryPage.vue';


const routes = [
    {
        path: '/hello',
        name: 'HelloWorld',
        component: HelloWorld
    },
    {
        path: '/home',
        name: 'HomePage',
        component: HomePage
    },
    {
        path: '/products',
        name: 'ProductsPage',
        component: ProductsPage
    },
    {
        path: '/productDetails',
        name: 'ProductDetails',
        component: ProductDetails
    },
    {
        path: '/add',
        name: 'AddProduct',
        component: AddProduct
    },
    {
        path: '/test',
        name: 'TestDialog',
        component: TestDialog 
    },
    {
        path: '/login',
        name: 'LoginPage',
        component: LoginPage
    },
    {
        path: '/admin',
        name: 'AdminPage',
        component: AdminPage
    },
    {
        path: '/inventory',
        name: 'InventoryPage',
        component: InventoryPage
    }
]
const router = createRouter({
    history: createWebHistory(),
    routes
  })
  
  export default router