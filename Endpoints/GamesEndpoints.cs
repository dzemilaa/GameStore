
using GameStore.Api.DTOs;
using GameStore.Api.Models;
using GameStore.Api.Models.Data;

namespace GameStore.Api.Endpoints
{
    public static class GamesEndpoints
    {
         const string GetGameEndpointName = "GetGame";
        private static readonly List<GameDto> games = [
            new(1, "Street Fighter II", "Fighting", 19.99M, new DateOnly(1922, 7, 16)),
            new(2, "Street Fighter 3", "Fighting", 19.99M, new DateOnly(1922, 7, 16)),
            new(3, "Street Fighter 4", "Fighting", 19.99M, new DateOnly(1922, 7, 16)),
        ];
    public static void MapGamesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/games");
            
// GET /games
group.MapGet("/", () => games);


//GET /games/1
group.MapGet("/{id}", (int id) => 
{
var game = games.Find(game => game.Id == id);
return game is null ? Results.NotFound() : Results.Ok(game);
})
.WithName(GetGameEndpointName);
//POST /games
group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext)=>
{

   Game game = new()
   {
    Name = newGame.Name,
    GenreId = newGame.GenreId,
    Price = newGame.Price,
    ReleaseDate = newGame.ReleaseDate
   };
   dbContext.Games.Add(game);
   dbContext.SaveChanges();

   GameDetailsDto gameDto = new (
    game.Id,
    game.Name,
    game.GenreId,
    game.Price,
    game.ReleaseDate
   );
   return Results.CreatedAtRoute(GetGameEndpointName, new{id = gameDto.Id}, gameDto);
});
//PUT /games/1
group.MapPut("/{id}", (int id, UpdateGameDto updatedGame)=>
{
    var index = games.FindIndex(game => game.Id==id);
    if (index == -1)
    {
        return Results.NotFound();
    }
    games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );
    return Results.NoContent();
});

//DELETE /games/1
group.MapDelete("/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);
    return Results.NoContent();
}
);
        }
    }
}
