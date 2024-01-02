using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using GameStore.Api.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

#region refactor1
// use for inmemorystorage
//builder.Services.AddSingleton<IGamesRepository, InMemoryGamesRepository>();

// use for sqlserver & entityframework
//builder.Services.AddScoped<IGamesRepository, EntityFrameworkGamesRepository>();

//Moved to GameStore.Api.Data.DataExtensions.cs
//var connString = builder.Configuration.GetConnectionString("GameStoreContext");
//builder.Services.AddSqlServer<GameStoreContext>(connString);    
#endregion
builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

#region refactor2
/*
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
    dbContext.Database.Migrate();
}
*/
//Moved to GameStore.Api.Data.DataExtensions.cs    
#endregion
await app.Services.InitializeDbAsync();


app.MapGamesEndPoints();

app.Run();
