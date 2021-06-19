<template>
  <div id="app">
    <router-view />
    <toast-component message="This a sample"/>
  </div>
</template>

<script>
  import ToastComponent from './components/ToastComponent.vue'

  export default {

    components: {
      ToastComponent
    }
  }
</script>

