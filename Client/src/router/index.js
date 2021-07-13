import { createRouter, createWebHistory } from "vue-router";
import LoginScreen from "../views/LoginScreen.vue";
import ChatScreen from "../views/ChatScreen.vue";

const routes = [
  {
    path: "/",
    name: "Login",
    component: LoginScreen,
  },
  {
    name: "chatScreen",
    path: "/ChatScreen",
    component: ChatScreen,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
