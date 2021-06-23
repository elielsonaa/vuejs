<template>
  <div classe="container">
    <h1>Home</h1>
     <section v-if="errored">
        <p>Não conseguimos recuperar os dados</p>
      </section>
      <p v-if="loading">
        <em><i class="pi pi-spin pi-spinner" style="fontSize: 2rem"></i></em>
      </p>
  </div>
</template>
<script>
import axios from "axios";
const keyToken = "c46ab8e46bdf2875bdba8b1c22762ca680c0fa03";
export default {
  name: "Home",
  data() {
    return {
      structure: [],
      erros: [],
      errored: false,
      loading: true,
    };
  },
  methods: {
    getDados() {
        axios
        .get(
          "https://api.brasil.io/v1/dataset/covid19/boletim/data/?format=json",
          {
            headers: {
              Authorization: `token ${keyToken}`,
            },
          }
        )
        .then((response) => {
          this.structure = response.data;
          console.log(this.structure);
          response.data.results.forEach(element => {
          const city = element.city
          const confirmed = element.confirmed
          const deaths = element.deaths
          const state = element.state
  
          console.log(`Cidade: ${city}`,
            `Quantidade de confirmados: ${confirmed}`, 
            `Quantidade de mortes ${deaths}`,
            `Estado: ${state}`)
          });
        })
        .catch(function(e) {
          this.erros = e.response.data.errors;
          this.errored = true;
        })
        .finally(() => (this.loading = false)); 
          
    },
  },
  mounted() {
    //this.getDados();
  },
};
</script>
