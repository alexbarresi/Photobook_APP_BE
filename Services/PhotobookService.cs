using Photobook_App_BE;

public class PhotobookService : PhotobookThirdPartyService, IPhotobookService
{
    public List<Album> RetrievePhotobookList(int userId = 0)
    {
        List<Album> AlbumList = GetAlbums(userId);

        return RetrieveAndFilterAlbumPhotoList(AlbumList);
    }

    public List<Album> RetrievePhotobookList()
    {
        List<Album> AlbumList = GetAlbums();

        return RetrieveAndFilterAlbumPhotoList(AlbumList);
    }

    private List<Album> RetrieveAndFilterAlbumPhotoList(List<Album> AlbumList)
    {
        List<int> AlbumIds = AlbumList.Select(c => c.Id).ToList();
        List<Photo> PhotoList = GetPhotos(AlbumIds);

        //for each album, here we filter and add the associated list of photos
        foreach (Album album in AlbumList)
        {
            List<Photo> filteredList = PhotoList
            .Select(c => c)
            .Where(c => c.AlbumId == album.Id)
            .ToList();

            album.PhotoList = filteredList.ToList();
        }

        return AlbumList;
    }

}