
<template>
    <div>
        <div v-if="store.cart.order.lineItems.length > 0">
            <DataTable id="cart" :value="store.cart.order.lineItems" responsiveLayout="scroll">
                <Column field="product.name" header="Name"></Column>
                <Column field="product.description" header="Description"></Column>
                <Column field="unitPrice" header="Price"></Column>
                <Column field="quantity" header="Quantity">
                <template #body="slotProps">
                    <Button icon="pi pi-minus" class="p-button-sm p-button-text m-1" @click="decreaseQuantity(slotProps.index)" />
                    
                    {{ slotProps.data.quantity }}
                    <Button icon="pi pi-plus" class="p-button-sm p-button-text m-1" @click="increaseQuantity(slotProps.index)" />
                    
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
            </div>
        </div>
        <div v-else>
            <font-awesome-icon id="cart" icon="fa-solid fa-cart-shopping" size="10x" /> <br/><br/>
            <h3>Your cart is empty!</h3>
            <Button label="Add Some Items" class="p-button-primary p-button-sm" @click="router.push('/')"></Button>
        </div>
    </div>
</template>

<script setup>
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import Button from 'primevue/button';
import { onBeforeMount, inject } from 'vue'
import { useRouter } from 'vue-router';

const router = useRouter();
const store = inject('store');
const taxRate = .08

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
    calcCost()
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

function deleteProduct(index) {
    store.cart.order.lineItems.splice(index, 1);
    calcCost()
}

function calcCost() {
    store.cart.order.subtotal = subTotal();
    store.cart.order.tax = store.cart.order.subtotal * taxRate
    store.cart.order.total = store.cart.order.subtotal + store.cart.order.tax
    store.methods.persistCart();
}

onBeforeMount(() => {
    calcCost()
})

</script>
<style scoped>

</style>
