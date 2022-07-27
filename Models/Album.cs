using System.ComponentModel.DataAnnotations;

namespace Photobook_App_BE;

public class Album
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    public List<Photo> PhotoList { get; set; }

}
