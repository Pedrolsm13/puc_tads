var config = require('./dbconfig');
const sql = require('mssql');

async function getprodutos(){
    try{
        let pool = await sql.connect(config);
        let lojas = await pool.request().query("SELECT * from produtos");
        return lojas.recordsets;
    }
    catch(error){
        console.log(error);
    }
}

async function updateProduto(produto) {
    try{
        let pool = await sql.connect(config);
        let loja = await pool.request()
        .input('input_parameter', sql.int, produto.id)
        .query(`UPDATE [dbo].[produtos]
            SET
            [nome] = '${produto.nome}',
            [cod_prod] = '${produto.cod_prod}',
            [preco] = '${produto.preco}',
            [descricao] = '${produto.descricao}',
            [quantidade] = '${produto.quantidade}',
            [avaliacao] = '${produto.avaliacao}',
            [categoria] = '${produto.categoria}',
            [imagem] = '${produto.imagem}'
            WHERE ID = @input_parameter
            `);
        return loja.recordsets
    }
    catch (error){
        console.log(error);
    }
}

async function getproduto(produtoid) {
    try{
        let pool = await sql.connect(config);
        let lojas = await pool.request()
        .input('input_parameter', sql.int, produtoid)
        .query("SELECT * from produtos WHERE ID = @input_parameter");
        return lojas.recordsets;
    }
    catch(error){
        console.log(error);
    }
}

async function delproduto(produtoid) {
    try{
        let pool = await sql.connect(config);
        let lojas = await pool.request()
        .input('input_parameter', sql.int, produtoid)
        .query("DELETE * from [dbo].[produtos] WHERE ID = @input_parameter");
        return lojas.recordsets;
    }
    catch(error){
        console.log(error);
    }
}

async function addproduto(produto) {
    try{
        let pool = await sql.connect(config);
        let lojas = await pool.request()
        .query(`INSERT INTO [dbo].[produtos](
            [nome],
            [cod_prod],
            [preco],
            [descricao]',
            [quantidade]',
            [avaliacao]',
            [categoria]',
            [imagem]'
        )VALUES(
            '${produto.id}',
            '${produto.nome}',
            '${produto.cod_prod}',
            '${produto.preco}',
            '${produto.descricao}',
            '${produto.quantidade}',
            '${produto.avaliacao}',
            '${produto.categoria}',
            '${produto.imagem}'
        )`);
        return lojas.recordsets;
    }
    catch(error){
        console.log(error);
    }
}

module.exports = {
    getprodutos: getprodutos,
    updateProduto: updateProduto,
    getproduto: getproduto,
    delproduto: delproduto,
    addproduto: addproduto
}