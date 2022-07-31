using Photobook_App_BE;

public interface IPhotobookThirdPartyService
{
    Task<List<Album>> GetAlbums(int userId = 0);

    Task<List<Photo>> GetPhotos(List<int> albumIds = null);

}