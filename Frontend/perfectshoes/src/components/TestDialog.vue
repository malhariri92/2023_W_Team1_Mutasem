<template>
    <div>  
      <button @click="addProduct" class="btn btn-primary mt-2" type="submit">New Product <font-awesome-icon icon="fa-solid fa-plus"/></button>
      <DynamicDialog />
    </div>   
</template>
    
<script setup>
import { useDialog } from 'primevue/usedialog';
import AddProduct from '@/components/AddProduct.vue'
import DynamicDialog from 'primevue/dynamicdialog';
import { provide } from 'vue';

  const dialog = useDialog();
  provide('dialog', dialog);

  const product = {};

  function addProduct() {
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
              data: product,                       
          });
  }
      
</script>
    
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1 {
  margin: 40px 0 0;
}
</style>
    