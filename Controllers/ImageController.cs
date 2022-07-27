using Microsoft.AspNetCore.Mvc;

namespace Photobook_App_BE.Controllers;

[ApiController]
[Route("AlbumPhoto")]
[Produces("application/json")]
public class AlbumPhotoController : ControllerBase
{
    private readonly ILogger<AlbumPhotoController> _logger;
    private readonly IAlbumPhotoService _imageService;
    public AlbumPhotoController(ILogger<AlbumPhotoController> logger, IAlbumPhotoService imageService)
    {
        _logger = logger;
        _imageService = imageService;
    }

    [HttpGet("GetAlbumPhotosByUserId")]
    public ActionResult<List<Album>> GetAlbumPhotosByUserId(int userId)
    {
        _logger.LogTrace("GetAlbumPhotosByUserId start");

        if (_imageService == null)
            return NotFound();

        return _imageService.RetrieveAlbumPhotosList(userId);
    }

    [HttpGet("GetAlbumPhotos")]
    public ActionResult<List<Album>> GetAlbumPhotos()
    {
        _logger.LogTrace("GetAlbumPhotos start");

        if (_imageService == null)
            return NotFound();

        return _imageService.RetrieveAlbumPhotosList();
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
