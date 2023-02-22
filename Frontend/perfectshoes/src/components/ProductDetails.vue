<template>
  <div class = "productDetails">
    <div class= "productName">
      <h3>Product Name </h3>
      {{productName}}
    </div>
    <div class= "productImage">
      <h3>Product Image </h3>
    {{productImage}}
    </div>
    <div class= "productPrice">
      <h3>Product Price </h3>
       ${{productPrice}}
    </div>
    <div class= "productOptions">
      <h3>Product Options </h3>
    The Options for this product are {{productOptions}}
    </div>
    <div class= "productDescription">
      <h3>Product Description </h3>
    The Description is {{productDesc}}
    </div>
  </div>  
</template>

<script setup>
import { defineProps, onMounted } from 'vue'

const props = defineProps(['productName', 'productImage', 'productPrice', 'productOptions', 'productDesc']);
 
onMounted(() => {
  console.log(props);
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
