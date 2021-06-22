<template>
  <div class="container">
    <form>
      <div class="form-row">
        <div class="form-group col-md-6 margin-bottom ">
          <label class="col-form-label" for="inputEmail4">Email</label>
          <input
            type="email"
            class="form-control"
            id="inputEmail4"
            placeholder="Email"
          />
        </div>
        <div class="form-group col-md-6 margin-bottom ">
          <label for="inputPassword4">Password</label>
          <input
            type="password"
            class="form-control"
            id="inputPassword4"
            placeholder="Password"
          />
        </div>
      </div>
      <div class="form-group margin-bottom ">
        <label for="inputAddress">Address</label>
        <input
          type="text"
          class="form-control"
          id="inputAddress"
          placeholder="1234 Main St"
        />
      </div>
      <div class="form-group margin-bottom ">
        <label for="inputAddress2">Address 2</label>
        <input
          type="text"
          class="form-control"
          id="inputAddress2"
          placeholder="Apartment, studio, or floor"
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
          <input type="text" class="form-control" id="inputZip" />
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
                  ,'PE','PI','RJ','RN','RS','RO','RR','SC','SP','SE','TO','DF']
    }
  },
})
</script>
