<template>
  <div class="container">
    <form>
      <div class="form-row">
      <div class="form-group margin-bottom col-md-2">
        <label for="data-validade">Data da Vacinacao</label>
        <!-- Datepicker as text field -->
        <div class="input-group date" data-date-format="dd/mm/yyyy">
          <input type="date" class="form-control" placeholder="dd/mm/yyyy" />
          <div class="input-group-addon">
            <span class="glyphicon glyphicon-th"></span>
          </div>
        </div>
      </div>
      </div>
       <div class="form-row">
      <div class="form-group margin-bottom col-md-5">
        <label for="inputCliente">Paciente</label>
        <input class="form-control mr-sm-2" 
        type="text" 
        placeholder="Buscar Paciente" 
        id="inputCliente"
        aria-label="Search">
      </div>
      </div>
      <div class="form-row">
      <div class="form-group margin-bottom col-md-5">
        <label for="inputCliente">Vacina</label>
        <input class="form-control mr-sm-2" 
        type="text" 
        placeholder="Buscar Vacina" 
        id="inputCliente"
        aria-label="Search">
      </div>
      </div>
      <div class="form-row">
        <div class="form-group col-md-2 margin-bottom ">
          <label for="inputDoses">Dose Aplicada</label>
          <input type="number" class="form-control " id="inputDoses" />
        </div>
      </div>
      <div class="form-row">
        <div class="form-group col-md-2 margin-bottom ">
          <label for="inputDoses">Doses Restantes</label>
          <input type="number" class="form-control" id="inputDosesRest" />
        </div>
      </div>
      <div class="bd-buttom">
        <button
          type="submit"
          class="btn btn-primary btn-lg btn-space"
          value="Submit"
        >
          Salvar
        </button>
        <button
          type="reset"
          class="btn btn-danger btn-lg btn-space"
          value="Reset"
        >
          Limpar
        </button>
      </div>
    </form>
  </div>
</template>
<script>
export default {
  name: "Vacinacao",
  data() {
    return {

    };
  },
};
</script>
