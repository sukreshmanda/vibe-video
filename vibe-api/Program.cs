using Azure.Identity;
using Microsoft.Extensions.Azure;
using vibe_api;
using vibe_api.Entity;
using vibe_api.Entity.SmallVideo;
using vibe_api.Middleware;
using vibe_api.Service;
using vibe_api.Service.BlobService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<SmallVideoUploadService>();
builder.Services.AddScoped<UploadTokenService>();
builder.Services.AddScoped<SmallVideoUploadService>();
builder.Services.AddScoped<IBlobService<SmallVideo>, VideoBlobService<SmallVideo>>();
builder.Services.AddScoped<ExceptionHandlingMiddleware>();

builder.Services.AddRepositories();
builder.Services.AddValidators();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddAzureClients(factoryBuilder =>
{
    var blobContainerName = builder.Configuration.GetSection("Azure")["BlobContainerName"];
    factoryBuilder.AddBlobServiceClient(new Uri($"https://{blobContainerName}.blob.core.windows.net"));
    factoryBuilder.UseCredential(new DefaultAzureCredential());
});


// builder.Services.AddScoped<ICurrentUser>();

var app = builder.Build();

app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// TODO: Remove this later.....
// app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Run();