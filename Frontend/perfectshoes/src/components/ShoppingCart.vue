
<template>
    <table>
        <thead>
            <tr>
                <th>#</th>
                <th>Name</th>
                <th>Description</th>
                <th>Price</th>
                <th>Quantity</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="(item, index) in items" :key="index">
                <td>{{ index }}</td>
                <td>{{ item.name }}</td>
                <td>{{ item.description }}</td>
                <td>{{ item.price }}</td>
                <td>{{ item.quantity }}</td>
            </tr>
        </tbody>
    </table>
    <div>
        <p>Subtotal cost: ${{ state.preTaxTotal.toFixed(2) }}</p>
        <p>Tax: ${{ state.taxCost.toFixed(2) }}</p>
        <p>Total: ${{ state.total.toFixed(2) }}</p>
    </div>
</template>

<script setup>
import { reactive, onMounted } from 'vue'
// container for items
// hardcoded placeholder
const items = [
    { name: "Rebok", description: "Tennis Shoe", price: 39.99, quantity: 1 },
    { name: "Nike", description: "Fancy Shoe", price: 79.99, quantity: 1 }

]

const taxRate = .08

const state = reactive({
    preTaxTotal: 0,
    taxCost: 0,
    total: 0
})


// Loop through the price of items in cart and get the subTotal
function subTotal() {
    let total = 0;
    for (let i = 0; i < items.length; i++) {
        total += items[i].price * items[i].quantity
    }
    return total;
}

onMounted(() => {

    console.log("Test")
    if (items.length == 0) {
        alert("Cart is Empty")
    }
    state.preTaxTotal = subTotal();
    state.taxCost = state.preTaxTotal * taxRate
    state.total = state.preTaxTotal + state.taxCost
    console.log("Done")
})
</script>
