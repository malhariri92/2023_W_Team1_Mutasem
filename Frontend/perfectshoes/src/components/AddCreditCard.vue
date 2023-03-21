<template>
    <div>
      <form id="addCreditCard" class="col-lg-10 offset-lg-1 ">
          <div class="row g-3 justify-content-center flex" >
              <div class="col-4">
                  <input v-model="state.creditCard.nameOnCard" required type="text" class="form-control" placeholder="Credit Card Holder *"
                      oninvalid="this.setCustomValidity('Credit Card Holder is required')"
                      oninput="this.setCustomValidity('')">
              </div>
              <div class="col-4">
                <input v-model="state.creditCard.cardNumber" required type="password" class="form-control" placeholder="Credit Number *" minlength="16" maxlength = "16"
                      oninvalid="this.setCustomValidity('Credit Number is required')"
                      oninput="this.setCustomValidity('')"
                      @keypress="IsNumber($event)">
              </div>
          </div>
          <div class="row g-3 justify-content-center mt-2">
              <div class="col-4">
                  <input v-model="state.creditCard.cvc" required type="password" class="form-control" placeholder="CVC *" minlength="3" maxlength="3" 
                      @keypress="IsNumber($event)"
                      oninvalid="this.setCustomValidity('CVC is required')"
                      oninput="this.setCustomValidity('')">
              </div>
              <div class="col-4">
                <Calendar v-model="state.creditCard.exprDate" dateFormat="mm/y" required
                    placeholder="Experation date *" view="month" oninvalid="this.setCustomValidity('experation date is required')"
                        oninput="this.setCustomValidity('')"/>
                  <!-- <input v-model="state.creditCard.exprDate" required type="text" class="form-control" placeholder="Expired date *"  minlength="5" maxlength="5"
                      oninvalid="this.setCustomValidity('Expired date is required')"
                      oninput="this.setCustomValidity('')"
                      @keypress="ValidateMaskInput($event)"> -->
              </div>
          </div>
  
          <div class="row g-1 justify-content-center mt-2">
              <Button label="Cancel" @click="close" class="p-button-danger col-4 ms-1"/>
              <Button type="submit" label="Save" @click="UpsertCreditCard($event)" class="p-button-success col-4 ms-1"/>
          </div>
          <div class="row g-3 justify-content-center mt-2">
              <div class="col-8 mb-3">
                  <span>* indicates a field is required.</span>
              </div>
          </div>

      </form>
      <DynamicDialog />
    </div>
</template>
      
<script setup>
  import { reactive, inject, provide } from "vue";
  import $ from 'jquery'
  import Button from 'primevue/button';
  import { useDialog } from 'primevue/usedialog';
  import Calendar from 'primevue/calendar';
  
  const dialogRef = inject("dialogRef");
  const store = inject("store");
  const state = reactive(dialogRef.value.data.creditCardState);
  const dialog = useDialog();
  provide('dialog', dialog);
  
  function validateCreditCard(){
      return state.creditCard.nameOnCard !== "" &&
      state.creditCard.cardNumber !== "" &&
      state.creditCard.cvc !== "" &&
      state.creditCard.exprDate !== null;
  }
  
  function IsNumber(e) {
      if (e.keyCode < 48 || e.keyCode > 57) {
        e.preventDefault();
      } else {
        return true;
      }
  }

//   function ValidateMaskInput(e) {
//       if (IsNumber(e) && state.creditCard.exprDate.length === 2){
//         state.creditCard.exprDate += '/';
//       }
//   }

  function UpsertCreditCard(e) {   
      if (!validateCreditCard()) return;
      e.preventDefault();
      
      state.creditCard.customerId = state.customerId
      state.creditCard.exprDate = state.creditCard.exprDate.toJSON();
      $.ajax({
      headers: { 
      'Accept': 'application/json',
      'Content-Type': 'application/json' 
      },
      'url': 'https://localhost:44310/api/CreditCard',
      'method': 'post',
      'data': JSON.stringify(state.creditCard)
      }).done((data) => {
        console.log(data);
      store.userState.user.creditCard = data;
      store.userState.user.creditCardId = data.id;
      console.log(store.userState.user);
      sessionStorage.setItem('user', JSON.stringify(store.userState.user));
      dialogRef.value.close();
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