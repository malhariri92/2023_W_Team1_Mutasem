import { createRouter, createWebHistory } from 'vue-router';
import HelloWorld from '../components/HelloWorld.vue';
import HomePage from '../components/HomePage.vue'

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
    }
]
const router = createRouter({
    history: createWebHistory(),
    routes
  })
  
  export default router