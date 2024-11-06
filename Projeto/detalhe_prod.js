function detalhes_produto() {
    var query = location.search.slice(1);
    var partes = query.split('&');
    console.log(partes)
    var valor
  
    partes.forEach(function(parte) {
      var chaveValor = parte.split('=');
      var chave = chaveValor[0];
      valor = chaveValor[1];
      console.log(chave)
      console.log(valor)
    });
  
    //fetch(`https://diwserver.vps.webdock.cloud/products/${valor}`)
    fetch(`http://localhost:8090/api/produtos/${valor}`)
      .then(res => res.json())
      .then(products => {
        console.log(products)
        let str = ''
        str +=
          `<div class="row">          
              <div class="col-md-4">
                <img src="${products.imagem}">
              </div>  
              <div class="col-md-8">
                <p>${products.nome}</p>
                <p>R$ ${products.preco}</p>
                <p2>Categoria:</p2>
                <p>${products.categoria}</p>
                <p2>Acaliação:</p2>
                <p>${products.avaliacao}</p>
                <p2>Quantidade:</p2>
                <p>${products.quantidade}</p>
                <p2>Codigo do Produto:</p2>
                <p>${products.cod_prod}</p>
                <p2>Descrição:</p2>
                <p>${products.descricao}</p>
              </div>
            </div>`
        $('#tela_detalhes').html(str)
      })
      .catch(error => console.log(error));
  }