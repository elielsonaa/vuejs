<template>
<div>
  <h1>Relação de Vacinação</h1>
  <div class="container">
    <section v-if="errored">
      <p>Não conseguimos recuperar os dados</p>
    </section>
    <p v-if="loading"><em><i class="fas fa-spinner " style="fontSize: 2rem"></i></em></p>

    <table
      class="table table-striped"
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
          <th>Doses Restates</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="vacinado of vacinados" :key="vacinado.id">
          <td>{{ vacinado.nome }}</td>
        </tr>
      </tbody>
    </table>
    <div class="bd-buttom">
      <button
        type="submit"
        class="btn btn-primary btn-lg btn-space"
        value="Submit"
      >
        Informar Vacinacao
      </button>
    </div>
  </div>
</div>
</template>


<script>
import axios from "axios";
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
        })
        .catch(function (e) {
          this.erros = e.response.data.errors;
          this.errored = true;
        })
        .finally(() => (this.loading = false));
    },
  },
  mounted() {
    this.getVacinados();
  },
};
</script>