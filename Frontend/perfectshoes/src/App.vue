<template>
  <div>
    <nav>
  <div class="nav nav-tabs" id="nav-tab" role="tablist">
    <a class="nav-item nav-link" id="nav-home-tab" data-toggle="tab" @click="doRoute('home')"
     role="tab" aria-controls="nav-home" aria-selected="true">Home</a>
    <a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" @click="doRoute('hello')"
     role="tab" aria-controls="nav-profile" aria-selected="false">HelloWorld</a>
     <a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" @click="doRoute('products')"
     role="tab" aria-controls="nav-profile" aria-selected="false">Products</a>
     <a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" @click="doRoute('cart')"
     role="tab" aria-controls="nav-profile" aria-selected="false">ShoppingCart</a>
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
  case 'cart':
    router.push('/cart');
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
  margin-top: 60px;
}
a {
  cursor: pointer;
}

</style>
