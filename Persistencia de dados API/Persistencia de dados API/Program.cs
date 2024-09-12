using Microsoft.EntityFrameworkCore;
using Persistencia_de_dados_API;
using static Persistencia_de_dados_API.Todo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(@"Server=localhost;Database=Persistencia;Trusted_Connection=True;TrustServerCertificate=true"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Endpoints para Categoria
app.MapGet("/Categorias", async (ApplicationDbContext db) =>
    await db.Categorias.Include(c => c.Produtos).ToListAsync());

app.MapGet("/Categorias/{id}", async (ApplicationDbContext db, int id) =>
    await db.Categorias.Include(c => c.Produtos).FirstOrDefaultAsync(c => c.Id == id) is Categoria categoria
        ? Results.Ok(categoria)
        : Results.NotFound());

app.MapPost("/Categorias", async (Categoria categoria, ApplicationDbContext db) =>
{
    db.Categorias.Add(categoria);
    await db.SaveChangesAsync();
    return Results.Created($"/Categorias/{categoria.Id}", categoria);
});

app.MapPut("/Categorias/{id}", async (ApplicationDbContext db, int id, Categoria inputCategoria) =>
{
    var categoria = await db.Categorias.FindAsync(id);
    if (categoria is null) return Results.NotFound();

    categoria.Nome = inputCategoria.Nome;
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Categorias/{id}", async (ApplicationDbContext db, int id) =>
{
    if (await db.Categorias.FindAsync(id) is Categoria categoria)
    {
        db.Categorias.Remove(categoria);
        await db.SaveChangesAsync();
        return Results.Ok(categoria);
    }
    return Results.NotFound();
});

// Endpoints para Produto
app.MapGet("/Produtos", async (ApplicationDbContext db) =>
    await db.Produtos.ToListAsync());

app.MapGet("/Produtos/{id}", async (ApplicationDbContext db, int id) =>
    await db.Produtos.FindAsync(id) is Produto produto
        ? Results.Ok(produto)
        : Results.NotFound());

// Leitura de dados por categoria
app.MapGet("/Produtos/Categoria/{categoriaId}", async (ApplicationDbContext db, int categoriaId) =>
{
    var produtos = await db.Produtos.Where(p => p.CategoriaID == categoriaId).ToListAsync();
    return produtos.Count > 0 ? Results.Ok(produtos) : Results.NotFound();
});

// Leitura de dados por código do produto
app.MapGet("/Produtos/Codigo/{codigoProduto}", async (ApplicationDbContext db, int codigoProduto) =>
{
    var produto = await db.Produtos.FirstOrDefaultAsync(p => p.Id == codigoProduto);
    return produto != null ? Results.Ok(produto) : Results.NotFound();
});

app.MapPost("/Produtos", async (Produto produto, ApplicationDbContext db) =>
{
    db.Produtos.Add(produto);
    await db.SaveChangesAsync();
    return Results.Created($"/Produtos/{produto.Id}", produto);
});

app.MapPut("/Produtos/{id}", async (ApplicationDbContext db, int id, Produto inputProduto) =>
{
    var produto = await db.Produtos.FindAsync(id);
    if (produto is null) return Results.NotFound();

    produto.Nome = inputProduto.Nome;
    produto.Preco = inputProduto.Preco;
    produto.Descricao = inputProduto.Descricao;
    produto.Estoque = inputProduto.Estoque;
    produto.Avaliacao = inputProduto.Avaliacao;
    produto.CategoriaID = inputProduto.CategoriaID;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Produtos/{id}", async (ApplicationDbContext db, int id) =>
{
    if (await db.Produtos.FindAsync(id) is Produto produto)
    {
        db.Produtos.Remove(produto);
        await db.SaveChangesAsync();
        return Results.Ok(produto);
    }
    return Results.NotFound();
});

app.Urls.Add("https://localhost:3000");

app.Run();


/*using Microsoft.EntityFrameworkCore;
using Persistencia_de_dados_API;
using static Persistencia_de_dados_API.Todo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(@"Server=localhost;Database=Persistencia;Trusted_Connection=True;TrustServerCertificate=true"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Endpoints para Categoria
app.MapGet("/Categorias", async (ApplicationDbContext db) =>
    await db.Categorias.Include(c => c.Produtos).ToListAsync());

app.MapGet("/Categorias/{id}", async (ApplicationDbContext db, int id) =>
    await db.Categorias.Include(c => c.Produtos).FirstOrDefaultAsync(c => c.Id == id) is Categoria categoria
        ? Results.Ok(categoria)
        : Results.NotFound());

app.MapPost("/Categorias", async (Categoria categoria, ApplicationDbContext db) =>
{
    db.Categorias.Add(categoria);
    await db.SaveChangesAsync();
    return Results.Created($"/Categorias/{categoria.Id}", categoria);
});

app.MapPut("/Categorias/{id}", async (ApplicationDbContext db, int id, Categoria inputCategoria) =>
{
    var categoria = await db.Categorias.FindAsync(id);
    if (categoria is null) return Results.NotFound();

    categoria.Nome = inputCategoria.Nome;
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Categorias/{id}", async (ApplicationDbContext db, int id) =>
{
    if (await db.Categorias.FindAsync(id) is Categoria categoria)
    {
        db.Categorias.Remove(categoria);
        await db.SaveChangesAsync();
        return Results.Ok(categoria);
    }
    return Results.NotFound();
});

// Endpoints para Produto
app.MapGet("/Produtos", async (ApplicationDbContext db) =>
    await db.Produtos.ToListAsync());

app.MapGet("/Produtos/{id}", async (ApplicationDbContext db, int id) =>
    await db.Produtos.FindAsync(id) is Produto produto
        ? Results.Ok(produto)
        : Results.NotFound());

app.MapGet("/Produtos/Categoria/{categoriaId}", async (ApplicationDbContext db, int categoriaId) =>
    await db.Produtos.Where(p => p.CategoriaID == categoriaId).ToListAsync());

app.MapPost("/Produtos", async (Produto produto, ApplicationDbContext db) =>
{
    db.Produtos.Add(produto);
    await db.SaveChangesAsync();
    return Results.Created($"/Produtos/{produto.Id}", produto);
});

app.MapPut("/Produtos/{id}", async (ApplicationDbContext db, int id, Produto inputProduto) =>
{
    var produto = await db.Produtos.FindAsync(id);
    if (produto is null) return Results.NotFound();

    produto.Nome = inputProduto.Nome;
    produto.Preco = inputProduto.Preco;
    produto.Descricao = inputProduto.Descricao;
    produto.Estoque = inputProduto.Estoque;
    produto.Avaliacao = inputProduto.Avaliacao;
    produto.CategoriaID = inputProduto.CategoriaID;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Produtos/{id}", async (ApplicationDbContext db, int id) =>
{
    if (await db.Produtos.FindAsync(id) is Produto produto)
    {
        db.Produtos.Remove(produto);
        await db.SaveChangesAsync();
        return Results.Ok(produto);
    }
    return Results.NotFound();
});

app.Urls.Add("https://localhost:3000");

app.Run();
*/
