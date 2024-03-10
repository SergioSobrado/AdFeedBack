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
        Id: 1,
        Name: "Instagram",
        Description: "Social media"
      },
      {
        Id: 2,
        Name: "Facebook",
        Description: "Social media"
      },
      {
        Id: 3,
        Name: "Youtube",
        Description: "Social media"
      },
      {
        Id: 4,
        Name: "Tiktok",
        Description: "Social media"
      }
    ] as PlataformVM[],
    topicAdCategory: [
      {
        Id: 1, 
        Name: "Mascotas",
        Description: "Si"
      },
      {
        Id: 2, 
        Name: "Ejecicio o Deportes",
        Description: "Si"
      },
      {
        Id: 3, 
        Name: "Videojuegos",
        Description: "Si"
      },
      {
        Id: 4, 
        Name: "Cine",
        Description: "Si"
      },
      {
        Id: 5, 
        Name: "Economía",
        Description: "Si"
      },
      {
        Id: 6, 
        Name: "Plataformas de aprendizaje",
        Description: "Si"
      },
      {
        Id: 7, 
        Name: "Alimentos",
        Description: "Si"
      },
      {
        Id: 8, 
        Name: "Tecnología",
        Description: "Si"
      },
      {
        Id: 9, 
        Name: "Sin publicidad",
        Description: "Si"
      }
    ] as TopicVM[]
  }
})
