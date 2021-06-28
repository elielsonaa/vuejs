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
        <em><i class="pi pi-spin pi-spinner" style="fontsize: 2rem"></i></em>
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
              <td>
                {{ vacinado.paciente.nome }}{{ vacinado.paciente.sobrenome }}
              </td>
              <td>{{ vacinado.vacina.nome }}</td>
              <td>{{ vacinado.vacina.doses }}</td>
              <td>{{ vacinado.dosesTomadas }}</td>
              <td>{{ vacinado.vacina.doses - vacinado.dosesTomadas }}</td>
              <td>
                <a
                  href="#"
                  class="link-success tooltip-test"
                  data-toggle="modal"
                  data-target="#formModal"
                  title="Visualizar"
                  ><i class="pi pi-book btn-space" style="color: green"></i
                ></a>
                  <a
                    href="#"
                    class="link-warning tooltip-test"
                    data-toggle="modal"
                    data-target="#formModal"
                    title="Editar"
                    ><i class="pi pi-pencil btn-space" style="color: orange"></i
                  ></a>
                <a
                  href="#"
                  class="link-danger tooltip-test"
                  data-toggle="modal"
                  data-target="#formModal"
                  title="Excluir"
                  ><i class="pi pi-trash btn-space" style="color: red"></i
                ></a>
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
      <!--Inicio Modal -->
      <div class="modal fade" id="formModal" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h2 class="modal-title">Editar dados de vacinados</h2>
              <button type="button" class="close" data-dismiss="modal">
                <span>x</span>
              </button>
            </div>
            <div class="modal-body">
              <form>
                <div class="form-row">
                  <div class="form-group margin-bottom col-md-4">
                    <label for="data-validade">Data da Vacinacao</label>
                    <!-- Datepicker as text field -->
                    <div class="input-group date" data-date-format="dd/mm/yyyy">
                      <input
                        type="date"
                        class="form-control"
                        placeholder="dd/mm/yyyy"
                      />
                      <div class="input-group-addon">
                        <span class="glyphicon glyphicon-th"></span>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="form-row">
                  <div class="form-group margin-bottom col-md-5">
                    <label for="inputCliente">Paciente</label>
                    <input
                      class="form-control mr-sm-4"
                      type="text"
                      placeholder="Buscar Paciente"
                      id="inputCliente"
                      aria-label="Search"
                    />
                  </div>
                </div>
                <div class="form-row">
                  <div class="form-group margin-bottom col-md-5">
                    <label for="inputCliente">Vacina</label>
                    <input
                      class="form-control mr-sm-4"
                      type="text"
                      placeholder="Buscar Vacina"
                      id="inputCliente"
                      aria-label="Search"
                    />
                  </div>
                </div>
                <div class="form-row">
                  <div class="form-group col-md-5 margin-bottom">
                    <label for="inputDoses">Dose Aplicada</label>
                    <input type="number" class="form-control" id="inputDoses" />
                  </div>
                </div>
                <div class="form-row">
                  <div class="form-group col-md-5 margin-bottom">
                    <label for="inputDoses">Doses Restantes</label>
                    <input
                      type="number"
                      class="form-control"
                      id="inputDosesRest"
                    />
                  </div>
                </div>
              </form>
            </div>
            <div class="modal-footer">
                <button
                  type="reset"
                  class="btn btn-danger btn-lg btn-space"
                  value="Reset"
                  data-dismiss="modal"
                >
                  Cancelar
                </button>
                               <button
                  type="submit"
                  class="btn btn-primary btn-lg btn-space"
                  value="Submit"
                >
                  Salvar
                </button>
            </div>
          </div>
        </div>
      </div>
      <!--Fum Modal -->
    </div>
  </div>
</template>

<script>
import axios from "axios";
import moment from "moment";
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
          console.log(response.data);
        })
        .catch(function (e) {
          this.erros = e.response.data.errors;
          this.errored = true;
        })
        .finally(() => (this.loading = false));
    },
    formatDate: function (value) {
      return moment(String(value)).format("L");
    },
  },
  mounted() {
    this.getVacinados();
  },
};
</script>
