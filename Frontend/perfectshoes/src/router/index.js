import { createRouter, createWebHistory } from 'vue-router';
import HelloWorld from '../components/HelloWorld.vue';
import HomePage from '../components/HomePage.vue';
import ProductsPage from '../components/ProductsPage.vue';
import AddProduct from '../components/AddProduct.vue';
import TestDialog from '../components/TestDialog.vue';

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
        path: '/add',
        name: 'AddProduct',
        component: AddProduct
    },
    {
        path: '/test',
        name: 'TestDialog',
        component: TestDialog 
    }
]
const router = createRouter({
    history: createWebHistory(),
    routes
  })
  
  export default router