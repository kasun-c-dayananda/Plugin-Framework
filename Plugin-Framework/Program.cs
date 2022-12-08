using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plugin_Framework.Application;
using Plugin_Framework.Application.Interfaces;
using Plugin_Framework.DbContexts;
using Plugin_Framework.Repository;
using Plugin_Framework.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register DB context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//register automapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//register dependencies
builder.Services.AddScoped<IImageEditorRepo, ImageEditorRepo>();
builder.Services.AddScoped<IApplicationImageEdit, ApplicationImageEdit>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
