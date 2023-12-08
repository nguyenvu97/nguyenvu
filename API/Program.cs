using API.Data;
using API.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<WalletService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OderDetailService>();
builder.Services.AddScoped<DepatmentService>();
builder.Services.AddScoped<EmployeeService>();
                                               // builder.Services.AddScoped<CustomersService>();
var connectString = builder.Configuration.GetConnectionString("mysql");
builder.Services.AddDbContext<ApplicationDbContext>(option => 
    option.UseMySql(connectString, ServerVersion.AutoDetect(connectString)));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}
app.UseStaticFiles(); // hinh anh thi impost o day


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();