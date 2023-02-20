<template>
    <div>
      <h1>Products </h1>
      <div class="products">
        <div  class="product" v-for="(item, id) in state.user"  :key="id">
           
          <img :src="item.imageUrl" :alt="item.description"/> 
          <h3>{{ item.name}}</h3> 
          <div class="price">${{item.price.toFixed(2)}}</div>
       
      </div>
</div>
    </div>  
  </template>
  
  <script setup>
  import { reactive, onMounted } from 'vue'
    import $ from 'jquery'

    const state = reactive({ 
      user: [],
    })


  onMounted(() => {
      $.ajax({
        url: 'https://localhost:44310/api/Products',
        method: 'get'
      }).done(data => {
        state.user = data;
        console.log(state.user);
      })    
    })
  
  </script>
  
  <!-- Add "scoped" attribute to limit CSS to this component only -->
  <style scoped>
  div.products{
    display:flex;
    flex-wrap:wrap;
    width: 100%;
    justify-content:center ;
    margin: 50px 0;
  }
  img{
    width: 200px;
    height: 200px;
    text-align: center;
    margin: 0 auto;
    display:block;
  }
  .product{
    width: 20%;
    /* height: 5%; */
    margin:15px;
    box-sizing: border-box;
    float:left;
    border-radius:20px;
    box-shadow: 0 14px 28px rgba(0,0,0,0.25);
    background: #f2f2f2;
    cursor: pointer;
    
  }

  .product:hover {
    outline: .1rem solid blue
  }

  </style>
  