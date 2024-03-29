using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;
using System;
using DataAccessLayer;
using DataAccessLayer.IRepository;
using BusinessLayer.IServices;
using DataAccessLayer.Repository;
using BusinessLayer.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DBConnectString");
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
	builder.WithOrigins("http://localhost:4200")
		   .AllowAnyHeader()
		   .AllowAnyMethod();
});

app.MapControllers();

// Use JWT authentication
var key = Encoding.ASCII.GetBytes("your-secret-key"); 
app.UseAuthentication();
app.UseAuthorization();



app.Run();
