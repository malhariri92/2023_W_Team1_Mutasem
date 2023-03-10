<template>
    <h2>Contact Information: </h2>
    <form id=nameAndEmail class="col-lg-10 offset-lg-1 ">
        <div>
            <div class="row g-3 justify-content-center flex">
                <div class="col-3">
                    <input v-model="store.cart.order.customer.firstName" required type="text" class="form-control"
                        placeholder="First Name *" oninvalid="this.setCustomValidity('First name is required')"
                        oninput="this.setCustomValidity('')">
                </div>
                <div class="col-3">
                    <input v-model="store.cart.order.customer.lastName" required type="text" class="form-control"
                        placeholder="Last Name *" oninvalid="this.setCustomValidity('Last name is required')"
                        oninput="this.setCustomValidity('')">
                </div>
            </div>
            <div class="row g-3 justify-content-center mt-2">
                <div class="col-8">
                    <input v-model="store.cart.order.customer.email" required type="text" class="form-control"
                        placeholder="email address *" oninvalid="this.setCustomValidity('Email address is required')"
                        oninput="this.setCustomValidity('')">
                </div>
            </div>
        </div>
    </form>
    <h2>Address information:</h2>
    <form id="address" class="col-lg-10 offset-lg-1 ">
        <div class="row g-3 justify-content-center mt-2">
            <div class="col-8">
                <input v-model="store.cart.order.customer.address.addressLine1" id="addr1" required type="text"
                    class="form-control" placeholder="Address Line 1 *"
                    oninvalid="this.setCustomValidity('address is required')" oninput="this.setCustomValidity('')">
            </div>
        </div>
        <div class="row g-3 justify-content-center mt-2">
            <div class="col-8">
                <input v-model="store.cart.order.customer.address.addressLine2" type="text" class="form-control"
                    placeholder="Address Line 2 *">
            </div>
        </div>
        <div class="row g-3 justify-content-center flex">
            <div class="col-3">
                <input v-model="store.cart.order.customer.address.city" required type="text" class="form-control"
                    placeholder="City *" oninvalid="this.setCustomValidity('city is required')"
                    oninput="this.setCustomValidity('')">
            </div>
            <div class="col-3">
                <input v-model="store.cart.order.customer.address.state" required type="text" class="form-control"
                    placeholder="State *" oninvalid="this.setCustomValidity('state is required')"
                    oninput="this.setCustomValidity('')">
            </div>
            <div class="col-2">
                <input v-model="store.cart.order.customer.address.zip" required type="text" class="form-control"
                    placeholder="Zip Code *" oninvalid="this.setCustomValidity('zip code is required')"
                    oninput="this.setCustomValidity('')">
            </div>
        </div>
    </form>
    <h2>Card information:</h2>
    <form id="cardInfo" class="col-lg-10 offset-lg-1 ">
        <div class="row g-3 justify-content-center mt-2">
            <div class="col-8">
                <input v-model="store.cart.order.customer.creditCard.nameOnCard" required type="text" class="form-control"
                    placeholder="Cardholder name *" oninvalid="this.setCustomValidity('card name is required')"
                    oninput="this.setCustomValidity('')">
            </div>
        </div>
        <div class="row g-3 justify-content-center mt-2">
            <div class="col-8">
                <input v-model="store.cart.order.customer.creditCard.cardNumber" required type="text" class="form-control"
                    placeholder="Card number *" oninvalid="this.setCustomValidity('card number is required')"
                    oninput="this.setCustomValidity('')">
            </div>
        </div>
        <div class="row g-3 justify-content-center flex">
            <div class="col-3">
                <input v-model="store.cart.order.customer.creditCard.cvc" required type="text" class="form-control"
                    placeholder="CVC *" oninvalid="this.setCustomValidity('cvc is required')"
                    oninput="this.setCustomValidity('')">
            </div>
            <div class="col-3">
                <input v-model="store.cart.order.customer.creditCard.exprDate" required type="text" class="form-control"
                    placeholder="Card experation date *" oninvalid="this.setCustomValidity('experation date is required')"
                    oninput="this.setCustomValidity('')">
            </div>
        </div>
    </form>
    <Button label="Place Order" class="p-button-success" @click="placeOrder()"></Button>
</template>

<script setup>

import { inject } from 'vue'
import $ from 'jquery'
import Button from 'primevue/button';

const store = inject('store');

function placeOrder() {
    console.log("placing order")
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'url': 'https://localhost:44310/api/Order',
        'method': 'post',
        'data': JSON.stringify(store.cart.order)
    }).done(() => {
        console.log("Order completed")
        alert("Order is placed");
        
    });

}

</script>