<template>
<div>
    <h1>Vacinas Disponíveis</h1>
    <div class="container">
   <section v-if="errored">
    <p>Não conseguimos recuperar os dados</p>
  </section>
    <p v-if="loading"><em><i class="fas fa-spinner " style="fontSize: 2rem"></i></em></p>
    
    <table class='table table-striped' aria-labelledby="tableLabel" v-if="vacinas">
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
                <td>{{ vacina.validade }}</td>
                <td>{{ vacina.doses }}</td>
                <td>{{ vacina.intervalo }}</td>
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
</template>


<script>
    import axios from 'axios'
    export default {
        name: "Vacinas",
        data() {
            return {
                vacinas: [],
                erros:[],
                errored: false,
                loading: true,
            }
        },
        methods: {
            getVacinas() {
                axios.get('/api/vacina')
                    .then((response) => {
                        this.vacinas =  response.data;
                        console.log(this.vacinas)
                    })
                    .catch(function (e) {
                        this.erros = e.response.errors
                        this.errored = true
                    })
                    .finally(() => this.loading = false);
            }
        },
        mounted() {
            this.getVacinas();
        }
    }
</script>