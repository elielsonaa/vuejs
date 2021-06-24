<template>
  <div class="container">
    <form>
      <div class="form-group margin-bottom col-md-6">
        <label for="inputNome">Nome da Vacina</label>
        <input
          type="text"
          class="form-control"
          id="inputNome"
          placeholder="CoronaVac etc."
        />
      </div>
      <div class="form-group col-md-5 margin-bottom ">
        <label for="inputFabricante">Fabricante</label>
        <select id="inputFabricante" class="form-control">
          <option selected>Selecione...</option>
          <option v-for="(fabricante, index) in fabricantes" :key="index">{{
            fabricante
          }}</option>
        </select>
      </div>
      <div class="form-group margin-bottom col-md-2 ">
        <label for="inputLote">Lote</label>
        <input
          type="text"
          class="form-control"
          id="inputLote"
          placeholder="00000000"
        />
      </div>
      <div class="form-group margin-bottom col-md-4">
        <label for="data-validade">Data de Validade"</label>
        <!-- Datepicker as text field -->
        <div class="input-group date" data-date-format="dd/mm/yyyy">
          <input type="date" class="form-control" placeholder="dd/mm/yyyy" />
          <div class="input-group-addon">
            <span class="glyphicon glyphicon-th"></span>
          </div>
        </div>
      </div>
      <div class="form-row margin-bottom col-md-12">
        <div class="form-group col-md-2">
          <label for="inputDoses">Nº de Doses</label>
          <input type="number" class="form-control" id="inputDoses" />
        </div>
        <div class="form-group col-md-2 ">
          <label for="inputIntDoses">Intervado entre Doses</label>
          <input type="number" class="form-control" id="inputIntDoses" />
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
  name: "Vacina",
  data() {
    return {
      fabricantes: [
        "AstraZeneca/Oxford",
        "Bharat Biotech",
        "CanSino Biologics",
        "Instituto de Pesquisa Gamaleya",
        "Johnson & Johnson e Janssen Vaccines",
        "Moderna Therapeutic",
        "Pfizer/BioNTech",
        "Sinovac",
        "Sinopharm",
      ],
      vacina:[],
    };
  },
};
</script>