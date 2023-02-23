import { createRouter, createWebHistory } from 'vue-router';
import HelloWorld from '../components/HelloWorld.vue';
import HomePage from '../components/HomePage.vue';
import ProductsPage from '../components/ProductsPage.vue';
import ShoppingCart from '../components/ShoppingCart.vue';

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
        path: '/cart',
        name: 'ShoppingCart',
        component: ShoppingCart
    }
    
]
const router = createRouter({
    history: createWebHistory(),
    routes
  })
  
  export default router