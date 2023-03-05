<template>
  <div>
    <h1>Login</h1>
    <form class="col-lg-10 offset-lg-1">
      <div class="row g-3 justify-content-center mt-2">
        <div class="col-4">
            <input id="email" v-model="state.email" type="email" class="form-control" placeholder="example@email.com *" required 
                oninvalid="this.setCustomValidity('Email is required')"
                oninput="this.setCustomValidity('')">
        </div> 
      </div>
      <div class="row g-3 justify-content-center mt-2">
        <div class="col-4">
            <input id="password" v-model="state.password" type="password" class="form-control" placeholder="Password *" required
              oninvalid="this.setCustomValidity('Password is required')" oninput="this.setCustomValidity('')">
            <div style="display:none;" id="msg" class="alert alert-danger mt-2" role="alert">
              The combination of email/password is invalid
            </div>
        </div>
      </div>
      <div class="row g-1 justify-content-center mt-2">
            <button type="submit" class="btn btn-success col-4 ms-1" @click="login($event)">Log in </button> 
      </div>
    </form>
  </div>  
  <br><br>
  <div>
  <!-- This div is for the account creation -->
    <h3>Don't have an account?</h3>
    <p>Enter information into the above email and password fields then enter your name below and hit the Create Account button!</p> 
    <form class="col-lg-10 offset-lg-1">
    <div class="row g-3 justify-content-center mt-2">
        <div class="col-4">
            <input id="firstName" v-model="state.firstName" type="firstName" class="form-control" placeholder="John *" required 
                oninvalid="this.setCustomValidity('First Name is required')"
                oninput="this.setCustomValidity('')">
        </div> 
      </div>
      <div class="row g-3 justify-content-center mt-2">
        <div class="col-4">
            <input id="lastName" v-model="state.lastName" type="lastName" class="form-control" placeholder="Smith *" required 
                oninvalid="this.setCustomValidity('Last Name is required')"
                oninput="this.setCustomValidity('')">
        </div> 
      </div>
      <div class="row g-1 justify-content-center mt-2">
        <button type="submit" class="btn btn-success col-4 ms-1" @click="createAccount($event)">Create Account</button>
      </div> 
      <div style="display:none;" id="msg2" class="alert alert-danger mt-2" role="alert">
        Error, user password already set
      </div>
    </form>
  </div>
</template>
  
<script setup>
  import $ from 'jquery'
  import { useRouter } from 'vue-router';
  import { reactive, inject } from "vue";

  const router = useRouter();
  const store = inject('store');
  const state = reactive({
    email: "",
    password: "",
  });

  async function login(e) {
    let email = document.getElementById('email');
    let password = document.getElementById('password');
    if(!email.checkValidity() | !password.checkValidity()) return;

    e.preventDefault();
    await store.methods.login(state.email, state.password).catch(() => {
      $("#msg").show().delay(5000).fadeOut();
    });

    if (store.userState.user !== null){
      if (store.userState.user.isAdmin === true) {
      console.log(store.userState.user);
      router.push('/admin');
    } 
    else {
      console.log(store.userState.user);
      router.push('/');
    }
    }
  }

  async function createAccount(e) {
    if(state.email!=="" && state.password !=="" && state.firstName !=="" && state.lastName !=="")
    {
    e.preventDefault();
    if(state.email.endsWith('@perfectshoes.com'))
    {
      await store.methods.insertEmployee(state.email, state.password, state.firstName, state.lastName).catch(()=> {$("msg2").show().delay(5000).fadeOut();})
    }
    else{
      //put the regular user creation here when it is completed
    }
    }
  }
</script>
  
  <!-- Add "scoped" attribute to limit CSS to this component only -->
  <style scoped>
  p.error{
    color:red
  }

  </style>
  