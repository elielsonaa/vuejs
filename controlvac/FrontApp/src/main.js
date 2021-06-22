import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'primevue/resources/primevue.min.css';
import 'primeicons/primeicons.css';
import PrimeVue from 'primevue/config';
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'


createApp(App).use(PrimeVue)
   .use(router).mount('#app')