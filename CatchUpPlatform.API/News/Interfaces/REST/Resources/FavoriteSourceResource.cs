namespace CatchUpPlatform.API.News.Interfaces.REST.Resources;

/// <summary>
/// Resource to get a favorite source
/// </summary>
/// <param name="Id"> The Favorite source id generated by this api </param>
/// <param name="NewsApiKey"> The news api key generated by the news provider </param>
/// <param name="SourceId"> The news provider source id </param>
public record FavoriteSourceResource(int Id, string NewsApiKey, string SourceId);