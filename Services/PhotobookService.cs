using Photobook_App_BE;

public class PhotobookService : IPhotobookService
{
    private readonly IPhotobookThirdPartyService _photobookThirdPartyService;

    public PhotobookService(IPhotobookThirdPartyService photobookThirdPartyService)
    {
        _photobookThirdPartyService = photobookThirdPartyService;
    }

    public async Task<List<Album>> RetrievePhotobookList(int userId = 0)
    {
        List<Album> AlbumList = await _photobookThirdPartyService.GetAlbums(userId);

        return await RetrieveAndFilterAlbumPhotoList(AlbumList);
    }

    public async Task<List<Album>> RetrievePhotobookList()
    {
        List<Album> AlbumList = await _photobookThirdPartyService.GetAlbums();

        return await RetrieveAndFilterAlbumPhotoList(AlbumList);
    }

    private async Task<List<Album>> RetrieveAndFilterAlbumPhotoList(List<Album> AlbumList)
    {
        List<int> AlbumIds = AlbumList.Select(c => c.Id).ToList();
        List<Photo> PhotoList = await _photobookThirdPartyService.GetPhotos(AlbumIds);

        //for each album, here we filter and add the associated list of photos
        foreach (Album album in AlbumList)
        {
            List<Photo> filteredList = PhotoList
            .Where(c => c.AlbumId == album.Id)
            .ToList();

            album.PhotoList = filteredList.ToList();
        }

        return AlbumList;
    }

}