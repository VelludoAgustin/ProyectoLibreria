const exp =require('constants');
const express = require('express');
const app = express();
const path = require('path');
const port = 3000
const router = express.Router();

app.use(express.static(__dirname + '/'));//revisar linea

app.get('/main',function(req,res){
  res.sendFile(path.join(__dirname+'/ListarLibros/ListarLibros.html'));
});

app.listen(port, () => console.log(`http://localhost:${port}/main`))