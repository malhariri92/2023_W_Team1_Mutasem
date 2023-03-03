<template>
  <div>
    <nav>
      <div class="nav nav-tabs justify-content-end mb-4" role="tablist">
        <a class="nav-item nav-link" data-toggle="tab" @click="doRoute('products')"
        role="tab">Shop</a>
        <a class="nav-item nav-link" data-toggle="tab" @click="doRoute('inventory')"
        role="tab">Inventory</a>
        <a class="nav-item nav-link" title="Shopping Cart" data-toggle="tab tooltip" @click="doRoute('cart')"
        role="tab"><font-awesome-icon id="cart" icon="fa-solid fa-cart-shopping" size="2x" /></a>
        <a v-if="store.userState.user === null" class="nav-item nav-link " data-toggle="tab tooltip" @click="doRoute('login')"
        role="tab"><font-awesome-icon id="cart" icon="fa-solid fa-user" size="2x" /></a>
        <a v-if="store.userState.user !== null" class="nav-item nav-link "
         data-toggle="tab tooltip" @click="logout()"
        role="tab"><font-awesome-icon id="cart" icon="fa-solid fa-sign-out" size="2x" /></a>
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
    router.push('/');
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
  case 'cart':
    router.push('/cart');
    break;
  default:
    router.push('/');
 }
}

function logout() {
  store.methods.logout()
  doRoute('login')
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
.p-speeddial {
    position: relative !important; 
}
.p-speeddial-button.p-button {
  margin-top: 5px;
  width: 50px !important;
  height: 50px !important;
}
#cart {
  width: 50%;
  margin: 0 auto;
}

</style>
