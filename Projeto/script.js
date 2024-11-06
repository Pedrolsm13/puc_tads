function init() {
    //fetch('https://diwserver.vps.webdock.cloud/products?page=1')
    fetch('http://localhost:8090/api/produtos')
        .then(res => res.json())
        .then(data => {
            console.log(data)
            let str = ''
            let aside = ''
            //data = data.products
            for (let i = 0; i < data.length; i++) {
                let products = data[i]
                console.log(products)
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
                    </div>`

                console.log(str)
                $('#tela').html(str)

            }
            for (let i = 0; i < 6; i++) {
                let products = data[i]
                console.log(products)
                aside +=
                    `<div>
                        <a href="detalhes.html?id=${products.id}"><img src="${products.imagem}"></a>
                        <p><a href="detalhes.html?id=${products.id}">${products.nome}</a><br>R$ ${products.preco}</p>
                    </div>
                    <hr>`
                console.log(aside)
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

/*const url = 'http://localhost:8090/api/produtos';

async function getprodutosjson() {
    let produtos = document.querySelector('.produtos');
    let data = await fetch(url);

    let response = await data.json();

    for (let i = 0; i < response.length; i++) {     
        let str = ''

        let id = response[i].id;
        let nome = response[i].nome;
        let cod_prod = response[i].cod_prod;
        let preco = response[i].preco;
        let descricao = response[i].descricao;
        let quantidade = response[i].quantidade;
        let avaliacao = response[i].avaliacao;
        let categoria = response[i].categoria;
        let imagem = response[i].imagem;

        str +=
            `<div class="prod">
                <a href="detalhes.html?id=${id}"><img src="${imagem}"></a>
                <p><a href="detalhes.html?id=${id}">${nome}</a><br>R$ ${preco}</p>
                <div id="apagar">${cod_prod}${descricao}${quantidade}${categoria}<p>categoria, tipo, marca</p></div>
                <div class="estrelas">
                    <input type="radio" id="cm_star-empty" name="fb" value="${avaliacao}" checked />
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
            </div>`

        console.log(str)
        $('#tela').html(str)

    }
    for (let i = 0; i < 6; i++) {
        let id = response[i].id;
        let nome = response[i].nome;
        let preco = response[i].preco;
        let imagem = response[i].imagem;

        let aside = ''

        aside +=
            `<div>
                <a href="detalhes.html?id=${id}"><img src="${imagem}"></a>
                <p><a href="detalhes.html?id=${id}">${nome}</a><br>R$ ${preco}</p>
            </div>
            <hr>`
        console.log(aside)
        $('#mais_vistos').html(aside)
    }
    
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
}*/