<template>
    <div>
        <h2>We have got your order </h2>
        <p><strong>Order Number: </strong> {{ props.id }}</p>
        <p>Your order will ship withn 48 hours.</p>
 
    </div>
</template>

<script setup>

import { defineProps } from 'vue'

const props = defineProps(['id']);


</script>