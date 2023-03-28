<template>
    <form id="addAddress" class="col-lg-10 offset-lg-1 ">
        <div class="row g-3 justify-content-center flex" >
            <div class="col-10">
                <input v-model="state.addressLine1" required type="text" class="form-control" placeholder="Address Line 1 *" minlength="1" maxlength="100" 
                    oninvalid="this.setCustomValidity('Address Line 1 is required')"
                    oninput="this.setCustomValidity('')">
            </div>
            <div class="col-10">
              <input v-model="state.addressLine2" type="text" class="form-control" placeholder="Address Line 2" maxlength="100" >
            </div>
            <div class="col-5">
                <input v-model="state.city" required type="text" class="form-control" placeholder="City *" minlength="1" maxlength="20"
                    oninvalid="this.setCustomValidity('City is required')"
                    oninput="this.setCustomValidity('')">
            </div>
            <div class="col-2">
                <select v-model="state.state" class="form-select" required
                    oninvalid="this.setCustomValidity('Select a state')" oninput="this.setCustomValidity('')">
                     <option selected value=""></option>
                     <option v-for="(item, index) in store.usStates" :key="index" :value="item">{{item}}</option>
                </select>
            </div>
            <div class="col-3">
                <input v-model="state.zip" required class="form-control" placeholder="Zip Code *" minlength="5" maxlength="5" 
                    oninvalid="this.setCustomValidity('Zip code is required')"
                    oninput="this.setCustomValidity('')">
            </div>
        </div>
        <div class="row g-3 justify-content-center mt-2">
            <div class="col-8 mb-3">
                <span>* indicates a field is required.</span>
            </div>
        </div>
        <div class="row g-1 justify-content-center mt-2">
            <Button label="Cancel" @click="close" class="p-button-danger col-4 ms-1"/>
            <Button type="submit" label="Save" @click="AddAddress($event)" class="p-button-success col-4 ms-1"/>
        </div>
    </form>
</template>

<script setup>
  import { reactive, inject, provide } from "vue";
  import $ from 'jquery'
  import Button from 'primevue/button';
  import { useDialog } from 'primevue/usedialog';
  
  const dialogRef = inject("dialogRef");
  const store = inject("store");
  const state = reactive(dialogRef.value.data.addressState);
  const dialog = useDialog();
  const header = dialogRef.value.options.props.header;

  provide('dialog', dialog);

  
  function AddAddress(e) {  
    if(!document.forms['addAddress'].reportValidity()) return; 
    e.preventDefault();
    if(header === 'Add Address') {
      $.ajax({
      headers: { 
      'Accept': 'application/json',
      'Content-Type': 'application/json' 
      },
      'url': 'https://localhost:44310/api/Address',
      'method': 'post',
      'data': JSON.stringify(state)
      }).done((data) => {
        store.userState.user['address']= data;
        sessionStorage.setItem('user', JSON.stringify(store.userState.user));
        dialogRef.value.close();
      });

    } if(header === 'Update Address'){
      $.ajax({
      headers: { 
      'Accept': 'application/json',
      'Content-Type': 'application/json' 
      },
      'url': 'https://localhost:44310/api/Address/update',
      'method': 'post',
      'data': JSON.stringify(state)
      }).done((data) => {
        store.userState.user['address']= data;
        Object.assign(store.userState.user.address, data)
        dialogRef.value.close();
      });

    }

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
  
  .addSpec {
      color:blue;
      cursor: pointer;
      text-decoration: underline;
  }
  .addSpec:hover {
      color:rgb(218, 28, 28);
      cursor: pointer;
  }
  #addProduct {
      overflow-x: hidden;
  }
  </style>