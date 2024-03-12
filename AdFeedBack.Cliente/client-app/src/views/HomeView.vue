<template>
  <div class="home">
    <div class="nav-bar">
      <h3>Publicaciones</h3>
      <b-button variant="primary" @click="OpenModal">Crear nueva publicación</b-button>
    </div>
    <Publish 
    :publishData="publish"/>
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
          v-model="postMessage"
          placeholder="Intruzca su historia con los anuncios"
          ></b-form-textarea>
        </div>
        <div>
          <h5>Plataforma donde vio la publicidad:</h5>
          <b-form-select v-model="selectedCategory" :options="categoryOptions" ></b-form-select>
        </div>  
        <div>
          <h5>Tema sobre el que vio la publicida:</h5>
          <b-form-select v-model="selectedTopic" :options="adsOptions" placeholder="Seleccione una tema" ></b-form-select>
        </div>  
        <div class="modal-buttons">
          <b-button @click="CreatePost" variant="success">Crear</b-button>
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
import { PlataformVM, PostVM, TopicVM } from '@/viewmodels';
import store from '@/store';


export default Vue.extend({
  name: 'HomeView',
  components: {
    Publish
  },
  data() {
    return {
      publish: [
        {
          UserId: 2,
          UserName: "Sergio Sobrado",
          Plataform: {value: 2, text: "Instagram"} as PlataformVM,
          PostText: "Rara expemriencia con anuncios de Mercadoi Libre",
          Topic: {value: 2, text: "Mascotas"} as TopicVM
        },
        {
          UserId: 1,
          UserName: "Alan Jimenez",
          Plataform: {value: 2, text: "Instagram"} as PlataformVM,
          PostText: "God con las recomendaciones",
          Topic: {value: 2, text: "Mascotas"} as TopicVM
        },
      ] as PostVM[],
      showModal: false,
      loggedUser: store.state.user,
      selectedCategory: 1,
      selectedTopic: 1,
      categoryOptions: store.state.socialMediaCategory,
      adsOptions: store.state.topicAdCategory,
      postMessage: "",
      postCategory: "",
      postTopic: "",
      newPost: {} as PostVM,
      toastVariant: "",
      defaultToastPosition: 'b-toaster-bottom-right'
    }
  },
  methods: {
    OpenModal() {
      this.showModal =! this.showModal;    
    },
    CreatePost() {
      let validPost = this.ValidatePost();
      if(validPost) {
        this.newPost = {
        UserId: this.loggedUser.Id,
        UserName: this.loggedUser.Name,
        Plataform: {value: this.selectedCategory, text: this.categoryOptions[this.selectedCategory-1].text},
        Topic: {value: this.selectedTopic, text: this.adsOptions[this.selectedTopic-1].text},
        PostText: this.postMessage
      };
      this.showModal =! this.showModal;  
      this.publish.push(this.newPost);
      }
    },
    ValidatePost() {
      if(this.selectedCategory!=null && this.selectedTopic!=null && this.postMessage!=""){
        this.toastVariant = 'success';
        this.$bvToast.toast('Se creó correctamente el post', {
          title: `Variant ${this.toastVariant || 'default'}`,
          toaster: this.defaultToastPosition,
          variant: this.toastVariant,
          solid: true
        })
        return true;
      }
      else {
        this.toastVariant = 'danger';
        this.$bvToast.toast('Verifique los campos', {
          title: `Variant ${this.toastVariant || 'default'}`,
          toaster: this.defaultToastPosition,
          variant: this.toastVariant,
          solid: true
        })
      return false;
      }
     
    }
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