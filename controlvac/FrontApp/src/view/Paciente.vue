<template>
  <div class="container">
    <form>
      <div class="form-row col-md-24 ">
        <div class="form-group col-md-6 margin-bottom ">
          <label class="col-form-label" for="inputNome">Nome</label>
          <input
            type="text"
            class="form-control"
            id="inputNome"
            placeholder="Nome"
          />
        </div>
        <div class="form-group col-md-6 margin-bottom ">
          <label class="col-form-label" for="inputSobrenome">Sobrenome</label>
          <input
            type="text"
            class="form-control"
            id="inputSobrenome"
            placeholder="Sobrenome"
          />
        </div>
      </div>
      <div class="form-row">
        <div class="form-group margin-bottom col-md-3">
        <label for="dataNascimento">Nascimento"</label>
        <!-- Datepicker as text field -->
        <div class="input-group date" data-date-format="dd/mm/yyyy">
          <input type="date" class="form-control" placeholder="01/01/1900" />
          <div class="input-group-addon">
            <span class="glyphicon glyphicon-th"></span>
          </div>
        </div>
      </div>
        <div class="form-group col-md-3 margin-bottom ">
          <label for="inputSexo">Sexo</label>
          <select id="inputState" class="form-control">
            <option selected>Selecione...</option>
            <option v-for="(sexo,index) in sexos" :key="index">{{sexo}}</option>
          </select>
        </div>
        <div class="form-group col-md-3 margin-bottom ">
          <label for="inputCpf">CPF</label>
          <input type="text" class="form-control" id="inputCpf" placeholder="000.000.000-00" />
        </div>
        <div class="form-group col-md-3 margin-bottom ">
          <label for="inputSus">Nº do Cartão SUS</label>
          <input type="text" class="form-control" id="inputSus" placeholder="000000000000000"/>
        </div>
      </div>
      <div class="form-group margin-bottom ">
        <label for="inputAddress">Endereço</label>
        <input
          type="text"
          class="form-control"
          id="inputAddress"
          placeholder="Rua 4, Nº 0, Bairro"
        />
      </div>
      <div class="form-row">
        <div class="form-group col-md-6 margin-bottom ">
          <label for="inputCity">Cidade</label>
          <input type="text" class="form-control" id="inputCity" />
        </div>
        <div class="form-group col-md-4 margin-bottom ">
          <label for="inputState">Estado</label>
          <select id="inputState" class="form-control">
            <option selected>Selecione...</option>
            <option v-for="(estado,index) in estados" :key="index">{{estado}}</option>
          </select>
        </div>
        <div class="form-group col-md-2 margin-bottom ">
          <label for="inputZip">Cep</label>
          <input type="text" class="form-control" id="inputZip" placeholder="00000-000"/>
        </div>
      </div>
      <div class="bd-buttom">
          <button type="submit" class="btn btn-primary btn-lg btn-space" value="Submit">Salvar</button>  
          <button type="reset" class="btn btn-danger btn-lg btn-space" value="Reset">Limpar</button>   
      </div>
    </form>
  </div>
</template>
<script>
export default ({
  name:'Paciente',
  data () {
    return {
        estados : [ 'AC','AL','AP','AM','BA','CE','ES','GO','MA','MT','MS','MG','PA','PB','PR'
                  ,'PE','PI','RJ','RN','RS','RO','RR','SC','SP','SE','TO','DF'],
        sexos:["Feminino","Masculino"],
        pacienteid:this.$route.params.id, 
    }
  },
})
</script>
