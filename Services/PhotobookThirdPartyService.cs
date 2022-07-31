using Photobook_App_BE;

public class PhotobookThirdPartyService
{
    private readonly Uri BaseUrl = new Uri("https://jsonplaceholder.typicode.com");
    private List<Album> Albums;
    private List<Photo> Photos;
    private static readonly HttpClient _client = new();

    public PhotobookThirdPartyService()
    {
        Albums = new();
        Photos = new();
    }
    
    public List<Photo> GetPhotos(List<int> albumIds = null)
    {
        Uri url = AddAlbumIdsToUrl(new Uri(BaseUrl, "/photos"), albumIds);

        HttpResponseMessage res = Get(url);
        Photos = res.Content.ReadFromJsonAsync<List<Photo>>().Result;

        return Photos;
    }

    public List<Album> GetAlbums(int userId = 0)
    {
        Uri url = AddUserIdToUrl(new Uri(BaseUrl, "/albums"), userId);

        HttpResponseMessage res = Get(url);
        Albums = res.Content.ReadFromJsonAsync<List<Album>>().Result;

        return Albums;
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

        // Here, we loop through the Album ids to build the query string with all the needed ids
        // So in this way we're preventing multiple calls thanks to query string power
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