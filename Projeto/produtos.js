class produtos{
    constructor(id, nome, cod_prod, preco, descricao, quantidade, avaliacao, categoria, imagem){
        this.id = id;
        this.nome = nome;
        this.cod_prod = cod_prod;
        this.preco = preco;
        this.descricao = descricao;
        this.quantidade = quantidade;
        this.avaliacao = avaliacao;
        this.categoria = categoria;
        this.imagem = imagem;
    }
}

module.exports = produtos;