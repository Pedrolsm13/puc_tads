function init() {
    //fetch('https://diwserver.vps.webdock.cloud/products?page=1')
    fetch('http://localhost:8090/api/produtos')
        .then(res => res.json())
        .then(data => {
            //console.log(data)
            let str = ''
            let aside = ''
            //data = data.products
            for (let i = 0; i < data.length; i++) {
                let products = data[i]
                //console.log(products)
                str +=
                    `<div class="prod">
                        <a href="detalhes.html?id=${products.id}"><img src="${products.imagem}"></a>
                        <p><a href="detalhes.html?id=${products.id}">${products.nome}</a><br>R$ ${products.preco}</p>
                        <div id="apagar">${products.categoria}<p>categoria, tipo, marca</p></div>
                        <div class="estrelas">
                            <input type="radio" id="cm_star-empty" name="fb" value="${products.avaliacao}" checked />
                            <label for="cm_star-1"><i class="fa"></i></label>
                            <input type="radio" id="cm_star-1" name="fb" value="1" />
                            <label for="cm_star-2"><i class="fa"></i></label>
                            <input type="radio" id="cm_star-2" name="fb" value="2" />
                            <label for="cm_star-3"><i class="fa"></i></label>
                            <input type="radio" id="cm_star-3" name="fb" value="3" />
                            <label for="cm_star-4"><i class="fa"></i></label>
                            <input type="radio" id="cm_star-4" name="fb" value="4" />
                            <label for="cm_star-5"><i class="fa"></i></label>
                            <input type="radio" id="cm_star-5" name="fb" value="5" />
                        </div>
                        <button onclick="excluirProduto(${products.id})">Excluir Produto</button>
                    </div>`

                //console.log(str)
                $('#tela').html(str)

            }
            for (let i = 0; i < 6; i++) {
                let products = data[i]
                //console.log(products)
                aside +=
                    `<div>
                        <a href="detalhes.html?id=${products.id}"><img src="${products.imagem}"></a>
                        <p><a href="detalhes.html?id=${products.id}">${products.nome}</a><br>R$ ${products.preco}</p>
                    </div>
                    <hr>`
                //console.log(aside)
                $('#mais_vistos').html(aside)
            }
        
        })
        .catch(error => console.log(error));
}

function buscar() {
    let input = document.getElementById('text_pesq').value;
    input=input.toLowerCase();
    let x = document.getElementsByClassName('prod');

    for (i = 0; i < x.length; i++) {
        if (!x[i].innerHTML.toLowerCase().includes(input)) {
            x[i].style.display="none";
        }
        else {
            x[i].style.display="list-item";                 
        }
    }
}

function buscar2() {
    let input = document.getElementById('cat').value;
    input=input.toLowerCase();
    let x = document.getElementsByClassName('prod');

    for (i = 0; i < x.length; i++) {
        if (!x[i].innerHTML.toLowerCase().includes(input)) {
            x[i].style.display="none";
        }
        else {
            x[i].style.display="list-item";                 
        }
    }
}

function buscar3() {
    let input = document.getElementById('mar').value;
    input=input.toLowerCase();
    let x = document.getElementsByClassName('prod');

    for (i = 0; i < x.length; i++) {
        if (!x[i].innerHTML.toLowerCase().includes(input)) {
            x[i].style.display="none";
        }
        else {
            x[i].style.display="list-item";                 
        }
    }
}

function buscar4() {
    let input = document.getElementById('tip').value;
    input=input.toLowerCase();
    let x = document.getElementsByClassName('prod');

    for (i = 0; i < x.length; i++) {
        if (!x[i].innerHTML.toLowerCase().includes(input)) {
            x[i].style.display="none";
        }
        else {
            x[i].style.display="list-item";                 
        }
    }
}

function abrirFormularioCriacao() {
    document.getElementById('form-criacao').style.display = 'block';
}

function fecharFormularioCriacao() {
    document.getElementById('form-criacao').style.display = 'none';
}

async function salvarNovoProduto() {
    // Obter a lista de produtos do servidor
    const response = await fetch('http://localhost:8090/api/produtos');
    if (!response.ok) {
        throw new Error('Erro ao obter a lista de produtos');
    }
    const data = await response.json();

    // Calcular o novo ID
    const novoId = data.length + 1;

    // Obter os valores do formulário
    const novoProduto = {
        id: novoId, // Gera um ID único
        nome: document.getElementById('nome').value,
        cod_prod: parseInt(document.getElementById('cod_prod').value),
        preco: parseFloat(document.getElementById('preco').value),
        descricao: document.getElementById('descricao').value,
        quantidade: parseInt(document.getElementById('quantidade').value),
        avaliacao: parseFloat(document.getElementById('avaliacao').value),
        categoria: document.getElementById('categoria').value,
        imagem: document.getElementById('imagem').value
    };
    console.log(novoProduto)

    try {
        // Chama a função addproduto no back-end via API
        const response = await fetch('http://localhost:8090/api/produtos', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(novoProduto)
        });

        if (response.ok) {
            console.log('Produto criado com sucesso!');
            fecharFormularioCriacao();
            init(); // Atualiza a lista de produtos
        } else {
            console.error('Erro ao criar produto:', response.statusText);
        }
    } catch (error) {
        console.error('Erro ao conectar com o servidor:', error);
    }
}


async function excluirProduto(id) {
    if (confirm('Tem certeza que deseja excluir este produto?')) {
        try {
            const response = await fetch(`http://localhost:8090/api/produtos/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                }
            });

            if (response.ok) {
                console.log('Produto excluído com sucesso!');
                document.getElementById(`prod-${id}`).remove(); // Remove o produto da página
            } else {
                console.error('Erro ao excluir produto:', response.statusText);
            }
        } catch (error) {
            console.error('Erro ao conectar com o servidor:', error);
        }
    }
}

