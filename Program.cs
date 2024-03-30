using BigHeadAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

builder.Services.AddScoped<StravaAuthService>();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("bhWebPage", policyBuilder =>
    {
        policyBuilder.WithOrigins("https://bigheadchallenge.com");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello from AWS Lambda");


app.MapControllers();

app.UseCors("bhWebPage");

//app.MapGet("/test", () => "Testing testing 3,2,1...");


app.Run();
