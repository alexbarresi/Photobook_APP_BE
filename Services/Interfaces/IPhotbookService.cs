using Photobook_App_BE;

public interface IPhotobookService
{
    public List<Album> RetrievePhotobooksList(int userId = 0);
}