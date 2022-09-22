using Microsoft.EntityFrameworkCore;
using PlaylistsApi.Adapters;
using PlaylistsApi.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PlaylistsDataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("songs");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IProvideTheSongCatalog, SongCatalog>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();