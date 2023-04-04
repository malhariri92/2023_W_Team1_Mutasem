import { createRouter, createWebHistory } from 'vue-router';
import ProductsPage from '../components/ProductsPage.vue';
import AddProduct from '../components/AddProduct.vue';
import LoginPage from '../components/LoginPage.vue';
import OrdersPage from '../components/OrdersPage.vue';
import ProductDetails from '../components/ProductDetails.vue';
import InventoryPage from '../components/InventoryPage.vue';
import ShoppingCart from '../components/ShoppingCart.vue';
import CheckoutPage from "../components/CheckoutPage.vue";
import CustomerProfile from "../components/CustomerProfile.vue";
import OrdersDetails from "../components/OrdersDetails.vue";

const routes = [
    {
        path: '/',
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
        path: '/login',
        name: 'LoginPage',
        component: LoginPage
    },
    {
        path: '/orders',
        name: 'OrdersPage',
        component: OrdersPage
    },
    {
        path: '/inventory',
        name: 'InventoryPage',
        component: InventoryPage
    },
    {
        path: "/cart",
        name: "ShoppingCart",
        component: ShoppingCart
    },
    {
        path: "/checkout",
        name: "CheckoutPage",
        component: CheckoutPage
    },
    {
        path: "/customer",
        name: "CustomerProfile",
        component: CustomerProfile
    },
    {
        path: "/orderDetails",
        name: "OrderDetails",
        component: OrdersDetails
    }

]
const router = createRouter({
    history: createWebHistory(),
    routes
  })
  
  export default router