using tailfinAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(o => o.AddPolicy("AllowAnyOrigins", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

builder.Services.AddDbContext<AppDbContext>();



var app = builder.Build();


app.MapControllers();
app.UseCors("AllowAnyOrigins");


app.Run();
