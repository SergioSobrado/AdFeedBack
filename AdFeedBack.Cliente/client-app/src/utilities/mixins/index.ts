import BootstrapVue from "bootstrap-vue";
import Vue from "vue";
Vue.use(BootstrapVue);
const GlobalMixins = {
    methods: {
        $IsNull(item: any): boolean {
            return item == null;
        }
    }
}

export default GlobalMixins;