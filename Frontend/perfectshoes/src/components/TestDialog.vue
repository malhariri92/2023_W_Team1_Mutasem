<template>
    <div>  
      <button @click="addProduct" class="btn btn-primary m-2" type="submit"> 
        <font-awesome-icon icon="fa-solid fa-plus"/> Add Address</button>
        <button @click="addProduct" class="btn btn-primary m-2" type="submit">
           <font-awesome-icon icon="fa-solid fa-plus"/> Edit Address</button>
      <DynamicDialog />
    </div>   
</template>
    
<script setup>
import { provide } from 'vue'
import AddProduct from '@/components/AddProduct.vue';
import { useDialog } from 'primevue/usedialog';
import ProductState from '../store/ProductState';

const dialog = useDialog();
provide('dialog', dialog);

  function addProduct() {
    const state = new ProductState();
    dialog.open(AddProduct, {
              props: {
                header: 'Add Product',
                  style: {
                    width: '40vw',
                  }, 
                  breakpoints:{
                    '960px': '75vw',
                    '640px': '90vw'
                },               
                modal: true,
              }, 
              data: { productState: state }                    
          });
    }
      
</script>
    
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1 {
  margin: 40px 0 0;
}
</style>
    