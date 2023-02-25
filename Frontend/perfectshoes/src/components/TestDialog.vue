<template>
    <div>  
      <button @click="openDialog" class="btn btn-primary mt-2" type="submit">{{ props.title }} <font-awesome-icon icon="fa-solid fa-plus"/></button>
    </div>   
</template>
    
<script setup>
import { defineProps } from 'vue';

  const props = defineProps(['title', 'component', 'dialogTitle', 'width', 'dialog'])
  const data = {};

  function openDialog() {
    props.dialog.open(props.component, {
              props: {
                header: props.dialogTitle,
                  style: {
                    width: props.width,
                  }, 
                  breakpoints:{
                    '960px': '75vw',
                    '640px': '90vw'
                },               
                modal: true,
              }, 
              data: data,                       
          });
  }
      
</script>
    
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1 {
  margin: 40px 0 0;
}
</style>
    