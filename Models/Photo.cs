using System.ComponentModel.DataAnnotations;

namespace Photobook_App_BE;

public class Photo
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int AlbumId { get; set; }

    [Required]
    public string Url { get; set; }

    [Required]
    public string ThumbnailUrl { get; set; }

    public string Title { get; set; }
}
