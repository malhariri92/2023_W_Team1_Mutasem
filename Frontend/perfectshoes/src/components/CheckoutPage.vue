<template>
    <h2>Contact Information: </h2>
    <form id=nameAndEmail class="col-lg-10 offset-lg-1 ">
        <div>
            <div class="row g-3 justify-content-center flex">
                <div class="col-3">
                    <div v-if="store.cart.order.customer.firstName !== ''">
                        <input v-model.lazy="store.cart.order.customer.firstName" required type="text" class="form-control"
                            :placeholder="store.cart.order.customer.firstName"
                            oninvalid="this.setCustomValidity('First name is required')"
                            oninput="this.setCustomValidity('')">

                    </div>
                    <div v-else>
                        <input v-model.lazy="store.cart.order.customer.firstName" required type="text" class="form-control"
                            placeholder="First Name *" oninvalid="this.setCustomValidity('First name is required')"
                            oninput="this.setCustomValidity('')">
                    </div>
                </div>
                <div class="col-3">
                    <div v-if="store.cart.order.customer.lastName !== ''">
                        <input v-model.lazy="store.cart.order.customer.lastName" required type="text" class="form-control"
                            :placeholder="store.cart.order.customer.lastName"
                            oninvalid="this.setCustomValidity('First name is required')"
                            oninput="this.setCustomValidity('')">
                    </div>
                    <div v-else>
                        <input v-model.lazy="store.cart.order.customer.lastName" required type="text" class="form-control"
                            placeholder="Last Name *" oninvalid="this.setCustomValidity('Last name is required')"
                            oninput="this.setCustomValidity('')">
                    </div>
                </div>
            </div>
            <div class="row g-3 justify-content-center mt-2">
                <div class="col-8">
                    <div v-if="store.cart.order.customer.email !== ''">
                        <input v-model.lazy="store.cart.order.customer.email" required type="text" class="form-control"
                            :placeholder="store.cart.order.customer.email"
                            oninvalid="this.setCustomValidity('Email address is required')"
                            oninput="this.setCustomValidity('')">
                    </div>
                    <div v-else>
                        <input v-model.lazy="store.cart.order.customer.email" required type="text" class="form-control"
                            placeholder="email address *" oninvalid="this.setCustomValidity('Email address is required')"
                            oninput="this.setCustomValidity('')">
                    </div>
                </div>
            </div>
        </div>
    </form>
    <h2>Address information:</h2>
    <form id="address" class="col-lg-10 offset-lg-1 ">
        <div class="row g-3 justify-content-center mt-2">
            <div class="col-8">
                <div v-if="store.cart.order.customer.address.addressLine1 !== ''">
                    <input v-model.lazy="store.cart.order.customer.address.addressLine1" id="addr1" required type="text"
                        class="form-control" :placeholder="store.cart.order.customer.address.addressLine1"
                        oninvalid="this.setCustomValidity('address is required')" oninput="this.setCustomValidity('')">
                </div>
                <div v-else>
                    <input v-model.lazy="store.cart.order.customer.address.addressLine1" id="addr1" required type="text"
                        class="form-control" placeholder="Address Line 1 *"
                        oninvalid="this.setCustomValidity('address is required')" oninput="this.setCustomValidity('')">
                </div>
            </div>
        </div>
        <div class="row g-3 justify-content-center mt-2">
            <div class="col-8">
                <div v-if="store.cart.order.customer.address.addressLine2 !== ''">
                    <input v-model.lazy="store.cart.order.customer.address.addressLine2" type="text" class="form-control"
                        :placeholder="store.cart.order.customer.address.addressLine2">
                </div>
                <div v-else>
                    <input v-model.lazy="store.cart.order.customer.address.addressLine2" type="text" class="form-control"
                        placeholder="Address Line 2 *">
                </div>
            </div>
        </div>
        <div class="row g-3 justify-content-center flex">
            <div class="col-3">
                <div v-if="store.cart.order.customer.address.city !== ''">
                    <input v-model.lazy="store.cart.order.customer.address.city" required type="text" class="form-control"
                        :placeholder="store.cart.order.customer.address.city"
                        oninvalid="this.setCustomValidity('city is required')" oninput="this.setCustomValidity('')">
                </div>
                <div v-else>
                    <input v-model.lazy="store.cart.order.customer.address.city" required type="text" class="form-control"
                        placeholder="City *" oninvalid="this.setCustomValidity('city is required')"
                        oninput="this.setCustomValidity('')">
                </div>
            </div>
            <div class="col-3">
                <div v-if="store.cart.order.customer.address.state !== ''">
                    <input v-model.lazy="store.cart.order.customer.address.state" required type="text" class="form-control"
                        :placeholder="store.cart.order.customer.address.state"
                        oninvalid="this.setCustomValidity('state is required')" oninput="this.setCustomValidity('')">
                </div>
                <div v-else>
                    <input v-model.lazy="store.cart.order.customer.address.state" required type="text" class="form-control"
                        placeholder="State *" oninvalid="this.setCustomValidity('state is required')"
                        oninput="this.setCustomValidity('')">
                </div>
            </div>
            <div class="col-2">
                <div v-if="store.cart.order.customer.address.zip !== ''">
                    <input v-model.lazy="store.cart.order.customer.address.zip" required type="text" class="form-control"
                        :placeholder="store.cart.order.customer.address.zip"
                        oninvalid="this.setCustomValidity('zip code is required')" oninput="this.setCustomValidity('')">
                </div>
                <div v-else>
                    <input v-model.lazy="store.cart.order.customer.address.zip" required type="text" class="form-control"
                        placeholder="Zip Code *" oninvalid="this.setCustomValidity('zip code is required')"
                        oninput="this.setCustomValidity('')">
                </div>
            </div>
        </div>
    </form>
    <h2>Card information:</h2>
    <form id="cardInfo" class="col-lg-10 offset-lg-1 ">
        <div class="row g-3 justify-content-center mt-2">
            <div class="col-8">
                <div v-if="store.cart.order.customer.creditCard.nameOnCard !== ''">
                    <input v-model.lazy="store.cart.order.customer.creditCard.nameOnCard" required type="text"
                        class="form-control" :placeholder="store.cart.order.customer.creditCard.nameOnCard"
                        oninvalid="this.setCustomValidity('card name is required')" oninput="this.setCustomValidity('')">
                </div>
                <div v-else>
                    <input v-model.lazy="store.cart.order.customer.creditCard.nameOnCard" required type="text"
                        class="form-control" placeholder="Cardholder name *"
                        oninvalid="this.setCustomValidity('card name is required')" oninput="this.setCustomValidity('')">
                </div>
            </div>
        </div>
        <div class="row g-3 justify-content-center mt-2">
            <div class="col-8">
                <div v-if="store.cart.order.customer.creditCard.cardNumber !== ''">
                    <input v-model.lazy="store.cart.order.customer.creditCard.cardNumber" required type="text"
                        class="form-control" :placeholder="store.cart.order.customer.creditCard.cardNumber"
                        oninvalid="this.setCustomValidity('card number is required')" oninput="this.setCustomValidity('')">
                </div>
                <div v-else>
                    <input v-model.lazy="store.cart.order.customer.creditCard.cardNumber" required type="text"
                        class="form-control" placeholder="Card number *"
                        oninvalid="this.setCustomValidity('card number is required')" oninput="this.setCustomValidity('')">
                </div>
            </div>
        </div>
        <div class="row g-3 justify-content-center flex">
            <div class="col-3">
                <div v-if="store.cart.order.customer.creditCard.cvc !== ''">
                    <input v-model.lazy="store.cart.order.customer.creditCard.cvc" required type="text" class="form-control"
                        :placeholder="store.cart.order.customer.creditCard.cvc"
                        oninvalid="this.setCustomValidity('cvc is required')" oninput="this.setCustomValidity('')">
                </div>
                <div v-else>
                    <input v-model.lazy="store.cart.order.customer.creditCard.cvc" required type="text" class="form-control"
                        placeholder="CVC *" oninvalid="this.setCustomValidity('cvc is required')"
                        oninput="this.setCustomValidity('')">
                </div>
            </div>
            <div class="col-3">
                <div v-if="store.cart.order.customer.creditCard.exprDate !== null">
                    <input v-model.lazy="store.cart.order.customer.creditCard.exprDate" required type="text"
                        class="form-control" :placeholder="store.cart.order.customer.creditCard.exprDate"
                        oninvalid="this.setCustomValidity('experation date is required')"
                        oninput="this.setCustomValidity('')">
                </div>
                <div v-else>
                    <input v-model.lazy="store.cart.order.customer.creditCard.exprDate" required type="text"
                        class="form-control" placeholder="MMYY"
                        oninvalid="this.setCustomValidity('experation date is required')"
                        oninput="this.setCustomValidity('')">
                </div>
            </div>
        </div>
    </form>
    <Button label="Place Order" class="p-button-success" @click="placeOrder()"></Button>
    <div v-if="noInfo">
        <a href="#" @click="enterUserInfo()">No Credit Card and/or Address information, would you like to add that to your
            profile</a>
    </div>
