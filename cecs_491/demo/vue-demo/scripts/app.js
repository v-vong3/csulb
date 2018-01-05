

// Initialization
const app = new Vue({
    el: "#app",
    data: {
        homeUrl: 'http://localhost:3000/#used_v-bind',
        title: 'Learning Vue.js & Bulma',
        tileTitles: ['Installation', 'Setup', 'Debugging', 'Productionalize'],
        footerMessage: 'Learn, Master, Repeat',

        themeColor: 'Dark',
        isDirty: false,
        view: null,
        items: [1,2,3,4,5,6,7,8,9,10]
    },
    methods: {
        route: (event) => {
            let basePath = 'http://localhost:3000/',
                templatePath = 'templates/',
                url = '';

            switch(event.target.id){
                case 'dataBind':
                    url = [basePath, templatePath, "data-binding.html"].join('');
                    break;
                case 'eventHandling':
                    url = [basePath, templatePath, "event-handling.html"].join('');
                    break;
                case 'settings':
                    url = [basePath, templatePath, "settings.html"].join('');
                    break;
                default:
                    return;
            }

            // Make a request
            axios.get(url)
                .then(function (response) {
                    let template = response.data;
                    let element = document.getElementById('main');
                    let replacement = document.createElement('div');

                    replacement.innerHTML = template;
                    element.innerHTML = '';
                    element.appendChild(replacement);

                })
                .then(() => {
                    // The DOM element must be done loading inorder for Vue to mount to it
                    this.view = new Vue({
                        el: "#view",
                        data: {
                            appName: 'Vue.js Demo',
                            isDisabled: true,
                            themeColor: 'Dark',
                            items: Array.apply(null, { length: 100 })
                        }
                    });
                })
                .catch(function (error) {
                    console.log(error);
                });

        }
    }
});


// Routing


// Error Handling
