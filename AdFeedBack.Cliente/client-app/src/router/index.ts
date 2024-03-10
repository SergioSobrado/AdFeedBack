import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import UserProfile from '@/views/UserProfile.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'home',
    meta: { title: 'Home'},
    component: HomeView
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/user',
    name: 'user',
    meta: { title: 'User Profile'},
    component: UserProfile,
  }
]

const router = new VueRouter({
  routes
})


const appTitle = "AdFeedBack";
router.afterEach((to, from) => {
  Vue.nextTick(() => {
    document.title = `${appTitle} - ${to?.meta?.title}` || appTitle;
  });
});
export default router
