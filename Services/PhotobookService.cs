using Photobook_App_BE;

public class PhotobookService : IPhotobookService
{
    private readonly Uri _baseUrl = new Uri("https://jsonplaceholder.typicode.com");
    private static readonly HttpClient _client = new();
    private List<Album> _albums;
    private List<Photo> _photos;

    public PhotobookService()
    {
        _albums = new();
        _photos = new();
    }

    public List<Album> RetrievePhotobooksList(int userId = 0)
    {
        List<Album> AlbumList = GetAlbums(userId);
        
        List<int> AlbumIds = AlbumList.Select(c => c.Id).ToList();
        List<Photo> PhotoList = GetPhotos(AlbumIds);

        //for each album, here I add the associated list of photos
        foreach (Album album in AlbumList)
        {
            List<Photo> filteredList = PhotoList
            .Select(c => c)
            .Where(c => c.Id == album.Id)
            .ToList();

            album.PhotoList = filteredList.ToList();
        }

        return AlbumList;
    }

    public List<Photo> GetPhotos(List<int> albumIds = null)
    {
        Uri url = AddAlbumIdsToUrl(new Uri(_baseUrl, "/photos"), albumIds);

        HttpResponseMessage res = Get(url);
        _photos = res.Content.ReadFromJsonAsync<List<Photo>>().Result;

        return _photos;
    }

    public List<Album> GetAlbums(int userId = 0)
    {
        Uri url = AddUserIdToUrl(new Uri(_baseUrl, "/albums"), userId);

        HttpResponseMessage res = Get(url);
        _albums = res.Content.ReadFromJsonAsync<List<Album>>().Result;

        return _albums;
    }

    #region Utility Methods
    private static Uri AddUserIdToUrl(Uri url, int id)
    {
        return id != 0 ? new Uri($"{url.AbsoluteUri}?userId={id}") : url;
    }

    private static Uri AddAlbumIdsToUrl(Uri url, List<int> albumIds)
    {
        if (albumIds == null || albumIds?.Count() == 0)
            return url;

        string queryWithIds = null;

        foreach (int id in albumIds)
        {
            if (string.IsNullOrWhiteSpace(queryWithIds))
                queryWithIds += $"AlbumId={id}";
            else
                queryWithIds += $"&AlbumId={id}";
        }
        return new Uri($"{url.AbsoluteUri}?{queryWithIds}");
    }

    private static HttpResponseMessage Get(Uri url)
    {
        if (_client.BaseAddress == null)
        {
            _client.BaseAddress = url;
            _client.DefaultRequestHeaders.Accept.Clear();
        }

        HttpResponseMessage response = _client.GetAsync(url.AbsoluteUri).Result;

        if (response.IsSuccessStatusCode)
            return response;

        throw new Exception($"Response Get status returned KO - response: {response}");
    }
    #endregion
}