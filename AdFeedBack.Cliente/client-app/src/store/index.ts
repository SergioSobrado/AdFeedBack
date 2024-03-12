import { PlataformVM, TopicVM, UserVM } from '@/viewmodels'
import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    user: {
            Id: 1,
            Name: "Sergio Sobrado",
            Email: "sergiomanuel1702@gmail.com"
    } as UserVM,
    socialMediaCategory: [
      {
        value: 1,
        text: "No aplica",
      },
      {
        value: 2,
        text: "Instagram",
      },
      {
        value: 3,
        text: "Facebook",
      },
      {
        value: 4,
        text: "Youtube",
      },
      {
        value: 5,
        text: "Tiktok",
      }
    ] as PlataformVM[],
    topicAdCategory: [
      {
        value: 1,
        text: "No aplica",
      },
      {
        value: 2, 
        text: "Mascotas",
      },
      {
        value: 3, 
        text: "Ejecicio o Deportes",
      },
      {
        value: 4, 
        text: "Videojuegos",
      },
      {
        value: 5, 
        text: "Cine",
      },
      {
        value: 6, 
        text: "Economía",
      },
      {
        value: 7, 
        text: "Plataformas de aprendizaje",
      },
      {
        value: 8, 
        text: "Alimentos",
      },
      {
        value: 9, 
        text: "Tecnología",
      }
    ] as TopicVM[]
  }
})
