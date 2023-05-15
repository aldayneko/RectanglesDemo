using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RectanglesDemo.Application.Queries;
using RectanglesDemo.Domain;

namespace RectanglesDemo.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class RectanglesSearchController : ApiControllerBase
{ 
    [HttpPost("Search")]
    public async Task<ActionResult<List<SearchResult>>> Search([FromBody] Point[] points)
    {
        return await Mediator.Send(new SearchRectanglesQuery(points));
    }
}