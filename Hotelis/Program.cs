using Hotelis.DatabaseContext;
using Hotelis.Model;
using Hotelis.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
    {
        builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000", "https://appname.azurestaticapps.net");
    });
});

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseInMemoryDatabase(databaseName: "HotelDB");
});
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dbContext.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
