using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Photolabs.DAL;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddDbContext<PhotolabContext>(option => {
  option.UseNpgsql(builder.Configuration.GetConnectionString("PhotolabsContext"));
});

builder.Services.AddControllers();
builder.Services.AddCors(options =>
    options.AddPolicy("AllowAll",
        builder =>
        {
          builder.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
        }
      )
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
