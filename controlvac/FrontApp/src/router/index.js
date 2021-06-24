import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Pacientes from "@/components/Pacientes.vue";
import Vacinas from "@/components/Vacinas.vue";
import Vacinados from "@/components/Vacinados.vue";
import Paciente from "@/view/Paciente.vue";
import Vacina from "@/view/Vacina.vue";
import Vacinacao from "@/view/Vacinacao.vue";

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
  },
  {
    path: "/vacina/:id",
    name: "Vacina",
    component: Vacina,
  },
  {
    path: "/paciente/:id",
    name: "Paciente",
    component: Paciente,
  },
  {
    path: "/vacinacao/:id",
    name: "Vacinacao",
    component: Vacinacao,
  }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;