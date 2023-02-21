<template>
  <div>
    <h1>Login</h1>
    <form class="login" v-on:submit="submitLogin">
      <input type="email" v-model="email" placeholder="Email" >
      <input type="password" v-model="password" placeholder="Password">
      <button type="submit">Login</button>
      <p class="error" v-text="errorMessage" />
    </form>
  </div>  
</template>
  
<script>
  import $ from 'jquery'
  import router from '../router';

  export default {
    data() {
      return {
        email: "",
        password: "",
        errorMessage: ""
      };
    },
    methods: {
      submitLogin(e) {
        e.preventDefault()
        if (this.email.endsWith('@perfectshoes.com')){
            $.ajax({
            url: 'https://localhost:44310/api/Employee?email=' + this.email + '&password=' + this.password,
            methods: 'get'
            })
            .done(router.push('/admin'))
            .fail(this.errorMessage = 'The combination of email/password is invalid')
        }
        else {
          // Add Customer Login Here
        }
      }
    },
  };
</script>
  
  <!-- Add "scoped" attribute to limit CSS to this component only -->
  <style scoped>
  form.login{
    display: flex;
    flex-direction: column;
    width: 100%;
    height: 40%;
    align-items: center;
    margin: 20px 0;
  }
  
  input{
    margin-bottom: 15px;
    width: 15%;
  }

  button{
    width: 15%;
  }

  img{
    width: 200px;
    height: 200px;
    text-align: center;
    margin: 0 auto;
    display:block;
  }

  p.error{
    color:red
  }

  </style>
  