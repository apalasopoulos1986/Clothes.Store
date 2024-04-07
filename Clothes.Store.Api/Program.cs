using Clothes.Store.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
{
    {
        var connectionString = builder.Configuration.GetConnectionString("DbConnection");
        builder.AddOptions();
        builder.Services.AddHttpClient();
        builder.Services.AddServices();
    }

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
}
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
