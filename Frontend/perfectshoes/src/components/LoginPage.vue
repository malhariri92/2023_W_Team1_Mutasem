<template>
  <div>
    <form class="col-lg-10 offset-lg-1 text-center">
      <h1>Login</h1>
      <div class="row g-3 justify-content-center mt-2">
        <div class="col-4">
          <input id="email" v-model="state.email" type="email" class="form-control" placeholder="example@email.com *"
            required oninvalid="this.setCustomValidity('Email is required')" oninput="this.setCustomValidity('')">
        </div>
      </div>
      <div class="row g-3 justify-content-center mt-2">
        <div class="col-4">
          <input id="password" v-model="state.password" type="password" class="form-control" placeholder="Password *"
            required oninvalid="this.setCustomValidity('Password is required')" oninput="this.setCustomValidity('')">
          <div style="display:none;" id="loginMsg" class="alert alert-danger mt-2" role="alert">
            The combination of email/password is invalid
          </div>
        </div>
      </div>
      <div class="row g-1 justify-content-center mt-2">
        <Button type="submit" class="p-button-success col-4 ms-1" @click="login($event)" label="Log in"> </Button>
      </div>
      <div class="divider">
        <span class="divider-title">
          OR
        </span>
      </div>
    </form>
    <form class="col-lg-10 offset-lg-1 text-center">
      <div class="row g-3 justify-content-center mt-2">
        <h1>Sign Up</h1>
        <div class="col-2">
          <input id="firstName" v-model="state.firstName" type="text" class="form-control" placeholder="First Name *"
            required oninvalid="this.setCustomValidity('First Name is required')" oninput="this.setCustomValidity('')">
        </div>
        <div class="col-2">
          <input id="lastName" v-model="state.lastName" type="text" class="form-control" placeholder="Last Name *"
            required oninvalid="this.setCustomValidity('Last Name is required')" oninput="this.setCustomValidity('')">
        </div>
      </div>
      <div class="row g-3 justify-content-center mt-2">
        <div class="col-4">
          <input id="signUpEmail" type="email" v-model="state.signUpEmail" class="form-control"
            placeholder="example@email.com *" required oninvalid="this.setCustomValidity('Email is required')"
            oninput="this.setCustomValidity('')">
        </div>
      </div>
      <div class="row g-3 justify-content-center mt-2">
        <div class="col-4">
          <input id="signUpPassword" type="password" v-model="state.signUpPassword" class="form-control"
            placeholder="password *" required oninvalid="this.setCustomValidity('Password is required')"
            oninput="this.setCustomValidity('')">
        </div>
      </div>
      <div class="row g-1 justify-content-center mt-2">
        <Button label="Sign Up" type="submit" class="p-button-primary col-4 ms-1" @click="createAccount($event)"></Button>
      </div>
      <div class="row g-3 justify-content-center mt-2">
        <div class="col-4 mb-3">
          <span>* indicates a field is required.</span>
          <div style="display:none;" id="msg1" class="alert alert-success mt-1" role="alert">
            Your account has been created!
          </div>
          <div style="display:none;" id="msg2" class="alert alert-danger mt-1" role="alert">
            Email is already in use!
          </div>
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
import { useRouter } from 'vue-router';
import { reactive, inject } from "vue";
import Button from 'primevue/button';

const router = useRouter();
const store = inject('store');
const state = reactive({
  email: "",
  password: "",
  firstName: "",
  lastName: "",
  signUpEmail: "",
  signUpPassword: ""

});

async function login(e) {
  let email = document.getElementById('email');
  let password = document.getElementById('password');
  if (!email.checkValidity() | !password.checkValidity()) return;

  e.preventDefault();
  await store.methods.login(state.email, state.password).catch(() => {
    $("#loginMsg").show().delay(5000).fadeOut();
  });

  if (store.userState.user !== null) {
    if (store.userState.user.isAdmin) {
      router.push('/inventory');
    }
    else {
      if (store.isLogingInAndSigningOut) {
        router.push('/checkout');
      }
      else {
        router.push('/customer');
      }
    }
  }
}

async function createAccount(e) {
  let firstName = document.getElementById('firstName');
  let lastName = document.getElementById('lastName');
  let email = document.getElementById('signUpEmail');
  let password = document.getElementById('signUpPassword');
  let regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$!@?])[a-zA-Z0-9#$!@?]{8,20}$/;

  if (!email.checkValidity() | !password.checkValidity()
    | !firstName.checkValidity() | !lastName.checkValidity()) return;

  if (!regex.test(state.signUpPassword)) {
    e.preventDefault();
    const user = {
        FirstName: state.firstName,
        LastName: state.lastName,
        Email: state.signUpEmail,
        Password: state.signUpPassword,
      }

    if(state.signUpEmail.endsWith('@perfectshoes.com'))
    {
      user['Type'] = "employee";
      user['Role'] = "Admin";
      user['IsAdmin'] = true; 
    }
    else{
      user['Type'] = "customer";
    }
    $.ajax(
      {
        headers: {'Accept': 'application/json', 'Content-Type': 'application/json' },
        url: 'https://perfectshopapp.azurewebsites.net/api/Users/User',
        type: 'post',
        data:JSON.stringify(user),
        success: () => {
          $("#msg1").show().delay(5000).fadeOut();
          state.firstName = "";
          state.lastName = "";
          state.signUpEmail = "";
          state.signUpPassword = "";
        },
        error: (jqXHR) => {
          if(jqXHR.status == 400)
          $("#msg2").show().delay(5000).fadeOut();
        }
      }
    );
    state.signUpPassword = "";
    $("#msg3").show().delay(6000).fadeOut();
    return;
  }

  e.preventDefault();
  const user = {
    FirstName: state.firstName,
    LastName: state.lastName,
    Email: state.signUpEmail,
    Password: state.signUpPassword,
  }

  if (state.signUpEmail.endsWith('@perfectshoes.com')) {
    user['Type'] = "employee";
    user['Role'] = "Admin";
    user['IsAdmin'] = true;
  }
  else {
    user['Type'] = "customer";
  }
  $.ajax(
    {
      headers: { 'Accept': 'application/json', 'Content-Type': 'application/json' },
      url: 'https://localhost:44310/api/Users/User',
      type: 'post',
      data: JSON.stringify(user),
      success: () => {
        $("#msg1").show().delay(5000).fadeOut();
        state.firstName = "";
        state.lastName = "";
        state.signUpEmail = "";
        state.signUpPassword = "";
      },
      error: (jqXHR) => {
        if (jqXHR.status == 400)
          $("#msg2").show().delay(5000).fadeOut();
      }
    }
  );
}
</script>
  
  <!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
p.error {
  color: red
}

.divider {
  width: 32%;
  height: 20px;
  border-bottom: 1px solid black;
  text-align: center;
  margin: 30px auto;
}

.divider-title {
  font-size: 30px;
  background-color: #FFF;
}
</style>
  