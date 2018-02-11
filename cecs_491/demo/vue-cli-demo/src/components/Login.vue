<template>
  <div>
    <h1>{{pageTitle}}</h1>
    <div>
        <form name="signIn" action="http://localhost:8081/signIn" method="POST">
            <div>
                <label for="email">Username</label>
                <input v-model="username" id="email" type="email" placeholder="user@email.com" autocomplete="current-username" />
            </div>
            <br />

            <div>
                <label for="password">Password</label>
                <input v-model="password" id="password" type="password" placeholder="Password" autocomplete="current-password" />
            </div>
            <br />

            <span>
                <!-- Cookie will be accessible if httpOnly is false because cookie domain is set -->
                <input id="submit" type="submit" value="Sign In Input" />
            </span>
            <span>
                <button @click.prevent="signIn">Sign In Button</button>
            </span>
        </form>

        <br /><br />
        <span>
            <router-link to="/">Go Home Link</router-link>
        </span>
        <span>
            <button v-on:click="goBack" >Go Back Button</button>
        </span>

        <span>
            <router-link to="/Secure">Go Secure Link</router-link>
        </span>
        <br /><br />
        <div v-show="hasErrored === true">
          <span class="error">
            {{pageError}}
          </span>
        </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'Login',
  computed: {
    isAuthenticated: function () {
      return this.$store.getters.isAuthenticated
    }
  },
  data () {
    return {
      pageTitle: 'Login Page',
      hasErrored: false,
      pageError: '',
      username: '',
      password: ''
    }
  },
  methods: {
    goBack: function () {
      this.$router.go(-1)
    },
    signIn () {
      if (this.$data.username !== 'test' || this.$data.password !== 'test') {
        this.$data.hasErrored = true
        this.$data.pageError = 'Invalid username and/or password'
        return false
      }

      this.$store.dispatch('signIn', {authStatus: true, username: this.$data.username})

      // Make a call to the server to authenticate user
      axios({
        method: 'POST',
        url: 'http://localhost:8081/signIn',
        data: { username: this.$data.username, password: this.$data.password },
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true
        }
      })
        .then((response) => {
          this.$log('Login success')

          // Should be blank since cookie domain is not set
          this.$log(['cookie', document.cookie])
          this.$data.hasErrored = false

          this.$router.push('Secure') // Use of .replace will cause cookie domain to not be set
        }).catch((error) => {
          this.$data.hasErrored = true
          this.$data.pageError = 'XHR request failed'

          if (error.response) {
            // Server returned a response, but was not 200 OK
            this.$log('Request FAILED')
          } else if (error.request) {
            // Unable to complete request
            this.$log('Request Timeout or request not able to be executed')
          } else {
            // Error in callback
            this.$log('Callback error')
          }
        })
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
a {
  color: #42b983;
}

button:hover {
    cursor: pointer;
}
</style>
