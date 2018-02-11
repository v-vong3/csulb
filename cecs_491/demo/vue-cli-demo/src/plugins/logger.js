// Logger Plugin for Vue

const Logger = {
  install (Vue, options) {
    // Add functionality to all components
    Vue.mixin({
      beforeCreate () {
        // Initialization happens here
      },
      created () {
        // Instance created
      },
      beforeMount () {
        // Before component is "attached" to DOM
      },
      mounted () {
        // Component is "attached" to DOM
      },
      beforeUpdate () {
        // Before data changes
      },
      updated () {
        // Data has changed
      },
      beforeDestroy () {
        // Before teardown of event listeners, watchers and child components
      },
      destroyed () {
        // Compoment destroyed
      }
    })

    // Add global functionality to specific instance
    Vue.log = function (message) {
      if (message.unshift) {
        message.unshift('[From Global]')
        console.log.apply(this, message)
      } else {
        console.log('[From Global]', message)
      }
    }

    // Add functionality to all Vue instances
    Vue.prototype.$log = function (message) {
      if (message.unshift) {
        message.unshift('[From prototype]')
        console.log.apply(this, message)
      } else {
        console.log('[From prototype]', message)
      }
    }
  }
}

// Automatic installation of plugin within web context
if (typeof window !== 'undefined' && window.Vue) {
  window.Vue.use(Logger)
}

export default Logger
