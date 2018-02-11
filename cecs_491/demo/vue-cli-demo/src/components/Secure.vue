<template>
  <transition name="slide">
    <div v-cloak>
      <h1>{{pageTitle}}</h1>
      <h2 v-if="authStatus === true">{{authMessage}}</h2>
      <h2 v-else>{{noAuthMessage}}</h2>
      <br />

      <span>
        <button @click.prevent="signOut">Sign Out</button>
      </span>
      <br />
      <br />

      <span>
        <router-link to="/">Go Home Link</router-link>
      </span>
      <span>
        <router-link to="/Login">Go Login Link</router-link>
      </span>
    <br>
    <div v-show="hasErrored === true">
      <span class="error">
        {{pageError}}
      </span>
    </div>
    </div>
  </transition>
</template>

<script>
import axios from 'axios'
export default {
  name: 'Secure',
  computed: {
    authStatus: function () {
      return this.$store.getters.authStatus
    }
  },
  data () {
    return {
      pageTitle: 'Secure Page',
      hasErrored: false,
      pageError: '',
      authMessage: 'You have been authenticated',
      noAuthMessage: 'Not authenticated'
    }
  },
  methods: {
    signOut: function () {
      axios({
        method: 'POST',
        url: 'http://localhost:8081/signOut',
        data: { },
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true
        }
      })
        .then((response) => {
          this.$log('Signing out successful')
          this.$data.hasErrored = false
          this.$store.dispatch('signOut')

          // Ensures deletion of cookie on the browser
          // document.cookie = 'auth_Cookie=; Max-Age=-1'
          this.$router.push('Login')
        })
        .catch((error) => {
          this.$data.hasErrored = true
          this.$data.pageError = (error.response && error.response.message) || error
        })
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