</template>

<script setup>

import { inject, onBeforeMount } from 'vue'
import $ from 'jquery'
import Button from 'primevue/button';
import router from '@/router';

let noInfo = false
let msg = ""
const store = inject('store');

onBeforeMount(() => {
    fillFields();
})

function fillFields() {
    if (store.isLogingInAndSigningOut == true) {
        if (store.userState.user != null) {
            store.cart.order.customer.firstName = store.userState.user.firstName
            store.cart.order.customer.lastName = store.userState.user.lastName
            store.cart.order.customer.email = store.userState.user.email
        }
        if (store.userState.user.address != null) {
            store.cart.order.customer.address.addressLine1 = store.userState.user.address.addressLine1
            store.cart.order.customer.address.addressLine2 = store.userState.user.address.addressLine2
            store.cart.order.customer.address.city = store.userState.user.address.city
            store.cart.order.customer.address.state = store.userState.user.address.state
            store.cart.order.customer.address.zip = store.userState.user.address.zip
        }
        else {
            noUserInfo()
        }
        if (store.userState.user.creditCard != null) {
            store.cart.order.customer.creditCard.nameOnCard = store.userState.user.creditCard.nameOnCard
            store.cart.order.customer.creditCard.cardNumber = store.userState.user.creditCard.cardNumber
            store.cart.order.customer.creditCard.cvc = store.userState.user.creditCard
            store.cart.order.customer.creditCard.exprDate = store.userState.user.exprDate
        } else {
            noUserInfo()
        }
    }
}

