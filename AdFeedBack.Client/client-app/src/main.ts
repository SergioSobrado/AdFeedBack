import Vue from 'vue'
import App from './App.vue'
import router from './router'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import store from './store'
import UserService from './services/UserService'
import BootstrapVue from 'bootstrap-vue'

import "bootstrap/dist/css/bootstrap.css"
import "bootstrap-vue/dist/bootstrap-vue.css"

Vue.config.productionTip = false

Vue.component("font-awesome-icon", FontAwesomeIcon);


Vue.use(BootstrapVue);

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
