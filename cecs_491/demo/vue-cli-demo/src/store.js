
import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    isAuthenticated: false,
    username: ''
  },
  getters: {
    authStatus: function (state) {
      return state.isAuthenticated
    },
    user: function (state) {
      return state.username
    }
  },
  mutations: {
    updateAuthStatus: function (state, payload) {
      state.isAuthenticated = payload.authStatus
    },
    updateUsername: function (state, payload) {
      state.username = payload.username
    }
  },
  actions: {
    signIn: function (context, payload) {
      context.commit('updateAuthStatus', payload)
      context.commit('updateUsername', payload)
    },
    signOut: (context, payload) => {
      context.commit('updateAuthStatus', {authStatus: false})
      context.commit('updateUsername', {username: ''})
    }
  }
})
