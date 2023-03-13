<template>
    <div>
        <h1>Products </h1>
        <Toolbar>
          <template #start>
            <div class="d-inline">
                <h5>Select category:&nbsp;&nbsp;</h5>
            </div>
            <div class="d-inline">
              <form>
                <select v-model="categoryId" class="form-select" @change="HandleChange()">
                     <option selected value="">All</option>
                     <option v-for="(item, index) in store.categories.value" :key="index" :value="item.id">{{item.name}}</option>
                </select>
              </form>
            </div>
          </template>
            <template #end>
              <span class="p-input-icon-right">
                <i class="pi pi-search" />
                <input class="form-control" placeholder="Search Products"  v-model="state.filters" @keyup="HandleChange()"/>
              </span>
            </template>
        </Toolbar>
        <div v-if="state.products.length != 0">
        <div class= "products">
          <div class="product" v-for="(item, id) in state.products"  :key="id">
            <div  @click="productDetails(item)">
            <img :src="item.imageUrl" :alt="item.description"/> 
            <h3>{{ item.name}}</h3> 
            <div class="price">${{item.price.toFixed(2)}}</div>
          </div>
        </div>
        </div>
      </div> 
      <div v-if="state.products.length == 0 && state.filters !== ''">
        <h3 class="mt-2">No products found!</h3>
      </div>
  </div> 
</template>
  
<script setup>
  import Order from '@/store/Order';
  import { onMounted, inject, reactive, ref } from 'vue';
  import { useRouter } from 'vue-router';
  import Toolbar from 'primevue/toolbar';

  const router = useRouter();
  const store = inject('store');
  const state = reactive({
    filters: "",
    products: [],
  });
  const categoryId = ref("");
  onMounted(async () => 
  {
    await store.methods.loadProducts();
    state.products = store.products.value;
    if(store.cart.order === null) {
      sessionStorage.setItem('order', JSON.stringify(new Order()));
      store.cart.order = JSON.parse(sessionStorage.getItem('order'));
    }
    store.methods.loadCategories();
  });

  function productDetails(product) {
    store.methods.setCurrentProduct(product);
    router.push('/productDetails');
  }
  
  function HandleChange(){  
    if (state.filters === "")  state.products = store.products.value;
    else state.products = store.products.value?.filter(x => x.name.toLowerCase().includes(state.filters.toLocaleLowerCase())
        || x.description.toLowerCase().includes(state.filters.toLowerCase())
        || x.category.name.toLowerCase().includes(state.filters.toLowerCase()));
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
  .p-toolbar{
    width: 85%;
    margin: 0 auto;
  }

</style>
  