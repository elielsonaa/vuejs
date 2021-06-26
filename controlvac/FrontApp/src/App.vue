<template>
 <div class="app">
  <nav-menu></nav-menu>
  <router-view :key="$route.fullPath"/>
 </div>
</template>

<script>
import '../styles/global.css'
import NavMenu from './components/NavMenu.vue'
export default {
  name: 'App',
  components: {
      NavMenu
  }
}
</script>