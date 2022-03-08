const express = require('express')
const cors = require('cors')

const port = 8080;
const app = express();

const allowHosts = ['http://localhost:3000']

const corsHandler = function (req, callback) {
    var corsOptions;
   
      corsOptions = { 
          
          origin: 'http://localhost:3000'
        } // disable CORS for this request
    
    callback(null, corsOptions) // callback expects two parameters: error and options
  }


app.use(cors(corsHandler));
app.use(express.json())



app.options('*', cors(corsHandler))

app.get('/', (request, response) => {
    response.append('Content-Type', 'application/javascript; charset=UTF-8');

    var randomSize = Math.floor(Math.random() * 10)
    var data = [];
    
    for(var i = 0; i < randomSize; i++) {
        var randomNumber = Math.floor(Math.random() * 10);

        data.push(randomNumber);
    }

    response.json({
        numbers: data,
        names: [],
        grades: []
    }); 
});

app.post('/', (request, response) => {

    while(true)
    {
        
    }

    // Valid incoming data
    // Saving data is success (capacity not full)
    // Operation was success

    response.status(500).send('Database is full');
})


app.listen(port, () => {

});