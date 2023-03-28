<template>
  <div>
      <div style="width: 90%; margin: 0 auto;">
          <DataTable :paginator="true" :value="store.orders.value" responsiveLayout="scroll" :rows="5"
              paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink
           LastPageLink CurrentPageReport RowsPerPageDropdown" :rowHover="true" :rowsPerPageOptions="[5, 10, 25, 50]" 
              currentPageReportTemplate="Showing {first} to {last} of {totalRecords} entries" 
               @rowSelect="onRowSelect"  selectionMode="single" :metaKeySelection="false">

              <template #empty>
                  No Order found.
              </template>
              
              <Column field="id" header="Order id">
                  <template #body="slotProps">
                      {{ slotProps.data.id }}
                  </template>
              </Column>

              <Column field="customerName" header="Customer">
                  <template #body="slotProps">
                      {{ slotProps.data.customerName }}
                  </template>
              </Column>

              <Column field="customerEmail" header="Email">
                  <template #body="slotProps">
                      {{ slotProps.data.customerEmail }}
                  </template>
              </Column>

              <Column field="date" header="Date" sortable>
                  <template #body="slotProps">
                      {{ slotProps.data.date.replace('T', ' ').slice(0, 19) }}
                  </template>
              </Column>
              <template #footer>
                  In total there are {{ store.orders.value ? store.orders.value.length : 0 }} orders.
              </template>
          </DataTable>
         
          <DynamicDialog />
      </div>
  </div>
</template>

<script setup>
import { inject, onMounted, provide } from 'vue';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import 'primeicons/primeicons.css';

import { useDialog } from 'primevue/usedialog';
import OrdersDetails from '../components/OrdersDetails.vue';


const store = inject('store');
const dialog = useDialog();
provide('dialog', dialog);


onMounted(() => {
  store.methods.loadOrders();
});

const onRowSelect = (event) => {
    console.log(event.data)
    dialog.open(OrdersDetails, {
        props: {
            header: 'Order Details',
            style: {
                width: '40vw',
            },
            breakpoints: {
                '960px': '75vw',
                '640px': '90vw'
            },
            modal: true,
        },
        data: { Order: event.data }
    });
    
};

</script>

<style scoped>
</style>
