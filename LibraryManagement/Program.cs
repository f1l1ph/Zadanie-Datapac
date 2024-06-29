using ClassLibrary.Application.Book;
using ClassLibrary.Context;
using ClassLibrary.Repositories.BookRepositories;
using ClassLibrary.Repositories.BorrowOrderRepositories;
using EmailWorker;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Services;
using LibraryManagement.EmailWorker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddBookCommand).Assembly));

builder.Services.AddTransient<IBookRepositoryWrite, BookRepositoryWrite>();
builder.Services.AddTransient<IBookRepositoryRead, BookRepositoryRead>();
builder.Services.AddTransient<IBOrderRepositoryWrite, BOrderRepositoryWrite>();
builder.Services.AddTransient<IBOrderRepositoryRead, BOrderRepositoryRead>();

builder.Services.AddHostedService<EmailHostedService>();
builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.AddDbContext<LibraryContextWrite>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("db"),
        b => b.MigrationsAssembly("LibraryManagement")));

builder.Services.AddDbContext<LibraryContextRead>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("db"), 
        b => b.MigrationsAssembly("LibraryManagement")));

builder.Services.AddHostedService<Worker>();


var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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
