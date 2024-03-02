<template>
  <div class="User-Profile">
    <div class="top-user-information">
        <svg width="40" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><path fill="#000" d="M399 384.2C376.9 345.8 335.4 320 288 320H224c-47.4 0-88.9 25.8-111 64.2c35.2 39.2 86.2 63.8 143 63.8s107.8-24.7 143-63.8zM0 256a256 256 0 1 1 512 0A256 256 0 1 1 0 256zm256 16a72 72 0 1 0 0-144 72 72 0 1 0 0 144z"/></svg>
        <span style="font-size: 25px; font-weight: 600;">Sergio Sobrado</span>
    </div>
    <div class="pusblish-zone">
        <span>{{ texto }}</span>
        <publish />
    </div>
  </div>
</template>

<script lang="ts">
import Publish from '@/components/Publish.vue'
import Services from '@/services/GetString'
import { defineComponent } from 'vue'

export default  defineComponent({
    components: { Publish },
    data() {
        return {
            texto: ""
        }
    },
    mounted(){
        this.GetStrings();
    },
    methods: {
        GetStrings() {
            Services.$GetString() 
            .then((response) => {
                this.texto = response.data;
            })
            .catch((error) => {
                console.log(error);
            })
        }
    }
});
</script>

<style scoped>
.User-Profile {
    height: calc(100vh - 161px);
    background-color: #ffffff;
}
.top-user-information {
    display: flex;
    align-items: center;
    gap: 8px;
    padding: 24px 8px;
    height: 10%;
    background-color: rgba(208, 206, 206, 0.393);
    border: 1xp solid rgba(180, 171, 171, 0.776);
}

</style>
