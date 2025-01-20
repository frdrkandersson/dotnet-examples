using Microsoft.AspNetCore.Mvc;
using PolymorphicApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();
app.MapScalarApiReference();
app.MapGet("/", () => Results.Redirect("/scalar/v1")).AllowAnonymous().ExcludeFromDescription();

app.MapGet("/polymorph", () =>
{
    List<Shape> result = [new Rectangle(10m, 20m), new Circle(5.0m)];
    return result;
});

app.MapPost("/polymorph", ([FromBody] Shape baseType) => baseType);

app.Run();
