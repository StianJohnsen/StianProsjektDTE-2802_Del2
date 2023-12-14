using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProsjektOppgaveWebAPI.Controllers;
using ProsjektOppgaveWebAPI.Models;
using ProsjektOppgaveWebAPI.Models.ViewModel;
using ProsjektOppgaveWebAPI.Services.CommentServices;

namespace ProsjektOppgaveWebAPITest;

public class CommentControllerTest
{
    private readonly Mock<ICommentService> _serviceMock;
    private readonly CommentController _controller;

    public CommentControllerTest()
    {
        _serviceMock = new Mock<ICommentService>();
        _controller = new CommentController(_serviceMock.Object);
    }

    
    
    // GET
    [Fact]
    public async Task GetComments_ReturnsExpectedComments()
    {
        // Arrange
        const int postId = 1;
        var expectedComments = new List<Comment> { new Comment(), new Comment() };
        _serviceMock.Setup(service => service.GetCommentsForPost(postId)).ReturnsAsync(expectedComments);

        // Act
        var result = await _controller.GetComments(postId);

        // Assert
        Assert.Equal(expectedComments, result);
        _serviceMock.Verify(x => x.GetCommentsForPost(postId), Times.Once);
    }
    
    [Fact]
    public void GetComment_ReturnsExpectedComment()
    {
        // Arrange
        const int commentId = 1;
        var expectedComment = new Comment();
        _serviceMock.Setup(service => service.GetComment(commentId)).Returns(expectedComment);

        // Act
        var result = _controller.GetComment(commentId);

        // Assert
        Assert.Equal(expectedComment, result);
        _serviceMock.Verify(x => x.GetComment(commentId), Times.Once);
    }

    
    
    // POST
    [Fact]
    public async Task Create_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var commentViewModel = new CommentViewModel();
        _controller.ModelState.AddModelError("error", "some error");

        // Act
        var result = await _controller.Create(commentViewModel.PostId, commentViewModel);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task Create_ReturnsCreatedAtAction_WhenModelStateIsValid()
    {
        // Arrange
        var comment = new Comment();
        var commentViewModel = new CommentViewModel();

        // Mock User
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "user1"),
            // other claims as needed
        }, "mock"));
        _controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext() { User = user }
        };

        // Act
        var result = await _controller.Create(commentViewModel.PostId, commentViewModel);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal("GetComment", createdAtActionResult.ActionName);
        Assert.Equal(comment, createdAtActionResult.Value);
        _serviceMock.Verify(x => x.Save(comment, user), Times.Once);
    }

    
    
    // PUT
    [Fact]
    public void Update_ReturnsBadRequest_WhenIdDoesNotMatchCommentId()
    {
        // Arrange
        var comment = new Comment { CommentId = 1 };
        var commentViewModel = new CommentViewModel { CommentId = 1 };

        // Act
        var result = _controller.Update(2, commentViewModel);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public void Update_ReturnsNotFound_WhenCommentDoesNotExist()
    {
        // Arrange
        var comment = new Comment { CommentId = 1 };
        var commentViewModel = new CommentViewModel { CommentId = 1 };
        _serviceMock.Setup(service => service.GetComment(comment.CommentId)).Returns((Comment)null);

        // Act
        var result = _controller.Update(1, commentViewModel);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Update_ReturnsUnauthorized_WhenUserIsNotOwner()
    {
        // Arrange
        var comment = new Comment { CommentId = 1, OwnerId = "user1" };
        var existingComment = new Comment { CommentId = 1, OwnerId = "user2" };
        
        var commentViewModel = new CommentViewModel { CommentId = 1, OwnerId = "user1" };
        
        _serviceMock.Setup(service => service.GetComment(comment.CommentId)).Returns(existingComment);

        // Mock User
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "user1"),
            // other claims as needed
        }, "mock"));
        _controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext() { User = user }
        };

        // Act
        var result = _controller.Update(1, commentViewModel);

        // Assert
        Assert.IsType<UnauthorizedResult>(result);
    }

    [Fact]
    public void Update_ReturnsNoContent_WhenUpdateIsSuccessful()
    {
        // Arrange
        var comment = new Comment { CommentId = 1, OwnerId = "user1" };
        var commentViewModel = new CommentViewModel { CommentId = 1, OwnerId = "user1" };

        var existingComment = new Comment { CommentId = 1, OwnerId = "user1" };
        _serviceMock.Setup(service => service.GetComment(comment.CommentId)).Returns(existingComment);

        // Mock User
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "user1"),
            // other claims as needed
        }, "mock"));
        _controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext() { User = user }
        };

        // Act
        var result = _controller.Update(1, commentViewModel);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _serviceMock.Verify(x => x.Save(comment, user), Times.Once);
    }
    
    
    
    // DELETE
    [Fact]
    public void Delete_ReturnsNotFound_WhenCommentDoesNotExist()
    {
        // Arrange
        const int commentId = 1;
        _serviceMock.Setup(service => service.GetComment(commentId)).Returns((Comment)null);

        // Act
        var result = _controller.Delete(commentId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Delete_ReturnsUnauthorized_WhenUserIsNotOwner()
    {
        // Arrange
        const int commentId = 1;
        var comment = new Comment { CommentId = commentId, OwnerId = "user1" };
        _serviceMock.Setup(service => service.GetComment(commentId)).Returns(comment);

        // Mock User
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "user2"),
            // other claims as needed
        }, "mock"));
        _controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext() { User = user }
        };

        // Act
        var result = _controller.Delete(commentId);

        // Assert
        Assert.IsType<UnauthorizedResult>(result);
    }

    [Fact]
    public void Delete_ReturnsNoContent_WhenDeleteIsSuccessful()
    {
        // Arrange
        const int commentId = 1;
        var comment = new Comment { CommentId = commentId, OwnerId = "user1" };
        _serviceMock.Setup(service => service.GetComment(commentId)).Returns(comment);

        // Mock User
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "user1"),
            // other claims as needed
        }, "mock"));
        _controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext() { User = user }
        };

        // Act
        var result = _controller.Delete(commentId);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _serviceMock.Verify(x => x.Delete(commentId, user), Times.Once);
    }
}