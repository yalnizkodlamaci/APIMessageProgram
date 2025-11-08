using MessageRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MessageRepository.MessageRepo>();
var app = builder.Build();

app.UseHttpsRedirection();

app.MapPost("/Mesaj", async (HttpRequest request , MessageRepository.MessageRepo repo) =>
{
    using var reader = new StreamReader(request.Body);
    string gelenMesaj = await reader.ReadToEndAsync();

    repo.Add(gelenMesaj);
    repo.Save();
    
    return ("Mesaj API Penceresinde Gözüktü ve Json'a Kaydedildi.");
});

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
