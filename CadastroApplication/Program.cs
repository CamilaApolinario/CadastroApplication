using CadastroApplication.Infra;
using CadastroApplication.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CadastroApplicationContext>(
    options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("CadastroApplicationConnection"), b => b.MigrationsAssembly("CadastroApplication"))
    );

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CadastroApplication", Version = "v1" });
    c.ResolveConflictingActions(x => x.First());
});

builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder.WithOrigins("http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

//app.UseSpa(spa =>
//{
//    spa.Options.SourcePath = "my-app";

//    if (app.Environment.IsDevelopment())
//    {
//        spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
//    }
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CadastroApplication v1"));
}



app.UseCors("AllowReactApp");


app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});