function noUserInfo() {
    if (store.isLogingInAndSigningOut == true) {
        noInfo = true
    }
}

function enterUserInfo() {
    router.push('/customer');
}

function isValidOrder() {
    let isValid = true
    if (!isValidContactInfo()) {
        isValid = false
    }
    if (!isValidAddressInfo()) {
        isValid = false
    }
    if (!isValidCardInfo()) {
        isValid = false
    }
    return isValid
}

function isValidContactInfo() {
    console.log("Testing Contact")
    let isValid = true
    if (store.cart.order.customer.firstName === '' || store.cart.order.customer.lastName === '' ||
        store.cart.order.customer.email) {
        isValid = false
    }
    return isValid
}

function isValidAddressInfo() {
    let isValid = true
    console.log("Testing address")
    console.log(store.cart.order.customer.address.zip.length)
    if (store.cart.order.customer.address.addressLine1 === '' || store.cart.order.customer.address.city === '' ||
        store.cart.order.customer.address.state === '' || store.cart.order.customer.address.zip === '') {
        isValid = false
    }

    if (store.cart.order.customer.address.zip.length != 5) {
        console.log("zip code not 5 digits")
        msg += "zip code is not 5 digits\n"
        isValid = false
    
    }
    return isValid
}

function isValidCardInfo() {
    console.log("Testing Card")
    let isValid = true
    if (store.cart.order.customer.creditCard.nameOnCard === '' || store.cart.order.customer.creditCard.cardNumber === '' ||
        store.cart.order.customer.creditCard.cvc === '' || store.cart.order.customer.creditCard.exprDate === null) {
        isValid = false
    }
    if (store.cart.order.customer.creditCard.cardNumber.length != 16) {
        console.log("credit card not 16 digits")
        msg += "Cardit Card number is not 16 digits\n"
        isValid = false
    }
    if (store.cart.order.customer.creditCard.cvc.length != 3) {
        console.log("CVC not 3 digits")
        msg += "cvc is not 3 digits\n"
        isValid = false
    }
    if (store.cart.order.customer.creditCard.exprDate === null) {
        console.log("Expr date is null")
        msg += "Experation date is null\n"
        isValid = false
    }
    if (store.cart.order.customer.creditCard.exprDate != null) {
        if (store.cart.order.customer.creditCard.exprDate.length != 4) {
            console.log("expr Date not 4 characters")
            msg += "exper Date is not 4 characters\n"
            isValid = false
        }
    }
    return isValid
}
function placeOrder() {
    if (isValidOrder()) {
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
    else {
        alert("Invalid Order\n" + msg)
        msg = ''
    }

}

</script>