using Microsoft.EntityFrameworkCore;
using Criacao_de_uma_API_minima;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/TodoItems", async(TodoDb db) =>
    await db.Todos.ToListAsync());

app.MapGet("/TodoItems/Complete", async(TodoDb db) =>
    //await db.Todos.Where(t => t.IsComplete == true).ToListAsync());
    await db.Todos.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/TodoItems/notcompleted", async (TodoDb db) =>
    await db.Todos.Where(t => !t.IsComplete).ToListAsync());

app.MapGet("/TodoItems/{Id}", async (TodoDb db, int id) =>
    await db.Todos.FindAsync(id)
        is Todo todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.MapGet("/TodoItems/Codigo/{Codigo_Produto}", async (TodoDb db, int Codigo_Produto) =>
{
    var todo = await db.Todos.FirstOrDefaultAsync(t => t.Codigo_Produto == Codigo_Produto);

    return todo != null ? Results.Ok(todo) : Results.NotFound();
});

app.MapGet("/TodoItems/Categoria/{Categoria}", async (TodoDb db, string Categoria) =>
{
    var todos = await db.Todos.Where(t => t.Categoria == Categoria).ToListAsync();

    return todos.Count > 0 ? Results.Ok(todos) : Results.NotFound();
});

app.MapPost("/TodoItems", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/TodoItems/{todo.Codigo_Produto}", todo);
});

app.MapPut("/TodoItems/{id}", async (TodoDb db, int id, Todo inputTodo) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) Results.NotFound();

    todo.Nome_Produto = inputTodo.Nome_Produto;
    todo.Codigo_Produto = inputTodo.Codigo_Produto;
    todo.Preco_Produto = inputTodo.Preco_Produto;
    todo.Descricao_Produto = inputTodo.Descricao_Produto;
    todo.Quantidade_Estoque = inputTodo.Quantidade_Estoque;
    todo.Avaliacao = inputTodo.Avaliacao;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/TodoItems/{id}", async (TodoDb db, int id) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }
    return Results.NotFound();
});

app.Urls.Add("https://localhost:3000");

app.Run();
