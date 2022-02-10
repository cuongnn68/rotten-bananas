using Microsoft.EntityFrameworkCore;
using UserManagerService.Configurations;
using UserManagerService.Models;
using UserManagerService.Services;
using UserManagerService.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("user-manager-service"));
builder.Services.AddScoped<KafkaProducerService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DoMigration();
Seed();

app.Run();


void Seed() {
    Console.WriteLine("--- Seeding ---");
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
    if(dbContext.Users.Any()) return;
    dbContext.AddRange(new[] {
        new User {
            Username = "testuser1", 
            Email="test1@test.com", 
            Salt=Convert.FromBase64String("dGVzdHNhbHQ="), 
            HashedPassword=PasswordUtil.Hash("1", Convert.FromBase64String("dGVzdHNhbHQ="))
        },
        new User {
            Username = "testuser2", 
            Email="test2@test.com", 
            Salt=Convert.FromBase64String("dGVzdHNhbHQ="), 
            HashedPassword=PasswordUtil.Hash("1", Convert.FromBase64String("dGVzdHNhbHQ="))
        },
        new User {
            Username = "testuser3", 
            Email="test3@test.com", 
            Salt=Convert.FromBase64String("dGVzdHNhbHQ="), 
            HashedPassword=PasswordUtil.Hash("1", Convert.FromBase64String("dGVzdHNhbHQ="))
        },
    });
    dbContext.SaveChanges();
    Console.WriteLine("---Seed---");
}

void DoMigration() {

}