import { createApp } from 'vue'
// @ts-ignore
import App from './App.vue'
import router from './router' 
import 'bootstrap/dist/js/bootstrap.bundle.js'
import 'bootstrap/dist/css/bootstrap.css'

const app=createApp(App);
app.use(router);
app.mount('#app');
