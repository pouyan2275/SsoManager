﻿using Application.Bases;
using GhasemIranApi.Bases;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddBaseDependecies();

var app = builder.Build();

// Configure the HTTP request pipeline.
//#if !DEBUG
//app.UseMiddleware<ExceptionHandlingMiddleware>();
//#endif

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.UseCors(o =>
{
    o.AllowAnyOrigin();
    o.AllowAnyMethod();
    o.AllowAnyHeader();
});

app.Run();
