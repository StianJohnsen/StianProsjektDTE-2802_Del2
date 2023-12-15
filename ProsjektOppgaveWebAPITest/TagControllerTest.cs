using Microsoft.AspNetCore.Mvc;
using Moq;
using ProsjektOppgaveWebAPI.Controllers;
using ProsjektOppgaveWebAPI.Models;
using ProsjektOppgaveWebAPI.Models.ViewModel;
using ProsjektOppgaveWebAPI.Services.TagServices;

namespace ProsjektOppgaveWebAPITest;

public class TagControllerTest
{
    private readonly Mock<ITagService> _serviceMock;
    private readonly TagController _controller;

    public TagControllerTest()
    {
        _serviceMock = new Mock<ITagService>();
        _controller = new TagController(_serviceMock.Object);
    }
    
    
    
    // POST
    [Fact]
    public async Task Create_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        _controller.ModelState.AddModelError("error", "some error");

        // Act
        var result = await _controller.Create(new TagViewModel());

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task Create_ReturnsOk_WhenModelStateIsValid()
    {
        // Arrange
        var tag = new Tag();
        var tagViewModel = new TagViewModel();

        // Act
        var result = await _controller.Create(tagViewModel);

        // Assert
        Assert.IsType<OkResult>(result);
        _serviceMock.Verify(x => x.Save(tag), Times.Once);
    }
}
