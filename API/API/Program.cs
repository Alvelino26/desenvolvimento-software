//minimal apis em C#
//testar a API
// - Rest Client - Extensão VS code
// - Postman
// - Insomnia
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Endpoints - Funcionalidades
// Requisição - URL e metodo/verbo HTTP
app.MapGet("/", () => "UM SENTIMENTO QUE EU CHAMO DE AMOR");
app.MapGet("/FINAL", () => "CAMISA VERDE BRANCA E A BANDEIRA AO VENTO");


app.Run();

// - Criar um endpoint para receber informação pela URL
// - Criar um endpoint para receber informação pelo corpo