<template>
  <div class="home">
    <div class="nav-bar">
      <h3>Publicaciones</h3>
      <b-button variant="primary" @click="OpenModal">Crear nueva publicación</b-button>
    </div>
    <Publish 
    :publishData="publishData"/>
    <b-modal 
    v-model="showModal"
    centered
    hide-header
    hide-footer
    size="md">
    <div>
      <div> 
        <h2>Crear nueva publicación</h2>
      </div>
      <div class="forms-area">
        <div>
          <h5>Nombre de usuario:</h5>
          <b-input 
          v-model="loggedUser.Name"
          disabled></b-input>
        </div>
        <div>
          <h5>Mensaje:</h5>
          <b-form-textarea 
          placeholder="Intruzca su historia con los anuncios"
          ></b-form-textarea>
        </div>
        <div>
          <h5>Plataforma donde vio la publicidad:</h5>
          <b-form-select v-model="selectedCategory" :options="categoriesName" ></b-form-select>
        </div>  
        <div>
          <h5>Tema sobre el que vio la publicida:</h5>
          <b-form-select v-model="selectedTopic" :options="topicNames" ></b-form-select>
        </div>  
        <div class="modal-buttons">
          <b-button variant="success">Crear</b-button>
          <b-button @click="OpenModal" variant="outline-danger">Cerrar</b-button>
        </div>
      </div>
    </div>  
  </b-modal>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Publish from '@/components/Publish.vue';
import { PostVM } from '@/viewmodels';
import store from '@/store';


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
      showModal: false,
      loggedUser: store.state.user,
      selectedCategory: null,
      selectedTopic: null,
      categoryOptions: store.state.socialMediaCategory,
      adsOptions: store.state.topicAdCategory,
      categoriesName: [{}],
      topicNames: [{}]
    }
  },
  methods: {
    OpenModal() {
      this.showModal =! this.showModal;    
    }
  },
  mounted() {
    this.categoryOptions.forEach((categorie) => 
      {
        this.categoriesName.push(categorie.Name)
      })
      this.adsOptions.forEach((topics) => {
        this.topicNames.push(topics.Name)
      })
  }
});
</script>

<style scoped>
.home {
  height: calc(100vh - 161px);
}

.nav-bar {
  display: flex;
  justify-content: space-between;
  padding: 20px;
  color: #000;
  align-items: center ;
  background-color: #E5E5E5;
  margin-bottom: 20px;
}
.forms-area {
  display: flex;
  flex-direction: column;
  gap: 20px;
}

.modal-buttons {
  display: flex;
  flex-direction: row-reverse;
  justify-content: end;
  gap: 10px;
}
</style>