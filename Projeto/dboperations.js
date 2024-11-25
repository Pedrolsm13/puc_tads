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
    try {
        let pool = await sql.connect(config);
        let loja = await pool.request()
            .input('input_parameter', sql.Int, produto.id)
            .query(`
                UPDATE [dbo].[produtos]
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
        console.log(loja.recordsets); // Verifique o que está retornando
        return loja.recordsets;
    } catch (error) {
        console.log(error);
        throw error;
    }
}

/*async function updateProduto(produto) {
    try{
        let pool = await sql.connect(config);
        let loja = await pool.request()
        .input('input_parameter', sql.Int, produto.id)
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
}*/

async function getproduto(produtoid) {
    try{
        let pool = await sql.connect(config);
        let lojas = await pool.request()
        .input('input_parameter', sql.Int, produtoid)
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
        .input('input_parameter', sql.Int, produtoid)
        .query("DELETE FROM [dbo].[produtos] WHERE ID = @input_parameter");
        return lojas.recordsets;
    }
    catch(error){
        console.log(error);
    }
}

/*async function addproduto(produto) {
    try {
      let pool = await sql.connect(config);

      // Gerar manualmente o próximo IdProduto
      const nextIdProduto = await getNextIdProduto();

      let insertProduto = await pool.request()
        .input('id', sql.Int, nextIdProduto)
        .input('nome', sql.VarChar(100), produto.nome)
        .input('cod_prod', sql.VarChar(50), produto.cod_prod)
        .input('preco', sql.Decimal(10, 2), produto.preco)
        .input('descricao', sql.VarChar(255), produto.descricao)
        .input('quantidade', sql.Int, produto.quantidade)
        .input('avaliacao', sql.Decimal(2, 1), produto.avaliacao)
        .input('categoria', sql.VarChar(100), produto.categoria)
        .input('imagem', sql.VarChar(200), produto.imagem)
        .query('INSERT INTO Produtos (id, nome, cod_prod, preco, descricao, quantidade, avaliacao, categoria, imagem) VALUES (@id, @nome, @cod_prod, @preco, @descricao, @quantidade, @avaliacao, @categoria, @imagem)');

      return insertProduto.recordsets;
    } catch (error) {
      console.log(error);
    }
  }*/

async function addproduto(produto) {
    try{
        let pool = await sql.connect(config);
        let lojas = await pool.request()
        .query(`INSERT INTO [dbo].[produtos](
            [id],
            [nome],
            [cod_prod],
            [preco],
            [descricao],
            [quantidade],
            [avaliacao],
            [categoria],
            [imagem]
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

async function getprodutosPorCategoria(categoria) {
    try {
        let pool = await sql.connect(config);
        let lojas = await pool.request()
            .input('input_parameter', sql.VarChar, categoria) // Use VarChar para categoria
            .query("SELECT * FROM produtos WHERE categoria = @input_parameter");
        return lojas.recordsets; // Retorna todos os produtos encontrados
    } catch (error) {
        console.log(error);
        throw error; // Lança o erro para o controlador
    }
}


module.exports = {
    getprodutos: getprodutos,
    updateProduto: updateProduto,
    getproduto: getproduto,
    delproduto: delproduto,
    addproduto: addproduto,
    getprodutosPorCategoria: getprodutosPorCategoria
}