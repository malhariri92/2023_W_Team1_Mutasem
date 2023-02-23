<template>
  <div>
    <nav>
      <div class="nav nav-tabs justify-content-end" role="tablist">
        <a class="nav-item nav-link" data-toggle="tab" @click="doRoute('home')"
        role="tab">Home</a>
        <a class="nav-item nav-link" data-toggle="tab" @click="doRoute('hello')"
        role="tab">HelloWorld</a>
        <a class="nav-item nav-link" data-toggle="tab" @click="doRoute('products')"
        role="tab">Products</a>
        <a class="nav-item nav-link" data-toggle="tab" @click="doRoute('inventory')"
        role="tab">Inventory</a>
        <a class="nav-item nav-link" data-toggle="tab" @click="doRoute('add')"
        role="tab">Add Product</a>
        <a class="nav-item nav-link" data-toggle="tab" @click="doRoute('test')"
        role="tab">Test</a>
        <a class="nav-item nav-link " title="Log In" data-toggle="tab tooltip" @click="doRoute('login')"
        role="tab"><font-awesome-icon id="cart" icon="fa-solid fa-user" size="2x" /></a>
        <a class="nav-item nav-link" title="Shopping Cart" data-toggle="tab tooltip" @click="doRoute('test')"
        role="tab"><font-awesome-icon id="cart" icon="fa-solid fa-cart-shopping" size="2x" /></a>
      </div>
    </nav>
    <router-view/>
     
  </div>
</template>

<script setup>
import { useRouter } from 'vue-router';
import { provide } from 'vue';
import store from '@/store';

provide('store', store);

const router = useRouter();
function doRoute(whereTo) {
 switch(whereTo) {
  case 'home':
    router.push('/home');
    break;
  case 'hello':
    router.push('/hello');
    break;
  case 'products':
    router.push('/products');
    break;
    case 'productDetails':
    router.push('/productDetails');
    break;
  case 'add':
    router.push('/add');
    break;
  case 'test':
    router.push('/test');
    break;
  case 'login':
    router.push('/login');
    break;
    case 'inventory':
    router.push('/inventory');
    break;
  default:
    router.push('/');
 }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 40px;
}
a {
  cursor: pointer;
}
.p-dialog-title {
  margin: 0 auto;
}

</style>
