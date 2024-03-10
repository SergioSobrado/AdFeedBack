<template>
    <div class="publis-wrapper">
        <div class="publish" v-for="(publicacion, index) in publishData" :key="index">
            <div class="header-publish">
              <svg width="40" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><path fill="#000" d="M399 384.2C376.9 345.8 335.4 320 288 320H224c-47.4 0-88.9 25.8-111 64.2c35.2 39.2 86.2 63.8 143 63.8s107.8-24.7 143-63.8zM0 256a256 256 0 1 1 512 0A256 256 0 1 1 0 256zm256 16a72 72 0 1 0 0-144 72 72 0 1 0 0 144z"/></svg>
              <span>{{ publicacion.UserName }} </span>
            </div>
            <div class="content">
                <div class="categories">
                    <div>{{ publicacion.PlattaformId }}</div>
                    <div>{{ publicacion.TopicId }}</div>
                </div>
                <p>{{ publicacion.PostText }}</p>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { PostVM } from '@/viewmodels';
import { defineComponent } from 'vue';

export default defineComponent({ 
    name: "Publish",
    props: {
      publishData: []
    },
    data() {
        return {
            titulo: "",
            suma: 0,
            mostrar: false,
        }
    },
});
</script>

<style scoped>
.header-publish {
    display: flex;
    align-items: center;
    width: 100%;
    padding: 15px;
    gap: 8px;
    background-color: #6b6b6b2b ;
    border-radius: 10px 10px 0px 0px;
    border-left: 2px solid #6b6b6b2b;
    border-right: 2px solid #6b6b6b2b;
    border-bottom: 2px solid #6b6b6b2b;
}
.header-publish span {
    font-weight: 700;
}
.publish {
    width: 70%;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    margin-left: 15%;
    margin-right: 15%;
}
.categories {
    width: 20%;
    display: flex;
    justify-content: start;
    gap: 10px;
    margin-left: 1%;
    margin-top: 1%;
    font-weight: 600;
}
.categories div {
    background-color: #73C6F4;
    padding: 4px;
    font-size: 10px;
}
.content {
    width: 100%;
    padding: 15px;
    gap: 8px;
    background-color: #ffffff2b ;
    border-left: 2px solid #6b6b6b2b;
    border-right: 2px solid #6b6b6b2b;
    border-bottom: 2px solid #6b6b6b2b;
    border-radius: 0px 0px 10px 10px;
}
.content p {
    display: flex;
    padding: 15px;
    font-weight: 400;
}
.publis-wrapper {
    display: flex;
    flex-direction: column;
    gap: 20px;
}
</style>