using Microsoft.EntityFrameworkCore;
using Photolabs.DAL;
using Microsoft.Extensions.FileProviders;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddDbContext<PhotolabContext>(option => {
  option.UseNpgsql(builder.Configuration.GetConnectionString("PhotolabsContext"));
});

builder.Services.AddControllers();
builder.Services.AddCors(options =>
  options.AddPolicy("AllowAll", builder => {
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
  })
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseDeveloperExceptionPage();
}
app.UseStaticFiles(new StaticFileOptions
{
  FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Content/images")),
  RequestPath = "/images"
});
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
