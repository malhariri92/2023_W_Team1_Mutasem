<template>
  <div>
    <div class="hello">
      <h1>The home page</h1>
    </div>
    <div>
      <button @click="increment">
        {{ state.count }}
      
      </button><br/> <br/>
      This is count using ref:
      <button @click="incrementrefCount">
        {{ refCount }}
      </button><br/> <br/>
      <input v-model="refCount" type="text">
      <p> local user variable after API call: <strong>{{ state.user.firstName }}</strong></p>
      <p>local user variable after API call: <strong>{{ state.user.email }}</strong></p>

      <p v-for="(item, id) in store.user"  :key="id">The global user first name is: <strong>{{ item.firstName }}</strong>
        the global user last name is: <strong>{{ item.lastName }}</strong>
      </p>
   </div>
   <HelloWorld v-if="state.isVisable" msg="Welcome to Your Vue.js App" :childCount="refCount"/>
  </div>
</template>
  
<script setup>
    import HelloWorld from '@/components/HelloWorld.vue'
    import { reactive, ref, inject, onMounted } from 'vue'
    import $ from 'jquery'

    const store = inject('store');

    const state = reactive({ count: 0,
      components: { HelloWorld },
      user: {},
      email: '',
      isVisable: true
    })
    const refCount = ref(0)

    function increment() {
      state.count++
      
    }
    onMounted(() => {
      $.ajax({
        url: 'https://localhost:44310/WeatherForecast?Id=1',
        method: 'get'
      }).done(data => {
        state.user = data;
        state.email = data.email;
        console.log(state.user);
      })    
    })
    function incrementrefCount() {
      refCount.value++;
    } 
</script>
  
  <!-- Add "scoped" attribute to limit CSS to this component only -->
  <style scoped>
  h1 {
    margin: 40px 0 0;
  }
  </style>
  