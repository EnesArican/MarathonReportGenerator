
import Vue from 'vue';
import App from './App.vue';
import Vuetify from 'vuetify';
import 'vuetify/dist/vuetify.min.css';
import { router } from './shared/router';

Vue.use(Vuetify);



Vue.config.productionTip = false;

const app = new Vue({
    el: '#app',
    vuetify: new Vuetify(),
    render: (h) => h(App),
    router,
});
