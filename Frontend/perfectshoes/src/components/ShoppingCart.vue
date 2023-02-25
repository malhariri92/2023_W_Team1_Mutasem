
<template>
    <div>
        <DataTable :value="state.order.lineItems" responsiveLayout="scroll">
            <Column field="product.name" header="Name"></Column>
            <Column field="product.description" header="Description"></Column>
            <Column field="unitPrice" header="Price"></Column>
            <Column field="quantity" header="Quantity"></Column>
            <Column header="Change Quantity">
                <template #body="slotProps">
                    <Button icon="pi pi-plus" @click="increaseQuantity(slotProps.index)"/>
                    <Button icon="pi pi-minus" @click="decreaseQuantity(slotProps.index)"/>
                </template>
            </Column>
            <Column header="Delete product?">
                <template #body="slotProps">
                    <Button label="Delete Product" class="p-button-warning" @click="deleteProduct(slotProps.index)"></Button>
                </template>
            </Column>
        </DataTable>
    </div>
    <div>
        <Button label="Empty Cart" class="p-button-danger" @click="emptyCart()"></Button>
        <p>Subtotal cost: ${{ state.preTaxTotal.toFixed(2) }}</p>
        <p>Tax: ${{ state.taxCost.toFixed(2) }}</p>
        <p>Total: ${{ state.total.toFixed(2) }}</p>
    </div>
</template>

<script setup>
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import Button from 'primevue/button';
import { reactive, onMounted } from 'vue'

const taxRate = .08

const state = reactive({
    preTaxTotal: 0,
    taxCost: 0,
    total: 0,
    order: []
})


// Loop through the price of items in cart and get the subTotal
function subTotal() {
    let total = 0;
    console.log(state.order.lineItems.length)
    for (let i = 0; i < state.order.lineItems.length; i++) {
        total += state.order.lineItems[i].unitPrice * state.order.lineItems[i].quantity
    }
    return total;
}

function emptyCart() {
    state.order.lineItems = []
    calcCost()
}
function increaseQuantity(index) {
    state.order.lineItems[index].quantity++    
    calcCost()
}

function decreaseQuantity(index) {
    state.order.lineItems[index].quantity--;
    calcCost()
}

function deleteProduct(index) {
    state.order.lineItems.splice(index, 1);
    calcCost()
}

function calcCost() {
    state.preTaxTotal = subTotal();
    state.taxCost = state.preTaxTotal * taxRate
    state.total = state.preTaxTotal + state.taxCost
}

onMounted(() => {

    state.order = fillDummyOrder()
    if (state.order.lineItems.length == 0) {
        alert("Cart is Empty")
    }
    else {
        calcCost()
    }
    
})

// Place holder for cart data
function fillDummyOrder() {
    const placeHolder = {
        customer:
        {
            id: 0,
            firstName: "string",
            lastName: "string",
            email: "string",
            address: {
                id: 0,
                addressLine1: "string",
                addressLine2: "string",
                city: "string",
                state: "st",
                zip: "strin"
            },
            creditCard: {
                id: 0,
                nameOnCard: "string",
                cardNumber: "string",
                cvc: "str",
                exprDate: "2023-02-22T02:24:47.804Z"
            },
        },
        date: "",
        subtotal: 0,
        tax: 0,
        total: 0,
        lineItems: [
            {
                unitPrice: 89.99,
                quantity: 1,
                productId: 0,
                product: {
                    id: 0,
                    name: "Shoe1",
                    description: "Fancy Shoes",
                    price: 89.99,
                    categoryId: 0,
                },
            },
            {
                unitPrice: 45.99,
                quantity: 2,
                productId: 0,
                product: {
                    id: 0,
                    name: "Shoe2",
                    description: "Crocs",
                    price: 45.99,
                    categoryId: 0,
                },
            }
        ]
    }
    return placeHolder
}

</script>

const order = {
  customer: 
      { id: 0,
        firstName: "string",
       lastName: "string",
      email: "string",
      address: {
          id: 0,
          addressLine1: "string",
          addressLine2: "string",
          city: "string",
          state: "st",
          zip: "strin"
      },
      creditCard: {
          id: 0,
          nameOnCard: "string",
          cardNumber: "string",
          cvc: "str",
          exprDate: "2023-02-22T02:24:47.804Z"},
      },
  date: "",
  subtotal: 0,
  tax: 0,
  total: 0,
  lineItems: [
      {
          unitPrice: 89.99,
          quantity: 1,
          productId: 0,
          product: {
              id: 0,
              name: "Shoe1",
              description: "Fancy Shoes",
              price: 89.99,
              categoryId: 0,
          },
      },
      {
          unitPrice: 45.99,
          quantity: 2,
          productId: 0,
          product: {
              id: 0,
              name: "Shoe2",
              description: "Crocs",
              price: 45.99,
              categoryId: 0,
          },
      }
      ]
  }

const order = {
  "customer": 
      {"id": 0,
      "firstName": "string",
       "lastName": "string",
      "email": "string",
      "address": {
          "id": 0,
          "addressLine1": "string",
          "addressLine2": "string",
          "city": "string",
          "state": "st",
          "zip": "strin"
      },
      "creditCard": {
          "id": 0,
          "nameOnCard": "string",
          "cardNumber": "string",
          "cvc": "str",
          "exprDate": "2023-02-22T02:24:47.804Z"},
      },
  "date": "",
  "subtotal": 0,
  "tax": 0,
  "total": 0,
  "lineItems": [
      {
          "unitPrice": 0,
          "quantity": 0,
          "productId": 0,
          "product": {
              "id": 0,
              "name": "string",
              "description": "string",
              "price": 0,
              "categoryId": 0,
          },
      }
      ]
  }