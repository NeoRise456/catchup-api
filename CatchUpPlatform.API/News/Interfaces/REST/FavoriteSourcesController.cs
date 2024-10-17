using System.Net.Mime;
using CatchUpPlatform.API.News.Domain.Model.Queries;
using CatchUpPlatform.API.News.Domain.Services;
using CatchUpPlatform.API.News.Interfaces.REST.Resources;
using CatchUpPlatform.API.News.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CatchUpPlatform.API.News.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Favorite Sources")]

public class FavoriteSourcesController(
    IFavoriteSourceCommandService favoriteSourceCommandService,
    IFavoriteSourceQueryService favoriteSourceQueryService
    ) : ControllerBase
{
    
    /// <summary>
    /// Get Favorite Source By ID
    /// </summary>
    /// <param name="Id"> the favorite source ID provided by this api </param>
    /// <returns>
    /// A <see cref="FavoriteSourceResource"/> object
    /// </returns>
    
    [SwaggerOperation(
        Summary = "Get Favorite Source By ID",
        Description = "Get a favorite source by given ID",
        OperationId = "GetFavoriteSourceById"
        )]
    [SwaggerResponse(200,"the favorite source was found",typeof(FavoriteSourceResource))]
    [SwaggerResponse(404,"the favorite source was not found")]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetFavoriteSourceById(int Id)
    {
        var getFavoriteSourceByIdQuery = new GetFavoriteSourceByIdQuery(Id);
        var result = await favoriteSourceQueryService.Handle(getFavoriteSourceByIdQuery);
        if (result == null)
        {
            return NotFound();
        }

        var resource = FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}