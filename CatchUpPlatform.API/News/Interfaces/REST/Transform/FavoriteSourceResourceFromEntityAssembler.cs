using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Interfaces.REST.Resources;

namespace CatchUpPlatform.API.News.Interfaces.REST.Transform;


/// <summary>
/// Create FavoriteSourceResource from FavoriteSource entity
/// </summary>
public static class FavoriteSourceResourceFromEntityAssembler
{
    
    /// <summary>
    /// Create FavoriteSourceResource from FavoriteSource entity
    /// </summary>
    /// <param name="entity"> the <see cref="FavoriteSource"/> entity </param>
    /// <returns> the <see cref="FavoriteSourceResource"/> </returns>
    public static FavoriteSourceResource ToResourceFromEntity( FavoriteSource entity)
    {
        return new FavoriteSourceResource(entity.Id,entity.NewsApiKey, entity.SourceId);
    }
}