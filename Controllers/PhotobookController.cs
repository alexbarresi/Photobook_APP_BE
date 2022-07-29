using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Photobook_App_BE.Controllers;

[ApiController]
[Route("api/Photobook")]
[Produces("application/json")]
public class PhotobookController : ControllerBase
{
    private readonly IPhotobookService _photobookService;

    public PhotobookController(IPhotobookService imageService)
    {
        _photobookService = imageService;
    }

    [HttpGet("{userId}")]
    public ActionResult<List<Album>> Get(int userId)
    {
        return _photobookService.RetrievePhotobooksList(userId);
    }

    [HttpGet]
    public ActionResult<List<Album>> Get()
    {
        return _photobookService.RetrievePhotobooksList();
    }

    // [HttpGet("GetPhotos")]
    // public ActionResult<IEnumerable<Photo>> GetPhotos()
    // {
    //     _logger.LogTrace("GetPhotos start");

    //     if (_photobookService == null)
    //         return NotFound();

    //     List<Photo> PhotoList = _photobookService.GetPhotos(null);

    //     _logger.LogTrace("GetPhotos end");
    //     return PhotoList;
    // }

    // [HttpGet("GetAlbums")]
    // public ActionResult<IEnumerable<Album>> getAlbums()
    // {
    //     _logger.LogTrace("GetAlbums start");

    //     if (_photobookService == null)
    //         return NotFound();

    //     List<Album> AlbumList = _photobookService.GetAlbums();


    //     _logger.LogTrace("GetAlbums end");
    //     return AlbumList;
    // }
}
