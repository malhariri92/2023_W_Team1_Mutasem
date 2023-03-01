<template>
    <div>  
      <button @click="addProduct" class="btn btn-primary mt-2" type="submit"> <font-awesome-icon icon="fa-solid fa-plus"/></button>
    </div>   
</template>
    
<script setup>
import { provide } from 'vue'
import AddProduct from '@/components/AddProduct.vue';
import { useDialog } from 'primevue/usedialog';

const dialog = useDialog();
provide('dialog', dialog);

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
          });
    }
      
</script>
    
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1 {
  margin: 40px 0 0;
}
</style>
    