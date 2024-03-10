import Vue from 'vue'
import App from './App.vue'
import router from './router'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import store from './store'
import UserService from './services/UserService'

Vue.config.productionTip = false

Vue.component("font-awesome-icon", FontAwesomeIcon);

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')


// UserService.$GetLoggedUser()
// .then((response) => {
//   store.state.user = response.data;
// })
// .catch((error) => {
//   console.log(error);
// });
