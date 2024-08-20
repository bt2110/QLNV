<template>
  <div>
    <TheHeader/>
    <div class="main">
      <TheNavbar/>
      <TheContent/>
    </div>
  </div>
</template>

<script>
import TheHeader from './components/layout/TheHeader.vue';
import TheNavbar from './components/layout/TheNavbar.vue';
import TheContent from './components/layout/TheContent.vue';


export default {
  name: 'App',
  components: {
    TheHeader, 
    TheNavbar, 
    TheContent
  }
}
</script>

<style>
  @import url(../src/style/main.css);
  @import url(../src/style/page/employee.css);
</style>
