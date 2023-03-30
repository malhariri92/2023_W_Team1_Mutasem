<template>
    <form id=orderDetails class="text-center">
        <div>
            <div class="row g-3 justify-content-center flex">
                <div class="col-5">
                    <label for="cusName">Customer Name</label>
                    <p>{{ state.customerName }}</p>
                </div>
                <div class="col-5">
                    <label for="cusEmail">Email</label>
                    <p>{{ state.customerEmail }}</p>
                </div>
            </div>
            <div class="row g-3 justify-content-center mt-2">
                 <label>Customer Address</label>
                 {{ state.shippingAddress }}                
            </div>
            <div class="row g-3 mt-2">
                    <div class="col"><label> Name</label></div>
                    <div class="col"><label>Price</label></div>
                    <div class="col"><label>Quantity</label></div>
            </div>
            <div v-for="(item, i) in state.lineItems" :key="i" class="row g-3">
                    <div class="col">{{ item.product.name }}</div>
                    <div class="col">${{ item.product.price.toFixed(2) }}</div>   
                    <div class="col">{{ item.quantity }}</div>   
            </div>
            <div class="row g-3 mt-2">
                    <div class="col"> <label>Subtotal:</label>${{state.subtotal.toFixed(2)}}</div>
                    <div class="col"><label>Tax:</label>${{state.tax.toFixed(2) }}</div>
                    <div class="col"><label>Total:</label>  ${{ state.total.toFixed(2) }}</div>
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

import { reactive, inject } from 'vue'
import Button from 'primevue/button';
import $ from 'jquery'
//import store from '@/store';
const dialogRef = inject("dialogRef");
const store = inject('store');

const state = reactive(dialogRef.value.data.Order);

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
            store.methods.loadOrders();
            dialogRef.value.close();
    });   
}

</script>

<style scoped>
label{
font-weight: bold;
}

</style>