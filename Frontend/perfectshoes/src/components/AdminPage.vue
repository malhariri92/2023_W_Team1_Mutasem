<template>
  <div>
    <h1>Admin</h1>
    <div v-if="store.userState.user !== null">
    {{ store.userState.user.firstName }}
  </div>
  </div>  
</template>

<script setup>
  import { inject } from "vue"
  const store = inject('store');
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
  