<template>
    <div>
        <div style="width: 90%; margin: 0 auto;">
            <DataTable :paginator="true" :value="store.products.value" responsiveLayout="scroll" :rows="5"
                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink
             LastPageLink CurrentPageReport RowsPerPageDropdown" :rowHover="true" :rowsPerPageOptions="[5, 10, 25, 50]"
                currentPageReportTemplate="Showing {first} to {last} of {totalRecords} entries" :filters="filters1"
                :globalFilterFields="['name', 'description', 'category.name']" removableSort>
                <template #header>
                    <div class="row g-3 justify-content-between flex">
                        <div class="col-1 d-flex flex-row">
                        <div>
                            <Button @click="addProduct" label="Product" icon="pi pi-plus" class="p-button-primary" />
                        </div>
                        <div>
                            <Button v-if="store.userState.user.role === 'manager'" @click="addEmployee" label="Employee" icon="pi pi-plus" class="p-button-primary ms-1" />
                        </div>
                        </div>
                        <div class="col-2 mt-4">
                            <span class="p-input-icon-right">
                                <i class="pi pi-search" />
                                <input class="form-control" placeholder="Keyword Search"
                                    v-model="filters1['global'].value" />
                            </span>
                        </div>
                    </div>
                    <DynamicDialog />
                </template>
                <template #empty>
                    No product found.
                </template>
                <Column field="name" header="Name" sortable>
                    <template #body="slotProps">
                        <h4>{{ slotProps.data.name }}</h4>
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
                <Column field="price" header="Price" sortable>
                    <template #body="slotProps">
                        ${{ slotProps.data.price.toFixed(2) }}
                    </template>
                </Column>
                <Column field="category.name" header="Category" sortable>
                    <template #body="slotProps">
                        <strong> {{ slotProps.data.category.name }}</strong>
                    </template>
                </Column>
                <Column field="quantity" header="Status" sortable>
                    <template #body="slotProps">
                        <span class="product-badge outofstock" v-if="slotProps.data.quantity == 0"> OUTOFSTOCK</span>
                        <span class="product-badge lowstock" v-else-if="slotProps.data.quantity <= 10">
                            LOWSTOCK</span>
                        <span class="product-badge instock" v-else> INSTOCK</span>
                    </template>
                </Column>
                <Column>
                    <template #body="slotProps">
                        <SpeedDial @click="setItem(slotProps.data)" :model="options" direction="left"
                            showIcon="pi pi-cog" />
                    </template>
                </Column>
                <template #footer>
                    In total there are {{ store.products.value ? store.products.value.length : 0 }} products.
                </template>
            </DataTable>
        </div>
        <ConfirmDialog />
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
import AddEmployee from '@/components/AddEmployee.vue'
import ProductState from '../store/ProductState';
import EmployeeState from '../store/EmployeeState';
import { FilterMatchMode } from 'primevue/api';
import $ from 'jquery';
import { useConfirm } from "primevue/useconfirm";


const dialog = useDialog();
provide('dialog', dialog);
const confirm = useConfirm();

const store = inject('store');
const selectedProduct = ref({});
onMounted(() => {
    store.methods.loadProducts();
});

const options = ref([
    {
        label: 'Remove',
        icon: 'pi pi-trash',
        command: () => { removeProduct(selectedProduct) }
    },
    {
        label: 'Edit',
        icon: 'pi pi-file-edit',
        command: () => { editProduct(selectedProduct) }
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
            breakpoints: {
                '960px': '75vw',
                '640px': '90vw'
            },
            modal: true,
        },
        data: { productState: state }
    });
}

function addEmployee() {
    const state = new EmployeeState();
    state.employee.Role = "admin"
    dialog.open(AddEmployee, {
        props: {
            header: 'Add Employee',
            style: {
                width: '40vw',
            },
            breakpoints: {
                '960px': '75vw',
                '640px': '90vw'
            },
            modal: true,
        },
        data: { employeeState: state }
    });
}

function editProduct(p) {
    const state = new ProductState();
    Object.assign(state.product, p.value);
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
            breakpoints: {
                '960px': '75vw',
                '640px': '90vw'
            },
            modal: true,
        },
        data: { productState: state }
    });
}
function removeProduct(p) {
    p.value.isActive = false;
    confirm.require({
                message: 'Are sure you want to permenantly delete this Product?',
                header: 'Delete Confirmation',
                icon: 'pi pi-exclamation-triangle',
                acceptClass: 'p-button-danger',
                accept: () => {
                    $.ajax({
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        'url': 'https://localhost:44310/api/Products',
                        'method': 'put',
                        'data': JSON.stringify(p.value)
                    }).done(() => {
                        store.methods.loadProducts();
                        $("#editmsg").show().delay(3000).fadeOut();
                    });
                },
                reject: () => {
                    //nothing
                }
            });   
}
const filters1 = ref({
    'global': { value: null, matchMode: FilterMatchMode.CONTAINS }
});
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
    text-overflow: ellipsis;
    /* will make [...] at the end */
    width: 90px;
    /* change to your preferences */
    white-space: nowrap;
    /* paragraph to one line */
    overflow: hidden;
    /* older browsers */
}</style>
  