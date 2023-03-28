<template>
    <TabView ref="tabview1">
    <TabPanel header="Contact Info">


        <label for="fname">First Name</label>
        <input type="text" id="fname" name="fname" :value="store.userState.user.firstName" readonly><br>
        <label for="lname">Last Name</label>
        <input type="text" id="lname" name="lname" :value="store.userState.user.lastName" readonly><br>
        <label for="fname">Email</label>

        <input type="text" id="email" name="email" :value="store.userState.user.email" readonly><br>

        <Button @click="changePassword" label="Change Password" icon="pi pi-plus" class="p-button-primary" />
        <DynamicDialog />

        <h3>Welcome {{ store.userState.user.firstName }} {{ store.userState.user.lastName }}!</h3>
        <p><strong>Email: </strong>{{ store.userState.user.email }}</p>

    </TabPanel>
    <TabPanel header="My Address">

        <div v-if="store.userState.user.address !== null">
            <h4>Shipping Address</h4>
            <p> <strong>{{ store.userState.user.firstName }} {{ store.userState.user.lastName }} </strong></p>
            <p> {{ store.userState.user.address.addressLine1 }},
            {{ store.userState.user.address.addressLine2 }}</p>
            <p> {{ store.userState.user.address.city }},
            {{ store.userState.user.address.state }}
            {{ store.userState.user.address.zip }}</p>
            <Button @click="updateAddress" label="Update Address" icon="pi pi-plus" class="p-button-primary"/>
        </div>
        <div v-if="store.userState.user.address === null">
            <h3>You have not added your address!</h3>
            <Button @click="addAddress" label="Add Address" icon="pi pi-plus" class="p-button-primary" />
        </div>
        <DynamicDialog />

    </TabPanel>
    <TabPanel header="My Credit Card">
        <div v-if="store.userState.user.creditCard !== null">
            <h4>Payment Information</h4>
            <p> <strong>Card Holder:</strong> {{ store.userState.user.creditCard.nameOnCard }}</p>
            <p><strong>Ending in:</strong> {{ store.userState.user.creditCard.cardNumber.slice(12) }}</p>
            <p><strong>Expires in:</strong> {{ new Date(store.userState.user.creditCard.exprDate).getMonth() + 1 }} /
            {{ new Date(store.userState.user.creditCard.exprDate).getFullYear() }}</p>
                <Button @click="editCreditCard" label="Update Credit Card" icon="pi pi-plus" class="p-button-primary" />
        </div>
        <div v-else>
            <h3>You have not added your credit card!</h3>
            <Button @click="addCreditCard" label="Add Credit Card" icon="pi pi-plus" class="p-button-primary" />
        </div>
    </TabPanel>
    <TabPanel header="Order History">
        <Accordion :multiple="false" :activeIndex="[0]">
            <AccordionTab v-for="(order, id) in store.userState.user.orders"  :header="new Date(order.date).toString().slice(4,13)" :key="id">
               <div class="row g-3">
                    <div class="col"><label> Name</label></div>
                    <div class="col"><label>Price</label></div>
                    <div class="col"><label>Quantity</label></div>
               </div>
                <div v-for="(item, i) in order.lineItems" :key="i" class="row g-3">
                    <div class="col-sm">{{ item.product.name }}</div>
                    <div class="col-sm">${{ item.product.price.toFixed(2) }}</div>   
                    <div class="col-sm">{{ item.quantity }}</div>   
                </div>
                <div class="row g-3 mt-2">
                    <div class="col-sm"> <label>Subtotal:</label>${{order.subtotal.toFixed(2)}}</div>
                    <div class="col-sm"><label>Tax:</label>${{order.tax.toFixed(2) }}</div>
                    <div class="col-sm"><label>Total:</label>  ${{ order.total.toFixed(2) }}</div>
                </div>
                <div class="row g-3 justify-content-center mt-2"><label>Shipping Address:</label>  {{ order.shippingAddress}}</div>
                <div class="row g-3 mt-2">
                    <div class="col"> <label>Order Date:</label>{{ order.date.replace('T', ' ').slice(0, 19) }}</div>
                    <div class="col"><label>Order Status:</label> {{ order.status }}</div>
                    <div class="col" v-if="order.shipDate != null"><label>Ship Date:</label> {{ order.shipDate  }} </div>
                    <div class="col" v-else><label>Ship Date:</label> Not Shipped yet</div>
                </div>
            </AccordionTab>
        </Accordion>
        <!-- add logic to show customer order history here -->
    </TabPanel>
</TabView>
</template>
  
<script setup>
    import { inject, provide, onMounted } from "vue";
    import Button from 'primevue/button';
    import TabView from 'primevue/tabview';
    import TabPanel from 'primevue/tabpanel';
    import Address from "../store/Address";
    import AddAddress from "./AddAddress.vue";
    import { useDialog } from 'primevue/usedialog';
    import CreditCardState from '../store/CreditCardState';
    import AddCreditCard from './AddCreditCard.vue';
    import UpdatePassword from "./UpdatePassword.vue";
    import Accordion from 'primevue/accordion';
    import AccordionTab from 'primevue/accordiontab';

onMounted(() => {
console.log(store.userState.user)
});

const store = inject("store");
const dialog = useDialog();

provide('dialog', dialog);

function addAddress() {
    const address = new Address();
    address.customerId = store.userState.user.id;
    dialog.open(AddAddress, {
    props: {
        header: 'Add Address',
        style: {
            width: '40vw'
        },
        breakpoints: {
            '960px': '75vw',
            '640px': '90vw'
        },
        modal: true,
    },
    data: { addressState: address }
    });
}

function updateAddress() {
const address = new Address();
Object.assign(address, store.userState.user.address);
address.customerId = store.userState.user.id;
dialog.open(AddAddress, {
props: {
    header: 'Update Address',
    style: {
        width: '40vw'
    },
    breakpoints: {
        '960px': '75vw',
        '640px': '90vw'
    },
    modal: true,
},
data: { addressState: address }
});
}

function changePassword() {
const address = new Address();
address.customerId = store.userState.user.id;
dialog1.open(UpdatePassword, {
props: {
    header: 'Change Password',
    style: {
        width: '40vw'
    },
    breakpoints: {
        '960px': '75vw',
        '640px': '90vw'
    },
    modal: true,
},
data: { addressState: address }
});
}

function editCreditCard() {
const state = new CreditCardState();
state.customerId = store.userState.user.id;
Object.assign(state.creditCard ,store.userState.user.creditCard);
state.creditCard.exprDate = new Date(state.creditCard.exprDate);

dialog.open(AddCreditCard, {
props: {
    header: 'Edit Credit Card',
    style: {
        width: '40vw',
    },
    breakpoints: {
        '960px': '75vw',
        '640px': '90vw'
    },
    modal: true,
},
data: { creditCardState: state }
});
}

function addCreditCard() {
const state = new CreditCardState();
state.customerId = store.userState.user.id;
dialog.open(AddCreditCard, {
props: {
    header: 'Add Credit Card',
    style: {
        width: '40vw',
    },
    breakpoints: {
        '960px': '75vw',
        '640px': '90vw'
    },
    modal: true,
},
data: { creditCardState: state }
});
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
input[type=text] {
width: 50%;
text-align: center;
padding: 12px 20px;
margin: 8px ;
border: none;
border-bottom: 2px solid blue;
}
label{
margin-right: 1em;
font-weight: bold;
}

Button {
margin: 1em;
}

.p-accordion{
    width: 50%;
    margin: 0 auto;
}
</style>
