<template>
  <div class="home">
    <Publish />
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Publish from '@/components/Publish.vue';

export default Vue.extend({
  name: 'HomeView',
  components: {
    Publish
  },
});
</script>
