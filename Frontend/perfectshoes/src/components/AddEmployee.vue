<template>
  <div>
    <form id="addEmployee" class="col-lg-10 offset-lg-1 ">
        <div class="row g-3 justify-content-center flex" >
              <div class="col-4">
                  <input v-model="state.employee.FirstName" required type="text" class="form-control" placeholder="Firstname *"
                      oninvalid="this.setCustomValidity('First Name is required')"
                      oninput="this.setCustomValidity('')">
              </div>
              <div class="col-4">
                <input v-model="state.employee.LastName" required type="text" class="form-control" placeholder="Lastname *"
                      oninvalid="this.setCustomValidity('Last name is required')"
                      oninput="this.setCustomValidity('')">
              </div>
        </div>

        <div class="row g-3 justify-content-center mt-2">
              <div class="col-4">
                  <input id="email" v-model="state.employee.Email" required type="email" class="form-control" placeholder="Email *" 
                      oninput="this.setCustomValidity('')">
              </div>
              <div class="col-4">
                <Dropdown v-model="state.employee.Role" :options="RolesEnum" placeholder="Select a role" class="w-full md:w-14rem custom" 
                    oninvalid="this.setCustomValidity('Role is required')"
                    oninput="this.setCustomValidity('')"/>
              </div>
        </div>
<!-- 
        <div class="row g-3 justify-content-center mt-2">
              <div class="col-8">
                  <input id="password" v-model="state.employee.Password" required type="password" class="form-control" placeholder="Password *" 
                      oninput="this.setCustomValidity('')">
              </div>
        </div> -->

        <div class="row g-1 justify-content-center mt-2">
            <Button label="Cancel" @click="close" size="large" class="p-button-danger col-4 ms-1"/>
            <Button type="submit" label="Save" size="small" @click="insertEmployee($event)" class="p-button-success col-4 ms-1"/>
        </div>
    </form>
    <DynamicDialog />
  </div>
</template>
    
<script setup>
import { reactive, inject, provide } from "vue";
import $ from 'jquery';
import Button from 'primevue/button';
import { useDialog } from 'primevue/usedialog';
import Dropdown from 'primevue/dropdown';

const RolesEnum = ['admin', 'manager']

const dialogRef = inject("dialogRef");
const state = reactive(dialogRef.value.data.employeeState);

const dialog = useDialog();
provide('dialog', dialog);

function validateEmployee(){
    let regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$!@?])[a-zA-Z0-9#$!@?]{8,20}$/;
    let email = document.getElementById('email');
    let password = document.getElementById('password');

    if (state.employee.Password === ''){
        password.setCustomValidity('Password is required');
    }
    else if (!regex.test(state.employee.Password)) {
        password.setCustomValidity('Password needs to be 8-20 characters and include an Uppercase letter, lowercase letter, number, and one of these: #$!@?');
        return false;
    }

    if (state.employee.Email === ''){
        email.setCustomValidity('Email is required')
        return false;
    } 
    else if (!state.employee.Email.endsWith('@perfectshoes.com')){
        email.setCustomValidity('Email must end with @perfectshoes.com')
        return false;
    }

    return (state.employee.FirstName !== "" &&
    state.employee.LastName !== "" &&
    state.employee.Email !== "" &&
    state.employee.Password !== "")
}

function insertEmployee(e) {

    state.employee.Type = "employee";

    if (!validateEmployee()) return;
    e.preventDefault();
    
    $.ajax({
        headers: { 
        'Accept': 'application/json',
        'Content-Type': 'application/json' 
        },
        'url': 'https://localhost:44310/api/Users/Employee',
        'method': 'post',
        'data': JSON.stringify(state.employee)
      }).done(dialogRef.value.close());
}

function close() {
    dialogRef.value.close();
}

</script>
    
    <!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.custom {
    width: 100%;
    height: 38.18px;
}
</style>