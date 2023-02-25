<template>
    <div>
        <DataTable :value="store.products.value" responsiveLayout="scroll">
            <template #header>
                <div class="table-header">
                    <TestDialog title="New Product" dialogTitle="Add Product" v-bind:component="AddProduct" width="40vw" v-bind:dialog="dialog"/>
                    <TestDialog title="New Category" dialogTitle="Add Category" v-bind:component="AddCategory" width="40vw" v-bind:dialog="dialog"/>
                    <DynamicDialog />
                </div>
            </template>
            <Column field="name" header="Name">
              <template #body="slotProps">
              <h3>{{ slotProps.data.name}}</h3> 
              </template>
            </Column>
            <Column header="Image">
                <template #body="slotProps">
                    <img :src="slotProps.data.imageUrl" :alt="slotProps.data.description" class="product-image" />
                </template>
            </Column>
            <Column field="price" header="Price">
                <template #body="slotProps">
                  ${{slotProps.data.price.toFixed(2)}}
                </template>
            </Column>
            <Column header="Status">
                <template #body="slotProps">
                    <span class="product-badge status-outofstock" v-if="slotProps.data.quantity == 0"> OUTOFSTOCK</span>
                    <span class="product-badge status-lowstock" v-else-if="slotProps.data.quantity <= 10 && slotProps.data.quantity != 0"> LOWSTOCK</span>
                    <span class="product-badge status-instock" v-else> INSTOCK</span>
                </template>
            </Column>
            <Column>
                <template #body>
                  <span>
                      <Button label="Edit" icon="pi pi-file-edit" class="p-button-success" style="margin-right: .9em"/>
                      <Button label="Delete" icon="pi pi-trash" class="p-button-danger" />
                  </span>
                </template>
            </Column>
            <template #footer>
                In total there are {{store.products.value ? store.products.value.length : 0 }} products.
            </template>
        </DataTable>
    </div>  
  </template>
  
<script setup>
  import { inject } from 'vue'
  import DataTable from 'primevue/datatable';
  import Column from 'primevue/column';
  import Button from 'primevue/button';
  import AddProduct from '@/components/AddProduct.vue'
  import AddCategory from '@/components/AddCategory.vue'
  import 'primeicons/primeicons.css';
  import TestDialog from '@/components/TestDialog.vue';
  import { useDialog } from 'primevue/usedialog';
  import { provide } from 'vue';
  import DynamicDialog from 'primevue/dynamicdialog';

  const store = inject('store');
  const dialog = useDialog();
  provide('dialog', dialog);

</script>
  
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
 
.table-header {
    text-align: center;
    margin: 20px;
}

.product-image {
    width: 60px;
    box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23)
}


</style>
  