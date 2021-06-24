<template>
  <div>
    <h1>Relação de Pacientes</h1>
    <div class="container">
      <section v-if="errors">
        <p>Não conseguimos recuperar os dados</p>
      </section>
      <section v-if="pacientes.length < 1">
        <p>Não encontramos registros lançados</p>
      </section>
      <p v-if="loading">
        <em><i class="pi pi-spin pi-spinner" style="fontSize: 2rem"></i></em>
      </p>
      <div class="table-responsive-md">
        <table
          class="table table-striped table-hover"
          aria-labelledby="tableLabel"
          v-if="pacientes"
        >
          <thead>
            <tr>
              <th>Id</th>
              <th>Nome</th>
              <th>Sexo</th>
              <th>CPF</th>
              <th>Cartão SUS</th>
              <th>Nascimento</th>
              <th>Municipio</th>
              <th>Estado</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="paciente of pacientes" :key="paciente.id">
              <td>{{ paciente.id }}</td>
              <td>{{ paciente.nome }} {{ paciente.sobrenome }}</td>
              <td>{{ paciente.sexo }} </td>
              <td>{{ paciente.cpf }}</td>
              <td>{{ paciente.sus }}</td>
              <td>{{ formatDate(paciente.nascimento) }}</td>
              <td>{{ paciente.municipio }}</td>
              <td>{{ paciente.estado }}</td>
              <td>
                <a href="#" class="link-success" data-toggle="tooltip" title="Visualizar"><i class="pi pi-book btn-space" style="color: green"></i></a>
                <router-link v-bind:to="`/paciente/${paciente.id}`">
                 <a href="#" class="link-warning" data-toggle="tooltip" title="Editar"><i class="pi pi-pencil btn-space"  style="color: orange"></i></a>
                </router-link>
                <a href="#" class="link-danger" data-toggle="tooltip" title="Excluir"><i class="pi pi-trash btn-space" style="color: red"></i></a>
              </td>
            </tr>
          </tbody>
        </table>
        <div class="bd-buttom">
          <button
            type="submit"
            class="btn btn-primary btn-lg btn-space"
            value="Submit"
          >
            Novo Paciente
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import moment from 'moment';
export default {
  name: "Pacientes",
  data() {
    return {
      pacientes: [],
      erros: [],
      loading: true,
    };
  },
  methods: {
    getPacientes() {
      axios
        .get("/api/paciente")
        .then((response) => {
          this.pacientes = response.data;
        })
        .catch(function(e) {
          this.erros = e.response.data.errors;
          alert(this.erros);
        })
        .finally(() => (this.loading = false));
    },
    formatDate: function (value) {
         return moment(String(value)).format('L')
     }
  },
  mounted() {
    this.getPacientes();
  },
};
</script>
