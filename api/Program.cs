
using Microsoft.AspNetCore.Builder;

const string ALLOW_DEVELOPMENT_CORS_ORIGINS_POLICY = "AllowDevelopmentSpecificOrigins";
const string LOCAL_DEVELOPMENT_URL = "http://127.0.0.1:5173";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocument();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: ALLOW_DEVELOPMENT_CORS_ORIGINS_POLICY,
                      policy =>
                      {
                          policy.WithOrigins(LOCAL_DEVELOPMENT_URL)
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                          ;
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUi();
    app.UseDeveloperExceptionPage();
    // Register the Swagger generator and the Swagger UI middlewares
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseCors(ALLOW_DEVELOPMENT_CORS_ORIGINS_POLICY);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
