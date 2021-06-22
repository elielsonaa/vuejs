import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Pacientes from "@/components/Pacientes.vue";
import Vacinas from "@/components/Vacinas.vue";
import Vacinados from "@/components/Vacinados.vue";

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/Vacinas",
    name: "Vacinas",
    component: Vacinas,
    },
    {
    path: "/pacientes",
    name: "Pacientes",
    component: Pacientes,
  },
  {
    path: "/vacinados",
    name: "Vacinados",
    component: Vacinados,
  }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;