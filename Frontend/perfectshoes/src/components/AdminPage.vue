<template>
  <div>
    <h1>Admin</h1>
    {{ store.user.value.firstName }}
  </div>  
</template>

<script setup>
  import { inject } from "vue"
  const store = inject('store');
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
  