<template>
    <div>
        <div style="width: 90%; margin: 0 auto;">
        <DataTable :paginator="true" :value="store.products.value" responsiveLayout="scroll" :rows="5"
        paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink
         LastPageLink CurrentPageReport RowsPerPageDropdown" :rowHover="true" :rowsPerPageOptions="[5,10,25,50]" 
         currentPageReportTemplate="Showing {first} to {last} of {totalRecords} entries">
            <template #header>  
                <div class="row g-3 justify-content-between flex">
                    <div class="col-1">
                        <Button @click="addProduct" label="Product" icon="pi pi-plus" class="p-button-primary"/>
                    </div>
                    <div class="col-2 mt-4">
                        <span class="p-input-icon-right">
                            <i class="pi pi-search" />
                            <input class="form-control" placeholder="Keyword Search" />
                        </span>
                    </div>
                </div>
                <DynamicDialog />
            </template>
            <Column field="name" header="Name">
              <template #body="slotProps">
              <h4>{{ slotProps.data.name}}</h4> 
              </template>
            </Column>
            <Column header="Image">
                <template #body="slotProps">
                    <img :src="slotProps.data.imageUrl" :alt="slotProps.data.description" class="product-image" />
                </template>
            </Column>
            <Column field="description" header="Description">
                <template #body="slotProps">
                    <p :title="slotProps.data.description">{{ slotProps.data.description }}</p>
                </template>
            </Column>
            <Column field="price" header="Price">
                <template #body="slotProps">
                  ${{slotProps.data.price.toFixed(2)}}
                </template>
            </Column>
            <Column field="category.name" header="Category">
                <template #body="slotProps">
                 <strong> {{slotProps.data.category.name}}</strong>
                </template>
            </Column>
            <Column header="Status">
                <template #body="slotProps">
                    <span class="product-badge outofstock" v-if="slotProps.data.quantity == 0"> OUTOFSTOCK</span>
                    <span class="product-badge lowstock" v-else-if="slotProps.data.quantity <= 10 && slotProps.data.quantity != 0">
                         LOWSTOCK</span>
                    <span class="product-badge instock" v-else> INSTOCK</span>
                </template>
            </Column>
            <Column>
                <template #body="slotProps">
                        <SpeedDial @click="setItem(slotProps.data)" :model="options" direction="left" showIcon="pi pi-cog" />                  
                </template>
            </Column>
            <template #footer>
                In total there are {{store.products.value ? store.products.value.length : 0 }} products.
            </template>
        </DataTable>
        </div>
    </div>  
</template>
  
<script setup>
  import { inject, onMounted, ref, provide } from 'vue';
  import DataTable from 'primevue/datatable';
  import Column from 'primevue/column';
  import Button from 'primevue/button';
  import SpeedDial from 'primevue/speeddial';
  import 'primeicons/primeicons.css';
  import { useDialog } from 'primevue/usedialog';
  import AddProduct from '@/components/AddProduct.vue'
  //import AddCategory from '@/components/AddCategory.vue';
  import DynamicDialog from 'primevue/dynamicdialog';
  import ProductState from'../store/ProductState';


  const dialog = useDialog();
  provide('dialog', dialog);

  const store = inject('store');
  const selectedProduct = ref({});
  onMounted(() => {
    store.methods.loadProducts();
  });

  const options = ref( [
    {
        label: 'Remove',
        icon: 'pi pi-trash',
    },
    {
        label: 'Edit',
        icon: 'pi pi-file-edit',
        command: () => {editProduct(selectedProduct)}
    },
  ]);

  function setItem(item) {
    selectedProduct.value = item;
  }

  function addProduct() {
    const state = new ProductState();
    dialog.open(AddProduct, {
              props: {
                header: 'Add Product',
                  style: {
                    width: '40vw',
                  }, 
                  breakpoints:{
                    '960px': '75vw',
                    '640px': '90vw'
                },               
                modal: true,
              }, 
              data: {productState: state}                     
          });
    }

    function editProduct(p) {
        const state = new ProductState();
        state.product = p.value;
        state.product.specs = p.value.specs?.slice();
        state.specs = p.value.specs?.slice();
        state.categoryId = p.value.categoryId;
        state.price = p.value.price;
        state.qty = p.value.quantity;
        console.log(state);
        dialog.open(AddProduct, {
              props: {
                header: 'Edit Product',
                  style: {
                    width: '40vw',
                  }, 
                  breakpoints:{
                    '960px': '75vw',
                    '640px': '90vw'
                },               
                modal: true,
              }, 
              data: {productState: state}                     
          });
    }
    
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
.outofstock {
    font-weight: 700;
    color: #FF5252;
    text-decoration: line-through;
}

.lowstock {
    font-weight: 700;
    color: #FFA726;
}

.instock {
    font-weight: 700;
    color: #66BB6A;
}
p {
    text-overflow:ellipsis; /* will make [...] at the end */
    width: 90px; /* change to your preferences */
    white-space: nowrap; /* paragraph to one line */
    overflow:hidden; /* older browsers */
}


</style>
  