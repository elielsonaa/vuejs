<template>
  <div>
    <h1>Vacinas Disponíveis</h1>
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
          v-if="vacinas"
        >
          <thead>
            <tr>
              <th>Nome</th>
              <th>Fabricante</th>
              <th>Lote</th>
              <th>Validade</th>
              <th>Doses</th>
              <th>Intervalo(dias)</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="vacina of vacinas" :key="vacina.id">
              <td>{{ vacina.nome }}</td>
              <td>{{ vacina.fabricante }}</td>
              <td>{{ vacina.lote }}</td>
              <td>{{ formatDate(vacina.validade) }}</td>
              <td>{{ vacina.doses }}</td>
              <td>{{ vacina.intervalo }}</td>
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
            Nova Vacina
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import moment from 'moment'
export default {
  name: "Vacinas",
  data() {
    return {
      vacinas: [],
      erros: [],
      errored: false,
      loading: true,
    };
  },
  methods: {
    getVacinas() {
      axios
        .get("/api/vacina")
        .then((response) => {
          this.vacinas = response.data;
          console.log(this.vacinas);
        })
        .catch(function(e) {
          this.erros = e.response.errors;
          this.errored = true;
        })
        .finally(() => (this.loading = false));
       },
        formatDate: function (value) {
         return moment(String(value)).format('L')
     } 
  },
  mounted() {
    this.getVacinas();
  },
};
</script>
