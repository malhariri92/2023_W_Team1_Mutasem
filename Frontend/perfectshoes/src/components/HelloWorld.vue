<template>
  <div class="hello">
    <h1>{{ message }}</h1>
    <h1>{{ props.msg }}</h1>
    <p>The count in the child: {{ props.childCount }}</p>
  </div>  
</template>

<script setup>
import { defineProps, onMounted } from 'vue'

const props = defineProps(['msg', 'childCount']);
const message = "Message in the child";
 
onMounted(() => {
  console.log(props);
}) 

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
