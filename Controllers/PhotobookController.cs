using Microsoft.AspNetCore.Mvc;

namespace Photobook_App_BE.Controllers;

[ApiController]
[Route("Photobook")]
[Produces("application/json")]
public class PhotobookController : ControllerBase
{
    private readonly ILogger<PhotobookController> _logger;
    private readonly IPhotobookService _imageService;
    public PhotobookController(ILogger<PhotobookController> logger, IPhotobookService imageService)
    {
        _logger = logger;
        _imageService = imageService;
    }

    [HttpGet("GetPhotobooksByUserId")]
    public ActionResult<List<Album>> GetPhotobooksByUserId(int userId)
    {
        _logger.LogTrace("GetPhotobooksByUserId start");

        if (_imageService == null)
            return NotFound();

        return _imageService.RetrievePhotobooksList(userId);
    }

    [HttpGet("GetPhotobooks")]
    public ActionResult<List<Album>> GetPhotobooks()
    {
        _logger.LogTrace("GetPhotobooks start");

        if (_imageService == null)
            return NotFound();

        return _imageService.RetrievePhotobooksList();
    }

    // [HttpGet("GetPhotos")]
    // public ActionResult<IEnumerable<Photo>> GetPhotos()
    // {
    //     _logger.LogTrace("GetPhotos start");

    //     if (_imageService == null)
    //         return NotFound();

    //     List<Photo> PhotoList = _imageService.GetPhotos(null);

    //     _logger.LogTrace("GetPhotos end");
    //     return PhotoList;
    // }

    // [HttpGet("GetAlbums")]
    // public ActionResult<IEnumerable<Album>> getAlbums()
    // {
    //     _logger.LogTrace("GetAlbums start");

    //     if (_imageService == null)
    //         return NotFound();

    //     List<Album> AlbumList = _imageService.GetAlbums();


    //     _logger.LogTrace("GetAlbums end");
    //     return AlbumList;
    // }
}
