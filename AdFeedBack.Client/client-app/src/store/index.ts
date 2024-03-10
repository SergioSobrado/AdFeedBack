import { UserVM } from '@/viewmodels'
import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    user: {
            Id: 1,
            Name: "Sergio Sobrado",
            Email: "sergiomanuel1702@gmail.com"
    } as UserVM
  }
})
