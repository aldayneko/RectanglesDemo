using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RectanglesDemo.Application.Commands;

namespace RectanglesDemo.Api.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class RectanglesStorageController : ApiControllerBase
{
    [HttpPost("PopulateRectrangles")]
    public async Task<ActionResult> PopulateRectrangles(int count)
    {
        await Mediator.Send(new PopulateRectanglesCommand(count));
        return Ok();
    }

    [HttpPost("ClearRectrangles")]
    public async Task<ActionResult> ClearRectrangles()
    {
        await Mediator.Send(new ClearRectanglesCommand());
        return Ok();
    }
}