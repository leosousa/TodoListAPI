using FluentValidation.AspNetCore;
using ToDoListAPI.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.AddApplicationDependencies();
builder.Services.AddInfraDependencies(builder.Configuration);

builder.Services.AddControllers(options => 
    options.Filters.Add<ApiExceptionFilterAttribute>());

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
