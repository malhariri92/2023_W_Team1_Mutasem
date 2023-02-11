<template>
  <div>
  <img alt="Vue logo" src="./assets/images/logo.png">
  <HelloWorld msg="Welcome to Your Vue.js App" :count="state.count"/> <br/> <br/>

  <button @click="increment">
    {{ state.count }}
  </button><br/> <br/>
  <p>{{ state.customer.address }}</p>
  <p>{{ state.address.addressLine1 }}</p>

  <h3>Using Router</h3>
  <button @click="doRoute('home')">Home</button><br/><br/>
  <button @click="doRoute('hello')">Hello World</button>
</div>
</template>

<script setup>
import HelloWorld from './components/HelloWorld.vue'
import { reactive } from 'vue'
import { useRouter } from 'vue-router';
import $ from 'jquery'

const state = reactive({ count: 0,
  components: { HelloWorld },
  customer: {},
  address: {}
})

function increment() {
  state.count++
  $.ajax({
    url: 'https://localhost:44310/WeatherForecast?Id=2',
    method: 'get'
  }).done(function (data) {
    state.customer = data;
    state.address = data.address;
    console.log(state.customer);
  })
}

const router = useRouter();
function doRoute(whereTo) {
 switch(whereTo) {
  case 'home':
    router.push('/home');
    break;
  case 'hello':
    router.push('/hello');
    break;
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
</style>
