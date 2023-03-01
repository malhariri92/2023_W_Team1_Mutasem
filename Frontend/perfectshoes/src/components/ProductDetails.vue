<template>
  <div>
    <div class = "productDetails">
      <div class= "productName">
        <h3>Product Name </h3>
        {{ state.product.name }}
      </div>
      <div class= "productImage">
        <h3>Product Image </h3>
      {{ state.product.imageUrl }}
      </div>
      <div class= "productPrice">
        <h3>Product Price </h3>
        ${{ state.product.price }}
      </div>
      <div class= "productOptions" v-if="state.product.specs !== null && state.product.specs.length !== 0">
        <h3>Product Options </h3>
        The Options for this product are:
        <div v-for="(attr, index) in state.product.specs" :key="index">
          <p>Attribute name: {{ attr.name }} Attribute value: {{ attr.value }}</p>
        </div>
      </div>
      <div class= "productDescription">
        <h3>Product Description </h3>
      The Description is: {{ state.product.description }}
      </div>
      <button class="btn btn-primary col-4 ms-1" @click="back">Back </button>
      <button class="btn btn-success col-4 ms-1">Add to Cart </button>
    </div> 
</div> 
</template>

<script setup>
import { inject, reactive } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();
const  store = inject('store');

const state = reactive({
  product: store.currentProduct.value
});

function back() {
  router.push('/');
}
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
