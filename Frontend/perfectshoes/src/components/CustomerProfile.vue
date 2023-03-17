<template>
    <TabView ref="tabview1">
    <TabPanel header="Contact Info">

        <label for="fname">First Name</label>
        <input type="text" id="fname" name="fname" :value="store.userState.user.firstName" readonly><br>
        <label for="lname">Last Name</label>
        <input type="text" id="lname" name="lname" :value="store.userState.user.lastName" readonly><br>
        <label for="fname">Email</label>

        <input type="text" id="email" name="email" :value="store.userState.user.email" readonly><br>

    </TabPanel>
    <TabPanel header="Adress Info">
        <div v-if="store.userState.user.address !== null">

            <label for="addressLine1">Adress Line 1</label>
            <input type="text" id="ad1" :value="store.userState.user.address.addressLine1"><br>
            <div v-if="store.userState.user.address.addressLine2 !== null">
                 <label for="addressLine2">Adress Line 2</label>
                <input type="text" id="ad2" :value="store.userState.user.address.addressLine2"><br>
            </div>
            <label for="zipCode">ZipCode</label>
            <input type="text" id="zip" :value="store.userState.user.address.zip"><br>
            <label for="city">City</label>
            <input type="text" id="city" :value="store.userState.user.address.city"><br>
            <label for="state">State</label>
            <input type="text" id="state" :value="store.userState.user.address.state"><br>
            <Button> Update Adress</Button>

        </div>
        <div v-else><Button> Add Adress</Button></div>
    </TabPanel>
    <TabPanel header="Payment Info">
        <div v-if="store.userState.user.creditCard !== null">
                <label for="creditCard">Last 4 digits of Credit Card</label><br>
                <input type="text" id="creditCard" 
                :value="store.userState.user.creditCard.cardNumber.substring(store.userState.user.creditCard.cardNumber.length - 4, 
                store.userState.user.creditCard.cardNumber.length)"><br>
                <Button @click="editCreditCard" label="Update Credit Card" icon="pi pi-plus" class="p-button-primary" />
        </div>
        <div v-else><Button @click="addCreditCard" label="Add Credit Card" icon="pi pi-plus" class="p-button-primary" /></div>
        <DynamicDialog />
    </TabPanel>
    <TabPanel header="Order History">
        <!-- add logic to show customer order history here -->
    </TabPanel>
</TabView>
  </template>
  
  <script setup>
    import { inject, provide } from "vue";
    import Button from 'primevue/button';
    import TabView from 'primevue/tabview';
    import TabPanel from 'primevue/tabpanel';
    import CreditCardState from '../store/CreditCardState';
    import { useDialog } from 'primevue/usedialog';
    import AddCreditCard from '@/components/AddCreditCard.vue';
    const store = inject('store');  
    console.log(store.userState.user)
    
    const dialog = useDialog();
    provide('dialog', dialog);

    function editCreditCard() {
    const state = new CreditCardState();
    state.creditCard = store.userState.user.creditCard;
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
   margin-right: 3em;
   font-weight: bold;
}

Button {
    margin: 1em;
}
  </style>
  