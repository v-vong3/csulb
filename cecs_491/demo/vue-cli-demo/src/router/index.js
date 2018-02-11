// Would make more sense if this file was renamed to [appName]-route-config.js or [appName]-routes.js

import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Login from '@/components/Login'
import Secure from '@/components/Secure'

Vue.use(Router)

const router = new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home,
      meta: {
        title: 'Home Page'
      }
    },
    // Example of redirecting to another route
    // Acts as if the user never visited the URI designated in the path property
    {
      path: '/Home',
      redirect: '/'
    },
    {
      path: '/Login',
      name: 'Login',
      component: Login,
      meta: {
        title: 'Login Page'
      }
    },
    {
      path: '/Secure',
      name: 'Secure',
      meta: {
        title: 'Secure Page'
      },
      beforeEnter: (to, from, next) => {
        // Component navigation guard
        // Not using logger plugin since _this_ keyword is not available for in beforeEnter nav guard
        console.log('From ' + from.path.name)
        if (from.path !== '/Login') {
          console.log('Restricted from direct access')
          next(false) // Restrict access
        } else {
          next()
        }
      },
      component: Secure
    },
    // Example of wildcard catch all route; Should redirect to error page
    {
      path: '*'
    }
  ]
})

// Change the broswer window's title on each navigation
router.beforeEach((to, from, next) => {
  document.title = (to.meta && to.meta.title) || 'Your App Name'
  next()
})

export default router
