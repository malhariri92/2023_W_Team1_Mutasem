<template>
  <div>
    <form id="addProduct" class="col-lg-10 offset-lg-1 ">
        <div class="row g-3 justify-content-center flex" >
            <div class="col-4">
                <input v-model="state.product.name" required type="text" class="form-control" placeholder="Product Name *"
                    oninvalid="this.setCustomValidity('Product name is required')"
                    oninput="this.setCustomValidity('')">
            </div>
            <div class="col-4">
                <select v-model="state.categoryId" class="form-select" required 
                    oninvalid="this.setCustomValidity('Category is required')"
                    oninput="this.setCustomValidity('')">
                     <option disabled selected value="">Select Category *</option>
                     <option v-for="(item, index) in state.categories" :key="index" :value="item.id">{{item.name}}</option>
                </select>
            </div>
        </div>
        <div class="row g-3 justify-content-center mt-2">
            <div class="col-8">
                <textarea v-model="state.product.description" class="form-control" rows="3" placeholder="Product Description *" 
                required oninvalid="this.setCustomValidity('Description is required')"
                    oninput="this.setCustomValidity('')"/>
            </div>
        </div>
        <div class="row g-3 justify-content-center mt-2">
            <div class="col-4">
                <input v-model="state.qty" type="number" class="form-control" placeholder="QTY *" min="0" required 
                    oninvalid="this.setCustomValidity('QTY is required')"
                    oninput="this.setCustomValidity('')">
            </div>
            <div class="col-4">
                <input v-model="state.price" type="number" step="0.01" class="form-control" min="0" placeholder="Price *" required>
            </div>
        </div>
        <div class="row g-3 justify-content-center mt-2">
            <div class="col-8">
                <input v-model="state.product.imageUrl" type="text" class="form-control" placeholder="Image URL *" required
                    oninvalid="this.setCustomValidity('Image Url is required')"
                    oninput="this.setCustomValidity('')">
            </div>
        </div>
        <div>
            <div v-for="(attr, index) in state.product.specs" :key="index" class="row g-3 justify-content-center mt-2">
            <div class="col-md-5">
                <input v-model="attr['name']" type="text" class="form-control" placeholder="Attribute Name *" required 
                oninvalid="this.setCustomValidity('Attribute name is required!')"
                    oninput="this.setCustomValidity('')">
            </div>
            <div class="col-2">
                <input v-model="attr['value']" type="text" class="form-control" placeholder="Value *" required
                oninvalid="this.setCustomValidity('Attribute value is required!')"
                    oninput="this.setCustomValidity('')">
            </div>
            <div class="col-1">
                <p class="mt-2 addSpec" @click.prevent="removeSpec(index)">Remove</p>
            </div>
        </div>
        </div>

        <div class="row g-3 justify-content-center mt-2">
            <div class="col-8">
                <p class="addSpec mx-auto" @click.prevent="addSpec">Add Attribute</p>
            </div>
        </div>

        <div class="row g-1 justify-content-center mt-2">
            <!-- <button type="submit" class="btn btn-danger col-4 ms-1" @click.prevent="close"> Cancel</button> -->
            <Button label="Cancel" @click="close" class="p-button-danger col-4 ms-1"/>
            <Button type="submit" label="Save" @click="insertProduct($event)" class="p-button-success col-4 ms-1"/>
            <!-- <button type="submit" class="btn btn-success col-4 ms-1" @click="insertProduct($event)">Save </button>  -->
        </div>
        <div class="row g-3 justify-content-center mt-2">
            <div class="col-8 mb-3">
                <span>* indicates a field is required.</span>
                <div style="display:none;" id="msg" class="alert alert-success mt-1" role="alert">
                    Product has been successfully added!
                </div>
                <div style="display:none;" id="editmsg" class="alert alert-success mt-1" role="alert">
                    Your changes has been saved successfully!
                </div>
            </div>
        </div>

    </form>
  </div>
</template>
    
<script setup>
import { reactive, onMounted, inject } from "vue";
import $ from 'jquery'
import Button from 'primevue/button';
import ProductState from '../store/ProductState';

const dialogRef = inject("dialogRef");
const header = dialogRef.value.options.props.header;
const store = inject("store");
const state = reactive(dialogRef.value.data.productState);

 onMounted(() =>  {
    // Object.assign(state.value, dialogRef.value.data.productState.value);
    console.log(state);
    $.ajax({
        url: 'https://localhost:44310/api/categories',
        method: 'get'
      }).done(data => {
        state.categories = data;
      }) 
      
});

function addSpec() {
    state.product.specs.push({"name":'', "value":''});
    if(header === 'Edit Product') {
        state.product.specs['id'] = state.product.id;
    }
    console.log(state.specs);
}

function removeSpec(index) {
    state.product.specs.splice(index,1);
}
function validateProduct(){
    if (state.product.categoryId <= 0 |
    state.product.name === "" |
    state.product.description === "" |
    state.product.imageUrl === "" |
    state.product.price <= 0.00 |
    state.product.quantity <= 0) return false;

    if(state.product.specs.length > 0) {
        state.specs.forEach(e => {
            if (e.name === '' | e.value === '') {
                return false;
            }
        })
    } 
    return true;
}

function insertProduct(e) {   
    state.product.categoryId = state.categoryId;
    state.product.price = state.price;
    state.product.quantity = state.qty;
    console.log(state.product);
    if (!validateProduct()) return;
    e.preventDefault();
    
    if(header === 'Add Product') {
        $.ajax({
        headers: { 
        'Accept': 'application/json',
        'Content-Type': 'application/json' 
        },
        'url': 'https://localhost:44310/api/Products',
        'method': 'post',
        'data': JSON.stringify(state.product)
      }).done( () => {
        Object.assign(state, new ProductState());
        store.methods.loadProducts();
        $("#msg").show().delay(5000).fadeOut();
      });
    }
    else if(header === 'Edit Product') {
        $.ajax({
        headers: { 
        'Accept': 'application/json',
        'Content-Type': 'application/json' 
        },
        'url': 'https://localhost:44310/api/Products',
        'method': 'put',
        'data': JSON.stringify(state.product)
      }).done( () => {
        store.methods.loadProducts();
        $("#editmsg").show().delay(5000).fadeOut();
        dialogRef.value.close();
      });
    }
     
}
function close() {
    dialogRef.value.close();
    store.methods.loadProducts();
}
</script>
    
    <!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1 {
    margin: 0 auto;
}

.addSpec {
    color:blue;
    cursor: pointer;
    text-decoration: underline;
}
.addSpec:hover {
    color:rgb(218, 28, 28);
    cursor: pointer;
}
#addProduct {
    overflow-x: hidden;
}
</style>