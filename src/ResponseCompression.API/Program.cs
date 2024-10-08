using ResponseCompression.API.DependencyInjection;
using ResponseCompression.Domain.Constants;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjection();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(CorsPoliciesNamesConstants.CorsPolicy);
app.UseResponseCompression();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
