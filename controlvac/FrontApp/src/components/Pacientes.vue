<template>
<div>
    <h1> Relação de Pacientes</h1>
    <div class="container">
    <section v-if="errors">
    <p>Não conseguimos recuperar os dados</p>
  </section>
    <p v-if="loading"><em><i class="fas fa-spinner " style="fontSize: 2rem"></i></em></p>

    <table class='table table-striped' aria-labelledby="tableLabel" v-if="pacientes">
        <thead>
            <tr>
                <th>Nome</th>
                <th>CPF</th>
                <th>Nº Cartão SUS</th>
                <th>Nascimento</th>
                <th>Comorbidade?</th>
                <th>Municipio</th>
                <th>Estado</th>
                <th>Ações</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="paciente of pacientes" :key="paciente.id">
                <td>{{ paciente.nome}} {{paciente.sobrenome}}</td>
                <td>{{ paciente.cpf}}</td>
                <td>{{ paciente.sus}}</td>
                <td>{{ paciente.nascimento}}</td>
                <td>{{ paciente.comorbidades}}</td>
                <td>{{ paciente.municipio}}</td>
                <td>{{ paciente.estado}}</td>
                <td>
                  <div class="actions">
                    <i class="pi pi-pencil"></i>
                    <i class="pi pi-trash"></i>
                   </div> 
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
</template>


<script>
    import axios from 'axios'
    export default {
        name: "Pacientes",
        data() {
            return {
                pacientes: [],
                erros:[],
                loading: true,
            }
        },
        methods: {
            getPacientes() {
                axios.get('/api/paciente')
                    .then((response) => {
                        this.pacientes =  response.data;
                    })
                    .catch(function (e) {
                        this.erros = e.response.data.errors
                        alert(this.erros)
                    })
                    .finally(() => this.loading = false);
            }
        },
        mounted() {
            this.getPacientes();
        }
    }
</script>