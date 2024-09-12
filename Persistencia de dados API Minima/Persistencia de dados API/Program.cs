using Microsoft.EntityFrameworkCore;
using Persistencia_de_dados_API;
using static Persistencia_de_dados_API.Todo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(@"Server=localhost;Database=Persistenciadados;Trusted_Connection=True;TrustServerCertificate=true"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Endpoints para Todo (Categorias e Produtos)

app.MapGet("/Todos", async (ApplicationDbContext db) =>
    await db.Categorias.ToListAsync());

app.MapGet("/Todos/{id}", async (ApplicationDbContext db, int id) =>
    await db.Categorias.FindAsync(id) is Todo todo
        ? Results.Ok(todo)
        : Results.NotFound());

// Leitura de dados por código do produto
app.MapGet("/Todos/Codigo/{codigoProduto}", async (ApplicationDbContext db, int codigoProduto) =>
{
    var produto = await db.Categorias.FirstOrDefaultAsync(p => p.Codigo_Produto == codigoProduto);
    return produto != null ? Results.Ok(produto) : Results.NotFound();
});

// Leitura de dados por categoria
app.MapGet("/Todos/Categoria/{categoria}", async (ApplicationDbContext db, string categoria) =>
{
    var produtos = await db.Categorias.Where(p => p.Categoria == categoria).ToListAsync();
    return produtos.Count > 0 ? Results.Ok(produtos) : Results.NotFound();
});

app.MapPost("/Todos", async (Todo todo, ApplicationDbContext db) =>
{
    db.Categorias.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/Todos/{todo.id}", todo);
});

app.MapPut("/Todos/{id}", async (ApplicationDbContext db, int id, Todo inputTodo) =>
{
    var todo = await db.Categorias.FindAsync(id);
    if (todo is null) return Results.NotFound();

    todo.Nome_Produto = inputTodo.Nome_Produto;
    todo.Codigo_Produto = inputTodo.Codigo_Produto;
    todo.Preco_Produto = inputTodo.Preco_Produto;
    todo.Descricao_Produto = inputTodo.Descricao_Produto;
    todo.Quantidade_Estoque = inputTodo.Quantidade_Estoque;
    todo.Avaliacao = inputTodo.Avaliacao;
    todo.Categoria = inputTodo.Categoria;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Todos/{id}", async (ApplicationDbContext db, int id) =>
{
    if (await db.Categorias.FindAsync(id) is Todo todo)
    {
        db.Categorias.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }
    return Results.NotFound();
});

app.Urls.Add("https://localhost:3000");

app.Run();
