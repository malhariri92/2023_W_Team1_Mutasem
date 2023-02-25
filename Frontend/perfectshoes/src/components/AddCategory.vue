<template>
    <div>
      <form id="addCategory" class="col-lg-10 offset-lg-1 ">
          <div class="row g-3 justify-content-center flex" >
              <div class="col-8">
                  <input v-model="state.category.Name" required type="text" class="form-control" placeholder="Category Name *"
                      oninvalid="this.setCustomValidity('Category name is required')"
                      oninput="this.setCustomValidity('')">
              </div>
          </div>
          <div class="row g-1 justify-content-center mt-2">
              <Button type="submit" label="Cancel" @click="close" class="p-button-danger col-4 ms-1"/>
              <Button type="submit" label="Save" @click="insertCategory($event)" class="p-button-success col-4 ms-1"/>
          </div>
          <div class="row g-3 justify-content-center mt-2">
              <div class="col-8 mb-3">
                  <div style="display:none;" id="msg" class="alert alert-success mt-1" role="alert">
                      Category has been successfuly added!
                  </div>
              </div>
          </div>
      </form>
    </div>
  </template>
      
  <script setup>
  import { reactive, inject } from "vue";
  import $ from 'jquery'
  import Button from 'primevue/button';
  
  const dialogRef = inject("dialogRef");
  
   const state = reactive({
      title: 'Add Category',
      specs: [
            {
              "Name": '',
              "Value": ''
            }
      ],
      category: {
        "Name": ''
      }
   });
  
  const initialState =  {
      specs: [
          {
              "Name": '',
              "Value": ''
          }
      ],
      category: {
        "Name": ''
      }
   };
  
  function insertCategory(e) {   
      if (state.category.Name === '') return;
      e.preventDefault();
  
      $.ajax({
          headers: { 
          'Accept': 'application/json',
          'Content-Type': 'application/json' 
          },
          'url': 'https://localhost:44310/api/Categories',
          'method': 'post',
          'data': JSON.stringify(state.category)
        }).done(() => {
          Object.assign(state, initialState);
          $("#msg").show().delay(5000).fadeOut();
        }); 
  }

  function close() {
      dialogRef.value.close();
  }
  </script>
      
      <!-- Add "scoped" attribute to limit CSS to this component only -->
  <style scoped>
  h1 {
      margin: 0 auto;
  }
  </style>