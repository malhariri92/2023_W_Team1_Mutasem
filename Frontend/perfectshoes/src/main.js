import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"
import { library } from '@fortawesome/fontawesome-svg-core'
import { fas } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import PrimeVue from 'primevue/config';
import DialogService from 'primevue/dialogservice';
import 'primevue/resources/primevue.min.css';
import 'primeicons/primeicons.css';   
import 'primevue/resources/themes/lara-light-indigo/theme.css';   
import 'primeicons/primeicons.css';   
import DynamicDialog from 'primevue/dynamicdialog';
import ConfirmationService from 'primevue/confirmationservice';
import ConfirmDialog from 'primevue/confirmdialog';

library.add(fas);
const app = createApp(App)
app.use(router);
app.use(PrimeVue, {ripple: true});
app.use(DialogService);
app.use(ConfirmationService);
app.component('DynamicDialog', DynamicDialog);
app.component('font-awesome-icon', FontAwesomeIcon);
app.component('ConfirmDialog', ConfirmDialog);
app.mount("#app");
