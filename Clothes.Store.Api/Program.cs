using Clothes.Store.Api.Configuration;
using Clothes.Store.Db.Context;
using Clothes.Store.Db.Interfaces;
using Clothes.Store.Db.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.AddOptions();
builder.Services.AddHttpClient();
builder.Services.AddServices();
        
       


    

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}
app.Run();
