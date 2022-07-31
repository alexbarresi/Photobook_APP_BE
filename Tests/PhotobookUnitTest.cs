using Photobook_App_BE;
using Photobook_App_BE.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Photobook_APP_BE.Tests;

public class UnitTest1
{
    [Fact]
    public void Should_Return_AlbumList_When_Albums_Found()
    {
        // Arrange
        var repositoryMock = new Mock<IPhotobookService>();
        var Album = GetAlbums();

        repositoryMock.Setup(r => r.RetrievePhotobookList()).ReturnsAsync(Album);
        var controller = new PhotobookController(repositoryMock.Object);

        // Act
        var result = controller.Get();

        // Assert
        var viewResult = Assert.IsType<Task<ActionResult<List<Album>>>>(result);
    }

    [Fact]
    public void Should_Return_AlbumList_When_Albums_FilteredByID_Found()
    {
        // Arrange
        int UserId = 9;
        var repositoryMock = new Mock<IPhotobookService>();
        var Album = GetAlbums();

        repositoryMock.Setup(r => r.RetrievePhotobookList()).ReturnsAsync(Album);
        var controller = new PhotobookController(repositoryMock.Object);

        // Act
        var result = controller.Get(UserId);

        // Assert
        var viewResult = Assert.IsType<Task<ActionResult<List<Album>>>>(result);
    }


    private List<Album> GetAlbums(int userId = 0)
    {
        List<Album> AlbumList = new();

        var jsonText = File.ReadAllText("Tests/Mocks/AlbumMock.json");
        AlbumList = JsonConvert.DeserializeObject<List<Album>>(jsonText);

        return AlbumList;
    }
}