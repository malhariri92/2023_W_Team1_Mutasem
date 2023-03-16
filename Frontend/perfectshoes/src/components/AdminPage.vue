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
                      {{ slotProps.data.date }}
                  </template>
              </Column>
              <template #footer>
                  In total there are {{ store.orders.value ? store.orders.value.length : 0 }} orders.
              </template>
          </DataTable>
      </div>
  </div>
</template>

<script setup>
import { inject, onMounted } from 'vue';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import 'primeicons/primeicons.css';


const store = inject('store');


onMounted(() => {
  store.methods.loadOrders();
});

const onRowSelect = (event) => {
    // add logic here to display the additional info
    alert(event.data.id);
};

</script>

<style scoped>
</style>
