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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
  app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
