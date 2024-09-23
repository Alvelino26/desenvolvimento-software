//Minimal APIs em C#
//Testar a API
// - Rest Client - Extensão VS Code
// - Postman
// - Insomnia
using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos = new List<Produto>
{
//     new Produto { Nome = "Apple iPhone 14", Valor = 999.99, Quantidade = 10 },
//     new Produto { Nome = "Samsung Galaxy S23", Valor = 899.99, Quantidade = 5 },
//     new Produto { Nome = "Sony WH-1000XM5", Valor = 349.99, Quantidade = 20 },
//     new Produto { Nome = "Dell XPS 13", Valor = 1199.99, Quantidade = 8 },
//     new Produto { Nome = "Apple MacBook Pro", Valor = 2399.99, Quantidade = 15 },
//     new Produto { Nome = "Bose QuietComfort 35 II", Valor = 299.99, Quantidade = 12 },
//     new Produto { Nome = "Nintendo Switch", Valor = 299.99, Quantidade = 7 },
//     new Produto { Nome = "GoPro HERO10", Valor = 499.99, Quantidade = 25 },
//     new Produto { Nome = "Kindle Paperwhite", Valor = 139.99, Quantidade = 30 },
//     new Produto { Nome = "Sony PlayStation 5", Valor = 499.99, Quantidade = 18 }
};

//Endpoints - Funcionalidades
//Requisição - URL e método/verbo HTTP
//Resposta - Dados (json/xml) e código HTTP de status
//GET: /
app.MapGet("/", () => "API de Produtos");

//GET: /api/produto/listar
app.MapGet("/api/produto/listar", () =>
{
    if(produtos.Count > 0)
    {
    return Results.Ok(produtos);
    }
    return Results.NotFound();

});

// DELETE: /api/produto/deletar
app.MapDelete("/api/produto/deletar", ([FromBody] Dictionary<string, string> data) =>
{
    if (data.TryGetValue("id", out var id))
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto != null)
        {
            produtos.Remove(produto);
            return Results.Ok(produto);
        }
        return Results.NotFound("Produto não encontrado");
    }
    return Results.BadRequest("Id do produto é necessário");
});

// PUT: /api/produto/alterar
app.MapPut("/api/produto/alterar", ([FromBody] Produto dadosAtualizacao) =>
{
    var produto = produtos.FirstOrDefault(p => p.Id == dadosAtualizacao.Id);
    if (produto != null)
    {
        // Atualiza os campos se fornecidos
        if (!string.IsNullOrEmpty(dadosAtualizacao.Nome))
        {
            produto.Nome = dadosAtualizacao.Nome;
        }
        if (dadosAtualizacao.Valor > 0)
        {
            produto.Valor = dadosAtualizacao.Valor;
        }
        if (dadosAtualizacao.Quantidade >= 0)
        {
            produto.Quantidade = dadosAtualizacao.Quantidade;
        }

        return Results.Ok(produto);
    }
    return Results.NotFound("Produto não encontrado");
});

//POST: /api/produto/cadastrar/param_nome
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto) =>
{
    produtos.Add(produto);
    return Results.Created("", produto);
});

// POST: /api/produto/buscar
app.MapPost("/api/produto/buscar", ([FromBody] string nome) =>
{
    var produto = produtos.FirstOrDefault(p => p.Nome == nome);
    if (produto != null)
    {
        return Results.Ok(produto);
    }
    return Results.NotFound("Produto não encontrado");
});



app.Run();

//Exercícios para aula de hoje
// - Buscar um produto pelo nome


