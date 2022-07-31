using Photobook_App_BE;

public interface IPhotobookService
{
    public List<Album> RetrievePhotobookList(int userId = 0);

    public List<Album> RetrievePhotobookList();

}