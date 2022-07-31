using Microsoft.AspNetCore.Mvc;

namespace Photobook_App_BE.Controllers;

[ApiController]
[Route("api/Photobook")]
[Produces("application/json")]
public class PhotobookController : ControllerBase
{
    private readonly IPhotobookService _photobookService;

    public PhotobookController(IPhotobookService photobookService)
    {
        _photobookService = photobookService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Album>>> Get()
    {
        List<Album> AlbumList = await _photobookService.RetrievePhotobookList();

        return Ok(AlbumList);
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<List<Album>>> Get(int userId)
    {
        List<Album> AlbumList = await _photobookService.RetrievePhotobookList(userId);

        return AlbumList.Any() ?
            Ok(AlbumList) :
            NotFound("User ID or Album list not found");
    }

}
