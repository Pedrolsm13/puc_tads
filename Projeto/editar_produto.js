function carregarDadosProduto() {
    const produtoId = new URLSearchParams(window.location.search).get('id');
    
    fetch(`http://localhost:8090/api/produtos/${produtoId}`)
      .then(res => res.json())
      .then(produto => {
        document.getElementById('nome').value = produto[0].nome;
        document.getElementById('cod_prod').value = produto[0].cod_prod;
        document.getElementById('preco').value = produto[0].preco;
        document.getElementById('descricao').value = produto[0].descricao;
        document.getElementById('quantidade').value = produto[0].quantidade;
        document.getElementById('avaliacao').value = produto[0].avaliacao;
        document.getElementById('categoria').value = produto[0].categoria;
        document.getElementById('imagem').value = produto[0].imagem;
      })
      .catch(error => console.log(error));
  }
  
  function salvarEdicao() {
    const produtoId = new URLSearchParams(window.location.search).get('id');
    
    const produtoAtualizado = {
      id: produtoId,
      nome: document.getElementById('nome').value,
      cod_prod: parseInt(document.getElementById('cod_prod').value),
      preco: parseFloat(document.getElementById('preco').value),
      descricao: document.getElementById('descricao').value,
      quantidade: parseInt(document.getElementById('quantidade').value),
      avaliacao: parseFloat(document.getElementById('avaliacao').value),
      categoria: document.getElementById('categoria').value,
      imagem: document.getElementById('imagem').value
    };
  
    fetch(`http://localhost:8090/api/produtos/${produtoId}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(produtoAtualizado)
    })
      .then(res => res.json())
      .then(data => {
        alert('Produto atualizado com sucesso!');
        window.location.href = `detalhes_produto.html?id=${produtoId}`; // Redireciona de volta para a página de detalhes
      })
      .catch(error => console.log(error));
  }
  