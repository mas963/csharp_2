using Mapster;
using PatricGodMapsterMappingExample.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

ConfigureMapster();

var gameCharacters = new List<GameCharacter>
{
    new GameCharacter
    {
        Id = 1,
        Name = "Ellie",
        Location = new Location
        {
            Name = "Jackson",
            Description = "A well-protected settlement in Wyoming."
        }
    },
    new GameCharacter
    {
        Id = 2,
        Name = "Joel",
        Location = new Location
        {
            Name = "Boston",
            Description = "A city in ruins with dangerous factions."
        }
    }
};

app.MapGet("/gamecharacters", () => gameCharacters.Adapt<List<GameCharacterDto>>());

app.Run();

void ConfigureMapster()
{
    TypeAdapterConfig<GameCharacter, GameCharacterDto>.NewConfig()
        .Map(dest => dest.FullName, src => src.Name);

    TypeAdapterConfig<Location, LocationDto>.NewConfig()
        .Map(dest => dest.Name, src => src.Name.ToUpper());
}