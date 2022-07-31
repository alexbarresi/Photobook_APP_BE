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
    public ActionResult<List<Album>> Get()
    {
        List<Album> AlbumList = _photobookService.RetrievePhotobookList();

        return AlbumList != null && AlbumList.Count() != 0 ?
            Ok(AlbumList) :
            NotFound("Album list not found");
    }

    [HttpGet("{userId}")]
    public ActionResult<List<Album>> Get(int userId)
    {
        List<Album> AlbumList = _photobookService.RetrievePhotobookList(userId);

        return AlbumList != null && AlbumList.Count() != 0 ?
            Ok(AlbumList) :
            NotFound("User ID or Album list not found");
    }

}
