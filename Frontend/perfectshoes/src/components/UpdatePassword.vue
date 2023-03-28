<template>
    <div>
      <form>
        <div class="row g-3 justify-content-center mt-2">
          <div class="col-10">
            <input id="currentPassword" type="password" v-model="state.currentPassword" class="form-control"
              placeholder="Current Password *" required oninvalid="this.setCustomValidity('Current password is required')"
              oninput="this.setCustomValidity('')">
          </div>
          <div class="col-10">
            <input id="newPassword" type="password" v-model="state.newPassword" class="form-control"
              placeholder="New Password *" required oninvalid="this.setCustomValidity('New password is required')"
              oninput="this.setCustomValidity('')">
          </div>
          <div class="col-10">
            <input id="newPasswordConfirm" type="password" v-model="state.newPasswordConfirm" class="form-control"
              placeholder="Confirm New Password *" required oninvalid="this.setCustomValidity('Password confirmation is required')"
              oninput="this.setCustomValidity('')">
          </div>
        </div>
        <div class="row g-1 justify-content-center mt-2">
          <Button label="Cancel" @click="close" class="p-button-danger col-4 ms-1"/>
          <Button label="Submit" type="submit" class="p-button-primary col-4 ms-1" @click="changePassword($event)"></Button>
        </div>
        <div class="row g-3 justify-content-center mt-2">
          <div class="col-4 mb-3">
            <span>* indicates a field is required.</span>
            <div style="display:none;" id="msg3" class="alert alert-danger mt-1" role="alert">
              Password needs to be 8-20 characters and include an Uppercase letter, lowercase letter, number, and one of
              these: #$!@?
            </div>
          </div>
        </div>
      </form>
    </div>
  </template>
    
  <script setup>
  import $ from 'jquery';
  import { reactive, inject } from "vue";
  import Button from 'primevue/button';
  
  const dialogRef = inject("dialogRef");
  const store = inject('store');
  const state = reactive({
    currentPassword:"",
    newPassword: "",
    newPasswordConfirm: ""
  });
    
  async function changePassword(e) {
    let newPassword = document.getElementById('newPassword');
    let newPasswordConfirm = document.getElementById('newPasswordConfirm');
    let currentPassword = document.getElementById('currentPassword');

    let regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$!@?])[a-zA-Z0-9#$!@?]{8,20}$/;
  
    if ( newPassword !== newPasswordConfirm)
     return;

    if ( newPassword === currentPassword)
      return;

     if (currentPassword !== state.userState.Password)
     return;

    if ( !newPassword.checkValidity())
     return;

  
    if (!regex.test(state.newPassword)) {
      e.preventDefault();
      state.newPassword = "";
      $("#msg3").show().delay(6000).fadeOut();
      return;
    }
  
    e.preventDefault();
    const user = {
      FirstName: state.firstName,
      LastName: state.lastName,
      Email: state.signUpEmail,
      Password: state.newPassword,
    }
  
    $.ajax(
      {
        headers: { 
          'Accept': 'application/json',
          'Content-Type': 'application/json' 
        },
        'url': 'https://localhost:44310/api/Users/UpdatePassword',
        'method': 'post',
        'data': JSON.stringify(user)
      }).done((data) => {
          store.userState.user = data;
          Object.assign(store.userState.user, data)
          dialogRef.value.close();
      });
      
    }
    
    function close() {
      dialogRef.value.close();
  }

  </script>
    
    <!-- Add "scoped" attribute to limit CSS to this component only -->
  <style scoped>
  p.error {
    color: red
  }
  
  .divider {
    width: 100%;
    height: 20px;
    border-bottom: 1px solid black;
    text-align: center;
    margin-top: 30px;
    margin-bottom: 30px;
  }
  
  .divider-title {
    font-size: 30px;
    background-color: #FFF;
  }
  </style>
    