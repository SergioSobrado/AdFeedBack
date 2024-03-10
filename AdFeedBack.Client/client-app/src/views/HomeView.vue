<template>
  <div class="home">
    
    <Publish 
    :publishData="publishData"/>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Publish from '@/components/Publish.vue';
import { PostVM } from '@/viewmodels';

export default Vue.extend({
  name: 'HomeView',
  components: {
    Publish
  },
  data() {
    return {
      publishData: [
        {
          UserId: 2,
          UserName: "Sergio Sobrado",
          PlattaformId: 1,
          PostText: "Rara experiencia con anuncios de Mercadoi Libre",
          TopicId: 1
        },
        {
          UserId: 1,
          UserName: "Alan Jimenez",
          PlattaformId: 1,
          PostText: "God con las recomendaciones",
          TopicId: 1
        },
      ] as PostVM[],
    }
  }
});
</script>

<style scoped>
.home {
  height: calc(100vh - 161px);
}
</style>