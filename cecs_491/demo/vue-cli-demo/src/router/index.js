import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Login from '@/components/Login'
import Secure from '@/components/Secure'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home,
      beforeEnter: (to, from, next) => {
        document.title = 'Home'
        next()
      }
    },
    // Example of redirecting
    {
      path: '/Home',
      redirect: '/'
    },
    {
      path: '/Login',
      name: 'Login',
      component: Login,
      beforeEnter: (to, from, next) => {
        document.title = 'Login'
        next()
      }
    },
    {
      path: '/Secure',
      name: 'Secure',
      meta: {
        title: 'Secure'
      },
      beforeEnter: (to, from, next) => {
        // Component navigation guard
        // Not using logger plugin since _this_ keyword is not available for in beforeEnter nav guard
        console.log('From ' + from.path.name)
        if (from.path !== '/Login') {
          console.log('Restricted from direct access')
          next(false) // Restrict access
        } else {
          document.title = to.meta.title
          next()
        }
      },
      component: Secure
    },
    // Example of wildcard catch all route
    {
      path: '*'
    }
  ]
})
