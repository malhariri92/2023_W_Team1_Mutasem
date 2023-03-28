<template>
  <div>
    <form id="addEmployee" class="col-lg-10 offset-lg-1 ">
        <div class="row g-3 justify-content-center flex" >
              <div class="col-4">
                  <input v-model="state.employee.FirstName" required type="text" class="form-control"
                   placeholder="Firstname *"
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
            <div class="row g-1 justify-content-center mt-2">
            <div style="display:none;" id="msg1" class="alert alert-success mt-1 col-8" role="alert">
                Employee has been added!
            </div>
            <div style="display:none;" id="msg2" class="alert alert-danger mt-1 col-8" role="alert">
                Something went wrong!
            </div>
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
import EmployeeState from '../store/EmployeeState';

const RolesEnum = ['admin', 'manager']

const dialogRef = inject("dialogRef");
const state = reactive(dialogRef.value.data.employeeState);

const dialog = useDialog();
provide('dialog', dialog);

function validateEmail(){
    let email = document.getElementById('email');

    if (state.employee.Email === ''){
        email.setCustomValidity('Email is required')
        return false;
    } 
    else if (!state.employee.Email.endsWith('@perfectshoes.com')){
        email.setCustomValidity('Email must end with @perfectshoes.com')
        return false;
    }

    return true;
}

function insertEmployee(e) {

    if (!document.forms['addEmployee'].reportValidity() | !validateEmail()) return;
    e.preventDefault();

    state.employee.isAdmin = true;
    console.log(state.employee)
    $.ajax({
        headers: { 
        'Accept': 'application/json',
        'Content-Type': 'application/json' 
        },
        'url': 'https://localhost:44310/api/Users/Employee',
        'method': 'post',
        'data': JSON.stringify(state.employee),
        success: () => {
        $("#msg1").show().delay(5000).fadeOut();
        state.employee = new EmployeeState();
      },
      error: (jqXHR) => {
        if (jqXHR.status == 400)
          $("#msg2").show().delay(5000).fadeOut();
      }
      });
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