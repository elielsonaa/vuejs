<template>
  <div>
    <h1>Relação de Vacinação</h1>
    <div class="container">
      <section v-if="errored">
        <p>Não conseguimos recuperar os dados</p>
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
              <th>Doses Restantes</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="vacinado of vacinados" :key="vacinado.id">
              <td>{{ vacinado.nome }}</td>
              <td>
                <a href="#" class="link-success"><i class="pi pi-pencil btn-space"  style="color: green"></i></a>
                <a href="#" class="link-danger"><i class="pi pi-trash btn-space" style="color: red"></i></a>
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
            Informar Vacinacao
          </button>
        </div>
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
        .catch(function(e) {
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
