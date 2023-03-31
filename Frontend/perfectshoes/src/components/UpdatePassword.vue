<template>
    <div>
      <form id="changePass">
        <div class="row g-3 justify-content-center mt-2">
          <div class="col-10">
            <input id="currentPassword" type="password" v-model="state.currentPassword" class="form-control"
              placeholder="Current Password *" required oninvalid="this.setCustomValidity('Current password is required')"
              oninput="this.setCustomValidity('')">
          </div>
          <div style="display:none;" id="msg1" class="col-10 text-danger" role="alert">
              Current password is incorrect
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
          <div style="display:none;" id="msg2" class="col-10 text-danger" role="alert">
              Passwords do not match
          </div>
          </div>
        
        <div class="row g-1 justify-content-center mt-2">
          <Button label="Cancel" @click="close" class="p-button-danger col-5 ms-1"/>
          <Button label="Submit" class="p-button-primary col-5 ms-1" @click="changePassword($event)"></Button>
        </div>
        <div class="row g-3 justify-content-center mt-2">
          <div class="col-10 mb-3">
            <span>* indicates a field is required.</span>
            <div style="display:none;" id="msg3" class="alert alert-danger mt-1" role="alert">
              Password needs to be 8-20 characters and include an Uppercase letter, lowercase letter, number, and one of
              these: #$!@?
            </div>
            <div style="display:none;" id="msg4" class="alert alert-success mt-1" role="alert">
              Password was updated!
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
    if(!document.forms['changePass'].reportValidity()) return;
    e.preventDefault();

    if (state.currentPassword !== store.userState.user.password) {
      $("#msg1").show().delay(6000).fadeOut();
      return;
    }
     
    let regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$!@?])[a-zA-Z0-9#$!@?]{8,20}$/;
    if (!regex.test(state.newPassword)) {
      state.newPassword = "";
      state.newPasswordConfirm = "";
      $("#msg3").show().delay(6000).fadeOut();
      return;
    }
    if ( state.newPassword !== state.newPasswordConfirm){
      $("#msg2").show().delay(6000).fadeOut();
      return;
    }
    
    const user = {
      "id": store.userState.user.id,
      "firstName": store.userState.user.firstName,
      "lastName": store.userState.user.lastName,
      "email": store.userState.user.email,
      "password": state.newPassword,
      "type": "customer",
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
    }).done(() => {
      $("#msg4").show().delay(6000);    
      });
      
    }
    
  function close() {
      dialogRef.value.close();
  }

</script>
    