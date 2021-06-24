<template>
 <div class="app">
  <nav-menu></nav-menu>
  <router-view :key="$route.fullPath"/>
 </div>
</template>

<script>
import NavMenu from './components/NavMenu.vue'
export default {
  name: 'App',
  components: {
      NavMenu
  },
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;

}
@media (min-width: 768px) {
        html {
            font-size: 16px;
        }
    }
.margin-bottom {
  margin-bottom: 15px;
}
.bd-buttom {
  padding: 1rem;
  margin: 2rem -15px 0;
  border: solid #dee2e6;;
  border-width: 0.2rem 0 0;
  justify-content: space-around;
}
.btn-space {
  margin-right: 9px;
}
h1 {
    font-size:2rem;
    padding-top: 0.8em;
}
section p {
  color: firebrick;
  font-style: oblique;
  font-weight: bold;
}
thead {
   background-color: #cd1076;
}
th {
  color: #f8f9fa;
}
.container {
  padding-top: 2em;
  -ms-flex-item-align: center;
  text-align: left;
}
.cardhome {
  padding: 1rem;
  margin:1rem;
}
.card {
  margin:.6rem;
}
</style>
