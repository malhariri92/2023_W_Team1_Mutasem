<template>
    <div>
        <div v-if="!isPlaced">
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
        <h2>Address information:</h2>
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
        <h2>Card information:</h2>
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
                    <Calendar v-model="store.cart.order.customer.creditCard.exprDate" dateFormat="mm/y" required
                    placeholder="Experation date * mm/yy" view="month" oninvalid="this.setCustomValidity('experation date is required')"
                        oninput="this.setCustomValidity('')"/>
                    <!-- <input v-model="store.cart.order.customer.creditCard.exprDate" required type="text" class="form-control"
                        placeholder="Card experation date *" oninvalid="this.setCustomValidity('experation date is required')"
                        oninput="this.setCustomValidity('')"> -->
                </div>
            </div>
            <Button type="submit" label="Place Order" class="p-button-success" @click="placeOrder($event)"></Button>
        </form>
    </div>
    <OrderConfirmation v-if="isPlaced" :id="orderId"/>
</div>
</template>

<script setup>

import { inject, ref } from 'vue'
import $ from 'jquery'
import Button from 'primevue/button';
import Calendar from 'primevue/calendar';
import OrderConfirmation from '@/components/OrderConfirmation.vue';
import Order from '@/store/Order';

const store = inject('store');
const isPlaced = ref(false);
const orderId = ref(0);

function placeOrder(e) {
    if(!document.forms['nameAndEmail'].reportValidity()) return;
    e.preventDefault();
    var date = new Date(store.cart.order.customer.creditCard.exprDate);
    store.cart.order.customer.creditCard.exprDate = date.toJSON();
    console.log(JSON.stringify(store.cart.order));
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'url': 'https://localhost:44310/api/Order',
        'method': 'post',
        'data': JSON.stringify(store.cart.order)
    }).done((response) => {
        isPlaced.value = true;
        orderId.value = response;
        sessionStorage.setItem('order', JSON.stringify(new Order()));
        store.cart.order = JSON.parse(sessionStorage.getItem('order'));
    }).fail(() => {
        alert('Something went wrong, please try again later.');
    });

}

</script>