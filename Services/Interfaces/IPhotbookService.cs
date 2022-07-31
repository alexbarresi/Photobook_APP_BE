using Photobook_App_BE;

public interface IPhotobookService
{
    Task<List<Album>> RetrievePhotobookList(int userId = 0);

    Task<List<Album>> RetrievePhotobookList();

}