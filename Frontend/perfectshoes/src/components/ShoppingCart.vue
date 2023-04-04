
<template>
    <div>
        <div v-if="store.cart.order.lineItems.length > 0">
            <DataTable id="cart" :value="store.cart.order.lineItems" responsiveLayout="scroll">
                <Column field="product.name" header="Name"></Column>
                <Column field="product.description" header="Description"></Column>
                <Column field="unitPrice" header="Price"></Column>
                <Column field="quantity" header="Quantity">
                <template #body="slotProps">
                    <span class="p-buttonset">
                        <Button icon="pi pi-minus" class="p-button-sm p-button-text " @click="decreaseQuantity(slotProps.index)" />                  
                        <Button disabled class="p-button-sm p-button-text">{{ slotProps.data.quantity }}</Button>
                        <Button icon="pi pi-plus" class="p-button-sm p-button-text" @click="increaseQuantity(slotProps.index)" />
                    </span>
                </template>
                </Column>
                
                <Column header="Delete product?">
                    <template #body="slotProps">
                        <Button class="p-button-warning p-button-sm" icon="pi pi-trash" @click="deleteProduct(slotProps.index)"></Button>
                    </template>
                </Column>
            </DataTable>
        
            <div>
            <Button label="Empty Cart" icon="pi pi-trash" class="p-button-danger m-2" @click="emptyCart()"></Button>
            <p>Subtotal cost: ${{ store.cart.order.subtotal.toFixed(2) }}</p>
            <p>Tax: ${{ store.cart.order.tax.toFixed(2) }}</p>
            <p>Total: ${{ store.cart.order.total.toFixed(2) }}</p>
            <Button label="Checkout As Guest" class="p-button-primary m-2" @click="checkout()"
            v-if="store.userState.user === null"></Button>
            <Button label="Login and checkout" class="p-button-success m-2" @click="loginAndCheckout()"
            v-if="store.userState.user === null"></Button>
            <Button label="Checkout" class="p-button-success" @click="checkout()"
            v-if="store.userState.user !== null"></Button>
            <DynamicDialog />
            </div>
        </div>
        <div v-else>
            <font-awesome-icon id="cart" icon="fa-solid fa-cart-shopping" size="10x" /> <br/><br/>
            <h3>Your cart is empty!</h3>
            <Button label="Add Some Items" class="p-button-primary p-button-sm" @click="router.push('/')"></Button>
        </div>
        <div id="msg" style="display: none">
            <div style="width: 50%; margin: 0 auto" class="alert alert-danger">
                 Sorry, the followiing product/s are no longer available. Please remove them to continue.
                <p v-for="item in state.removedProducts" :key="item.id">{{item.name}}</p>
            </div>
        </div>
    </div>
</template>

<script setup>
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import Button from 'primevue/button';
import { onBeforeMount, inject, provide, reactive } from 'vue'
import { useRouter } from 'vue-router';
import { useDialog } from 'primevue/usedialog';
import LoginPage from '../components/LoginPage.vue';
import $ from 'jquery';


const dialog = useDialog();
provide('dialog', dialog);

const router = useRouter();
const store = inject('store');
const taxRate = .08;
const state = reactive({
    products: [],
    removedProducts: []
});


// Loop through the price of items in cart and get the subTotal
function subTotal() {
    let total = 0;
    for (let i = 0; i < store.cart.order.lineItems.length; i++) {
        total += store.cart.order.lineItems[i].unitPrice * store.cart.order.lineItems[i].quantity
    }
    return total;
}

function emptyCart() {
    store.cart.order.lineItems = []
    calcCost();
    $("#msg").hide();
}
function increaseQuantity(index) {
    store.cart.order.lineItems[index].quantity++    
    calcCost()
}

function decreaseQuantity(index) {
    if(store.cart.order.lineItems[index].quantity > 1) {
        store.cart.order.lineItems[index].quantity--;
        calcCost()
    }
    
}

async function deleteProduct(index) {
    store.cart.order.lineItems.splice(index, 1);
    calcCost();
    if(await verifyProduct()) {
        state.removedProducts = [];
        $("#msg").hide();
    }
}

function calcCost() {
    store.cart.order.subtotal = subTotal();
    store.cart.order.tax = store.cart.order.subtotal * taxRate
    store.cart.order.total = store.cart.order.subtotal + store.cart.order.tax
    store.methods.persistCart();
}

async function loginAndCheckout() {
    store.isLogingInAndSigningOut = true;
    if(await verifyProduct()) {
        dialog.open(LoginPage, {
              props: {
                  style: {
                    width: '50vw',
                  }, 
                  breakpoints:{
                    '960px': '75vw',
                    '640px': '90vw'
                },               
                modal: true,
              },    
                  
          });
    } else {
        $("#msg").show();
    }
}

onBeforeMount(() => {
    calcCost();
});

async function checkout() {
    store.methods.loadProducts();
    if (await verifyProduct()) {
        router.push('/checkout')
    }
    else {
        $("#msg").show();
    }
}
async function verifyProduct() {
    await store.methods.loadProducts();
    state.products = store.products.value;
    state.removedProducts = [];
    let isProduct = false;
    for (let i = 0; i < store.cart.order.lineItems.length; i++) {
        isProduct = false;
        for (let j = 0; j < state.products.length; j++) {
            if (store.cart.order.lineItems[i].product.id == state.products[j].id) {
                isProduct = true;
            }
        }      
        if(!isProduct) {
            state.removedProducts.push(store.cart.order.lineItems[i].product);
        }
    }
    return state.removedProducts.length === 0;
}
</script>
<style scoped>

</style>
