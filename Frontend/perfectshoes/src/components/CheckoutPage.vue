<template>
    <div>
        <div v-if="!isPlaced && store.userState.user === null">
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
                    <div class="col-6">
                        <input v-model="store.cart.order.customer.email" required type="email" class="form-control"
                            placeholder="email address *" oninvalid="this.setCustomValidity('Email address is required')"
                            oninput="this.setCustomValidity('')">
                    </div>
                </div>
            </div>
        <h2 class="mt-3">Address information:</h2>
            <div class="row g-3 justify-content-center mt-2">
                <div class="col-6">
                    <input v-model="store.cart.order.customer.address.addressLine1" id="addr1" required type="text"
                        class="form-control" placeholder="Address Line 1 *"
                        oninvalid="this.setCustomValidity('address is required')" oninput="this.setCustomValidity('')">
                </div>
            </div>
            <div class="row g-3 justify-content-center mt-2">
                <div class="col-6">
                    <input v-model="store.cart.order.customer.address.addressLine2" type="text" class="form-control"
                        placeholder="Address Line 2 *">
                </div>
            </div>
            <div class="row g-3 justify-content-center mt-2">
                <div class="col-2">
                    <input v-model="store.cart.order.customer.address.city" required type="text" class="form-control"
                        placeholder="City *" oninvalid="this.setCustomValidity('city is required')"
                        oninput="this.setCustomValidity('')">
                </div>
                <div class="col-2">
                    <select v-model="store.cart.order.customer.address.state" class="form-select" required
                    oninvalid="this.setCustomValidity('Select a state')" oninput="this.setCustomValidity('')">
                     <option selected value=""></option>
                     <option v-for="(item, index) in store.usStates" :key="index" :value="item">{{item}}</option>
                </select>
                </div>
                <div class="col-2">
                    <input v-model="store.cart.order.customer.address.zip" required type="text" class="form-control"
                        placeholder="Zip Code *" oninvalid="this.setCustomValidity('Enter 5 digits zip code')"
                        oninput="this.setCustomValidity('')" pattern="^[0-9]{5}$" maxlength="5">
                </div>
            </div>
        <h2 class="mt-3">Card information:</h2>
            <div class="row g-3 justify-content-center mt-2">
                <div class="col-6">
                    <input v-model="store.cart.order.customer.creditCard.nameOnCard" required type="text" class="form-control"
                        placeholder="Cardholder name *" oninvalid="this.setCustomValidity('card name is required')"
                        oninput="this.setCustomValidity('')">
                </div>
            </div>
            <div class="row g-3 justify-content-center mt-2">
                <div class="col-6">
                    <input v-model="store.cart.order.customer.creditCard.cardNumber" required type="text" class="form-control"
                        placeholder="Card number *" oninvalid="this.setCustomValidity('card number is required and must consist of 16 digits')"
                        minlength="16" maxlength="16"
                        oninput="this.setCustomValidity('')" pattern="^[0-9]{16}$">
                </div>
            </div>
            <div class="row g-3 justify-content-center mt-2">
                <div class="col-3">
                    <input v-model="store.cart.order.customer.creditCard.cvc" required type="password" minlength="3"
                        maxlength="3" class="form-control" pattern="^[0-9]{3}$"
                        placeholder="CVC *" oninvalid="this.setCustomValidity('cvc is required and must be 3 digits')"
                        oninput="this.setCustomValidity('')">
                </div>
                <div class="col-3">
                    <Calendar id="exprDate" class="custom" v-model="store.cart.order.customer.creditCard.exprDate"
                    dateFormat="mm/yy"
                    placeholder="Experation date * mm/yy" view="month" :manualInput="false"
                    oninvalid="this.setCustomValidity('experation date is required')"
                        oninput="this.setCustomValidity('')"/>
                </div>
            </div>
            <Button type="submit" label="Place Order" class="p-button-success mt-3" @click="placeOrder($event)"></Button>
        </form>
    </div>
    <OrderConfirmation v-if="isPlaced" :id="orderId"/>
    <div v-if="store.userState.user !== null && !isPlaced">
        <div v-if="store.userState.user.address !== null">
            <h4>Shipping Address</h4>
            <p> <strong>{{ store.userState.user.firstName }} {{ store.userState.user.lastName }} </strong></p>
            <p> {{ store.userState.user.address.addressLine1 }},
            {{ store.userState.user.address.addressLine2 }}</p>
            <p> {{ store.userState.user.address.city }},
            {{ store.userState.user.address.state }}
            {{ store.userState.user.address.zip }}</p>
        </div>
        <div v-if="store.userState.user.creditCard !== null">
            <h4>Payment Information</h4>
            <p> <strong>Card Holder:</strong> {{ store.userState.user.creditCard.nameOnCard }}</p>
            <p><strong>Ending in:</strong> {{ store.userState.user.creditCard.cardNumber.slice(12) }}</p>
            <p><strong>Expires in:</strong> {{ new Date(store.userState.user.creditCard.exprDate).getMonth() + 1 }} /
            {{ new Date(store.userState.user.creditCard.exprDate).getFullYear() }}</p>
        </div>
        <a class="link" v-if="store.userState.user.creditCard === null" @click="router.push('/customer')">
        Please add a credit card to continue</a><br/>
        <a class="link" v-if="store.userState.user.address === null"  @click="router.push('/customer')">
        Please add your address to continue</a>
        <Button @click="placeOrder($event)" v-if="store.userState.user.creditCard !== null && store.userState.user.address !== null"
         class="p-button-success" label="Place Order"></Button>
    </div>
</div>
</template>

<script setup>

import { inject, ref, onMounted } from 'vue'
import $ from 'jquery'
import Button from 'primevue/button';
import Calendar from 'primevue/calendar';
import OrderConfirmation from '@/components/OrderConfirmation.vue';
import Order from '@/store/Order';
import { useRouter } from 'vue-router';
//import InputMask from 'primevue/inputmask';

const store = inject('store');
const isPlaced = ref(false);
const orderId = ref(0);
const router = useRouter();

function placeOrder(e) {
    if(store.userState.user !== null) {
        store.cart.order.customer = store.userState.user;
        store.cart.order.customerId = store.userState.user.id;
    }
    console.log(store.cart.order.customer)
    if (store.userState.user === null && store.cart.order.customer.creditCard.exprDate !== null) {
        var dateField = document.getElementById('exprDate').children[0];
        dateField.readOnly = true;
        dateField.required = false;
    }
    if(store.userState.user === null && !document.forms['nameAndEmail'].reportValidity()) return;
    e.preventDefault();
    
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
onMounted(() => {
    if(store.userState.user === null) {
        var dateField = document.getElementById('exprDate').children[0];
        dateField.readOnly = false;
        dateField.required = true;
        dateField.setCustomValidity('experation date is required');
    }
});

// function setDate() {
//     var date = new Date(store.cart.order.customer.creditCard.exprDate);
//     store.cart.order.customer.creditCard.exprDate = date.toJSON();
//     document.getElementById('exprDate').children[0].required = false;
//     document.getElementById('exprDate').children[0].readOnly = true;
// }
</script>

<style scoped>
.custom {
    width: 100%;
    height: 38.18px;
}
</style>