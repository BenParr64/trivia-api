using AutoMapper;
using PubQuiz.Services;
using PubQuiz.Services.Interfaces;
using PubQuiz.Services.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMongoConnectionService, MongoConnectionService>();
builder.Services.AddScoped<IQuestionFetchService, QuestionFetchService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddSingleton(new MapperConfiguration(mc =>
{
    mc.AddProfile(new QuestionProfile());
}).CreateMapper());

var app = builder.Build();

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
