<template>
  <transition name="slide">
    <div v-cloak>
      <span class="right" v-show="!!user === true">{{'username: ' + user}}</span>

    </div>
  </transition>
</template>

<script>
export default {
  name: 'User',
  computed: {
    user: function () {
      return this.$store.getters.user
    }
  },
  data () {
    return {
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
