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
        return _photobookService.RetrievePhotobookList();
    }

    [HttpGet("{userId}")]
    public ActionResult<List<Album>> Get(int userId)
    {
        return _photobookService.RetrievePhotobookList(userId);
    }

}
