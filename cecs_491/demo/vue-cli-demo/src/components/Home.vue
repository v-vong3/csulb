<template>
  <transition name="slide">
    <div v-cloak>
      <h1>{{pageTitle}}</h1>
      <p>
        {{pageDescription}}
      </p>
      <br />

      <span>
        <router-link to="/login">Login Link</router-link>
      </span>
      <span>
        <button @click="toLogin" >Login Button</button>
      </span>

      <User />
    </div>
  </transition>
</template>

<script>
import User from '@/components/User'
export default {
  name: 'Home',
  components: { User },
  template: '<User />',

  computed: {
    user: function () {
      return this.$store.getters.user
    }
  },
  data () {
    return {
      pageTitle: 'Home Page',
      pageDescription: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'
    }
  },
  methods: {
    toLogin: function () {
      this.$router.push('Login')
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1 {
  font-weight: bold;
  color: rgb(6, 109, 66);
}

p {
  background-color: rgb(209, 209, 209);
}

span {
  margin-right: 15px;
}

button {
    color: whitesmoke;
    background-color: darkcyan;
    font-size: 12pt;
    border-radius: 5px 5x;
    padding: 2px 2px;
}

button:hover {
    cursor: pointer;
}
</style>
