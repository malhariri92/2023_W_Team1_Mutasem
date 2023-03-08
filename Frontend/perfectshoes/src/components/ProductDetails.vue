<template>
  <div>
    <div class="productDetails">
      <div class="productsDetails">
        <div class="productImage">
          <img :src=state.product.imageUrl :alt="state.product.description" />
        </div>
        <div class="productDetailsPanel">
          <div class="productNameAndPrice">
            <h4><b>{{ state.product.name }}</b></h4>
            ${{ state.product.price }}
          </div>
          <div class="productDescription">
            <h5>Description:</h5>
            {{ state.product.description }}
          </div>
          <div class="productOptions" v-if="state.product.specs !== null && state.product.specs.length !== 0">
            <h5>Avalable Options: </h5>
            <div v-for="(attr, index) in state.product.specs" :key="index">
              <p>{{ attr.name }} - {{ attr.value }}</p>
            </div>
          </div>
        </div>
      </div>
      <div class="buttons">
        <button class="btn btn-primary col-4 ms-1" @click="back">Back </button>
        <button class="btn btn-success col-4 ms-1" @click="addToCart">Add to Cart </button>
        <div style="display:none; margin: 0 auto" id="msg" class="alert alert-success mt-2 col-8" role="alert">
          Product was added to your cart!
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { inject, reactive } from 'vue';
import { useRouter } from 'vue-router';
import $ from 'jquery';

const router = useRouter();
const store = inject('store');

const state = reactive({
  product: store.currentProduct.value
});

function back() {
  router.push('/');
}

function addToCart() {
  let isInCart = false;
  if (store.cart.order.lineItems.length > 0) {
    for (let i = 0; i < store.cart.order.lineItems.length; i++) {
      if (store.cart.order.lineItems[i].productId === state.product.id) {
        store.cart.order.lineItems[i].quantity++;
        isInCart = true;
        break;
      }
    }
  }
  if (isInCart) {
    store.methods.persistCart();
    $("#msg").show().delay(3000).fadeOut();
  }
  else {
    const lineItem =
    {
      "unitPrice": state.product.price,
      "quantity": 1,
      "productId": state.product.id,
      "product": state.product
    };
    store.cart.order.lineItems.push(lineItem);
    store.methods.persistCart();
    $("#msg").show().delay(3000).fadeOut();
  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
div.productsDetails {
  display: flex;
  flex-wrap: wrap;
  width: 100%;
  justify-content: center;
  margin: 50px 0;
}

div.productImage {
  display: flex;
  flex-wrap: wrap;
  width: 50%;
  justify-content: center;
  margin: 50px 0;
}

div.productNameAndPrice {
  flex-wrap: wrap;
  width: 50%;
  justify-content: center;
  margin: 50px 0;
}

div.productOptions {
  width: 50%;
  justify-content: center;
  margin: 50px 0;
}

div.productDescription {
  flex-wrap: wrap;
  width: 50%;
  justify-content: center;
  margin: 50px 0;
}

div.productDetailsPanel {
  flex-wrap: wrap;
  width: 50%;
  justify-content: center;
  margin: 50px 0;
}

img {
  width: 300px;
  height: 300px;
  text-align: center;
  margin: 0 auto;
  display: block;
}

.product {
  width: 20%;
  /* height: 5%; */
  margin: 15px;
  box-sizing: border-box;
  float: left;
  border-radius: 20px;
  box-shadow: 0 14px 28px rgba(0, 0, 0, 0.25);
  background: #f2f2f2;
  cursor: pointer;

}

.product:hover {
  outline: .1rem solid blue
}
</style>
