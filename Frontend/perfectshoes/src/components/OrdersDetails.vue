<template>
    <form id=orderDetails class="col-lg-10 offset-lg-1 ">
        <div>
            <div class="row g-3 justify-content-center flex">
                <div class="col-3">
                    <label for="cusName">Customer Name</label>
                    <input type="text" id="cusName" name="cusName"
                        :value="state.customer.FirstName + ' ' + state.customer.lastName" readonly><br>
                </div>
                <div class="col-3">
                    <label for="cusEmail">Email</label>
                    <input type="text" id="cusEmail" name="cusEmail" :value="state.customer.email" readonly><br>
                </div>
            </div>
            <div class="row g-3 justify-content-center mt-2">
                <div class="col-3">
                    <label for="cusAdd">Customer Address</label>
                    <p>{{ state.customer.address.addressLine1 }}</p>
                </div>
            </div>
            <div class="row g-3 justify-content-center flex">
                <div class="col-3">
                    <label for="subTotal">Subtotal $</label>
                    <input type="text" id="subTotal" name="subTotal" :value="state.subtotal" readonly><br>
                </div>
                <div class="col-3">
                    <label for="tax">Tax $</label>
                    <input type="text" id="tax" name="tax" :value="state.tax" readonly><br>
                </div>
                <div class="col-3">
                    <label for="total">Total $</label>
                    <input type="text" id="total" name="total" :value="state.total" readonly><br>
                </div>
            </div>
            <div class="row g-3 justify-content-center mt-2">
                <div class="col-3">
                    <p>Placeholder</p>
                </div>
            </div>
            <div class="row g-3 justify-content-center mt-2">
                <div class="col-3">
                    <Button label="Fullfill Order" icon="primary" @click="fullfilOrder()"></Button>
                </div>
            </div>
            <div class="row g-3 justify-content-center mt-2">
                <div class="col-8 mb-3">
                    <div style="display:none;" id="msg" class="alert alert-success mt-1" role="alert">
                        Order is fullfiled
                    </div>

                </div>
            </div>
        </div>

    </form>
</template>

<script setup>

import { reactive, inject, onMounted } from 'vue'
import Button from 'primevue/button';
import $ from 'jquery'
const dialogRef = inject("dialogRef");
// const store = inject('store');



let state = reactive(dialogRef.value.data.Order);

onMounted(() =>  {
    console.log("----------------------------------")
    state = dialogRef.value.data.Order
    console.log(state) 
});


function fullfilOrder() {
    
    $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'url': 'https://localhost:44310/api/Order/Fulfill',
            'method': 'post',
            'data': JSON.stringify(state)
        }).done(() => {
            console.log("Order is fulfilled")
            alert("Order fulfilled");
        });
    
    
}


</script>