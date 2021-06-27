<template>
  <div>
    <h1>Relação de Vacinação</h1>
    <div class="container">
      <section v-if="errored">
        <p>Não conseguimos recuperar os dados</p>
      </section>
      <section v-if="vacinados.length < 1">
        <p>Não encontramos registros lançados</p>
      </section>
      <p v-if="loading">
        <em><i class="pi pi-spin pi-spinner" style="fontSize: 2rem"></i></em>
      </p>

      <div class="table-responsive-md">
        <table
          class="table table-striped table-hover"
          aria-labelledby="tableLabel"
          v-if="vacinados"
        >
          <thead>
            <tr>
              <th>Data</th>
              <th>Paciente</th>
              <th>Vacina</th>
              <th>Doses</th>
              <th>Aplicadas</th>
              <th>Restantes</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="vacinado of vacinados" :key="vacinado.id">
              <td>{{ formatDate(vacinado.data) }}</td>
              <td>{{ vacinado.paciente.nome }}{{ vacinado.paciente.sobrenome }}</td>
              <td>{{ vacinado.vacina.nome }}</td>
              <td>{{ vacinado.vacina.doses }}</td>
              <td>{{ vacinado.dosesTomadas }}</td>
              <td>{{ vacinado.vacina.doses - vacinado.dosesTomadas }}</td>
              <td>
                <a href="#" class="link-success" data-toggle="tooltip" title="Visualizar"><i class="pi pi-book btn-space" style="color: green"></i></a>
                <router-link v-bind:to="`/vacinacao/${vacinado.id}`">
                 <a href="#" class="link-warning" data-toggle="tooltip" title="Editar"><i class="pi pi-pencil btn-space"  style="color: orange"></i></a>
                </router-link>
                <a href="#" class="link-danger" data-toggle="tooltip" title="Excluir"><i class="pi pi-trash btn-space" style="color: red"></i></a>
              </td>
            </tr>
          </tbody>
        </table>
        
        <div class="bd-buttom">
          <router-link v-bind:to="`/vacinacao`">
          <button
            type="submit"
            class="btn btn-primary btn-lg btn-space"
            value="Submit"
          >
            Informar Vacinacao
          </button>
         </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import moment from 'moment';
export default {
  name: "Vacinados",
  data() {
    return {
      vacinados: [],
      erros: [],
      errored: false,
      loading: true,
    };
  },
  methods: {
    getVacinados() {
      axios
        .get("/api/vacinacao")
        .then((response) => {
          this.vacinados = response.data;
          console.log(response.data)
        })
        .catch(function(e) {
          this.erros = e.response.data.errors;
          this.errored = true;
        })
        .finally(() => (this.loading = false));
    },
    formatDate: function (value) {
         return moment(String(value)).format('L')
     } 
  },
  mounted() {
      this.getVacinados();
  },
};
</script>
