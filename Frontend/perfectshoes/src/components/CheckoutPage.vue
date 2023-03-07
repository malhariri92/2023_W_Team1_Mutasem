<template>
    <form id=nameAndEmail>
        <div>
            <input v-model="store.cart.order.customer.firstName" required type="text" class="form-control"
                placeholder="First Name *" oninvalid="this.setCustomValidity('First name is required')"
                oninput="this.setCustomValidity('')">
            <input v-model="store.cart.order.customer.lastName" required type="text" class="form-control"
                placeholder="Last Name *" oninvalid="this.setCustomValidity('Last name is required')"
                oninput="this.setCustomValidity('')">
            <input v-model="store.cart.order.customer.email" required type="text" class="form-control"
                placeholder="email address *" oninvalid="this.setCustomValidity('Email address is required')"
                oninput="this.setCustomValidity('')">
        </div>
    </form>
    <form id="address">
        <div>
            <input v-model="store.cart.order.customer.address.addressLine1" required type="text" class="form-control"
                placeholder="Address Line 1 *" oninvalid="this.setCustomValidity('address is required')"
                oninput="this.setCustomValidity('')">
            <input v-model="store.cart.order.customer.address.addressLine2" required type="text" class="form-control"
                placeholder="Address Line 2 *" oninvalid="this.setCustomValidity('address is required')"
                oninput="this.setCustomValidity('')">
            <input v-model="store.cart.order.customer.address.city" required type="text" class="form-control"
                placeholder="City *" oninvalid="this.setCustomValidity('city is required')"
                oninput="this.setCustomValidity('')">
            <input v-model="store.cart.order.customer.address.state" required type="text" class="form-control"
                placeholder="State *" oninvalid="this.setCustomValidity('state is required')"
                oninput="this.setCustomValidity('')">
            <input v-model="store.cart.order.customer.address.zip" required type="text" class="form-control"
                placeholder="Zip Code *" oninvalid="this.setCustomValidity('zip code is required')"
                oninput="this.setCustomValidity('')">
        </div>
    </form>
    <form id="cardInfo">
        <div>
            <input v-model="store.cart.order.customer.creditCard.nameOnCard" required type="text" class="form-control"
                placeholder="Cardholder name *" oninvalid="this.setCustomValidity('card name is required')"
                oninput="this.setCustomValidity('')">
            <input v-model="store.cart.order.customer.creditCard.cardNumber" required type="text" class="form-control"
                placeholder="Card number *" oninvalid="this.setCustomValidity('card number is required')"
                oninput="this.setCustomValidity('')">
            <input v-model="store.cart.order.customer.creditCard.cvc" required type="text" class="form-control"
                placeholder="CVC *" oninvalid="this.setCustomValidity('cvc is required')"
                oninput="this.setCustomValidity('')">
            <input v-model="store.cart.order.customer.creditCard.exprDate" required type="text" class="form-control"
                placeholder="Card experation date *" oninvalid="this.setCustomValidity('experation date is required')"
                oninput="this.setCustomValidity('')">
        </div>
    </form>
</template>

<script setup>

import { inject } from 'vue'
const store = inject('store');

</script>