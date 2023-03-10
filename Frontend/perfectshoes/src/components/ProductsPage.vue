<template>
    <div>
      <h1>Products </h1>
      <div class="row justify-content-between flex">
        <div class="col-3 mt-4">
          <span class="p-input-icon-right">
            <i class="pi pi-search" />
            <input class="form-control" placeholder="Keyword Search"  v-model="state.filters" @change="HandleChange()"/>
          </span>
        </div>
      </div>
      <div class= "products">
        <div class="product" v-for="(item, id) in state?.products"  :key="id">
          <div  @click="productDetails(item)">
          <img :src="item.imageUrl" :alt="item.description"/> 
          <h3>{{ item.name}}</h3> 
          <div class="price">${{item.price.toFixed(2)}}</div>
        </div>
      </div>
      </div>
    </div>  
</template>
  
<script setup>
  import Order from '@/store/Order';
  import { onMounted, inject, reactive } from 'vue';
  import { useRouter } from 'vue-router';

  const router = useRouter();
  const store = inject('store');
  const state = reactive({
    filters: "",
    products: [],
  });

  onMounted(async () => 
  {
    await store.methods.loadProducts();
    state.products = store.products.value;
    if(store.cart.order === null) {
      sessionStorage.setItem('order', JSON.stringify(new Order()));
      store.cart.order = JSON.parse(sessionStorage.getItem('order'));
    }
  });

  function productDetails(product) {
    store.methods.setCurrentProduct(product);
    router.push('/productDetails');
  }
  
  function HandleChange(){
    if (state.filters === "")  state.products = store.products.value;
    else state.products = store.products.value?.filter(x => x.name.includes(state.filters) || x.description.includes(state.filters) || x.category.name?.includes(state.filters))
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
  