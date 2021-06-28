import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"
import 'primevue/resources/primevue.min.css';
import 'primeicons/primeicons.css';
import PrimeVue from 'primevue/config';
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

createApp(App).use(PrimeVue)
   .use(router).mount('#app')