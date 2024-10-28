var Db = require('./dboperations');
var produtos = require('./produtos');
const dboperations = require('./dboperations');

var express = require('express');
var bodyparser = require('body-parser');
var cors = require('cors');
var app = express();
var router = express.Router();

app.use(bodyparser.urlencoded({extended: true}));
app.use(bodyparser.json());
app.use(cors());
app.use('/api', router);

router.use((request, response, next)=>{
    console.log('middleware');
    next();
})

/*router.route('/produtos').get((request, response) => {
    dboperations.getprodutos().then(result => {
        if (result && result.length > 0) {
            response.json(result[0]);
        } else {
            response.status(404).json({ message: 'Nenhum produto encontrado.' });
        }
    }).catch(error => {
        console.error('Erro ao buscar produtos:', error);
        response.status(500).json({ message: 'Erro ao buscar produtos.' });
    });
});*/

router.route('/produtos').get((request, response) =>{
    dboperations.getprodutos().then(result =>{
        response.json(result[0]);
    })
})

router.route('/produtos/:id').patch((request, response)=>{
    let produto = {...request.body}

    dboperations.updateProduto(produto).then(result =>{
        response.status(204).json(result);
    })
})

router.route('/produtos/:id').get((request, response)=>{
    dboperations.getprodutos(request.params.id).then(result =>{
        response.json(result[0]);
    })
})

router.route('/produtos/:id').delete((request, response)=>{
    dboperations.delproduto(request.params.id).then(result =>{
        response.json(result[0]);
    })
})

router.route('/produtos').post((request, response)=>{
    let produto = {...request.body}

    dboperations.addproduto(produto).then(result =>{
        response.status(201).json(result);
    })
})

var port = process.env.PORT || 8090;
app.listen(port);
console.log('Api de produtos rodando na porta: '+ port);