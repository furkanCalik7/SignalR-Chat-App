import "@babel/polyfill";
import "mutationobserver-shim";

// import BootstrapVue from "bootstrap-vue";
// import "bootstrap/dist/css/bootstrap.min.css";
// import "bootstrap-vue/dist/bootstrap-vue.css";

import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";

var app = createApp(App);
app.use(router);
// app.use(BootstrapVue);
app.mount("#app");
