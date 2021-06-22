<template>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light border-bottom box-shadow mb-12" style="background-color: #cd1076">
                <a class="navbar-brand text-light">
                   <img src="../assets/logo.png" alt="" width="60" height="44" class="d-inline-block">
                   <strong>ControlVAC</strong>
                </a>
                <button class="navbar-toggler"
                        type="button"
                        data-toggle="collapse"
                        data-target=".navbar-collapse"
                        aria-label="Toggle navigation"
                        @click="toggle">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse"
                     v-bind:class="{show: isExpanded}">
                    <ul class="navbar-nav flex-grow">
                        <li class="nav-item">
                            <router-link :to="{ name: 'Home' }" class="nav-link text-light">Home</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="{ name: 'Vacinas' }" class="nav-link text-light">Vacinas</router-link>
                        </li>
                         <li class="nav-item">
                            <router-link :to="{ name: 'Pacientes' }" class="nav-link text-light">Pacientes</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="{ name: 'Vacinados' }" class="nav-link text-light">Vacinados</router-link>
                        </li>
                    </ul>
                </div>
        </nav>
    </header>
</template>
<style>
    a.navbar-brand {
        text-align: center;
        
    }
    .nav-item {
      font-size: 1.2em;
      font-style:bold; 
    }
    html {
        font-size: 14px;
    }
    .box-shadow {
        box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05);
    }
</style>
<script>
    export default {
        name: "NavMenu",
        data() {
            return {
                isExpanded: false
            }
        },
        methods: {
            collapse() {
                this.isExpanded = false;
            },

            toggle() {
                this.isExpanded = !this.isExpanded;
            }
        }
    }
</script>