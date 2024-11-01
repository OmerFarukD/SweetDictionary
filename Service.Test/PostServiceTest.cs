using AutoMapper;
using Core.Exceptions;
using Moq;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Concretes;
using SweetDictionary.Service.Constants;
using SweetDictionary.Service.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Test;

public class PostServiceTest
{
    private PostService _postService;

    private Mock<IPostRepository> _mockRepository;

    private Mock<IMapper> _mockMapper;

    private Mock<PostBusinessRules> _mockRules;


    [SetUp]
    public void SetUp()
    {
        _mockRepository = new Mock<IPostRepository>();
        _mockMapper = new Mock<IMapper>();
        _mockRules = new Mock<PostBusinessRules>(_mockRepository.Object);

        _postService = new PostService(_mockRepository.Object,_mockMapper.Object,_mockRules.Object);
    }


    [Test]
    public async Task PostService_WhenPostAdded_ReturnSuccess()
    {
        
        // Arrange
        CreatePostRequestDto dto = new CreatePostRequestDto("deneme","deneme",1);
        Post post = new Post
        {
            Title = dto.Title,
            Content = dto.Content,
            CategoryId = dto.CategoryId
        };

        PostResponseDto response = new PostResponseDto
        {
            AuthorUserName = "deneme",
            CategoryName = "deneme",
            Content = "deneme",
            id = new Guid("{EEF23537-D755-4B37-8A99-831089A5D0F1}"),
            Title = "deneme"

        };
        
        _mockMapper.Setup(x => x.Map<Post>(dto)).Returns(post);
        _mockRepository.Setup(x => x.Add(post)).Returns(post);
        _mockMapper.Setup(x => x.Map<PostResponseDto>(post)).Returns(response);

        // Act 

        var result =await _postService.Add(dto, "{AEF23537-D755-4B37-8A99-831089A5D0F1}");

        // Assert 
        Assert.IsTrue(result.Success);
        Assert.AreEqual(response,result.Data);
        Assert.AreEqual(200, result.Status);
        Assert.AreEqual("Post eklendi.", result.Message);

    }

    [Test]
    public void PostService_WhenPostIsPresent_RemovePost()
    {
        // Arrange
        Guid id = new Guid("{BEF23537-D755-4B37-8A99-831089A5D0F1}");
        Post post = new Post
        {
            Id = id,
            Title = "dto.Title",
            Content = "dto.Content",
            CategoryId = 1,
            AuthorId = "DENEME",
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now
        };
        

        _mockRules.Setup(x => x.PostIsPresent(id)).Returns(true);


        _mockRepository.Setup(x => x.GetById(id)).Returns(post);
        _mockRepository.Setup(x => x.Delete(post)).Returns(post);


        // Act

        var result = _postService.Delete(id);

        // Assert

        Assert.IsTrue(result.Success);
    }

    [Test]
    public void PostService_WhenPostIsNotPresent_RemoveFailed()
    {
        // Arrange 
        Guid id = new Guid("{BEF23537-D755-4B37-8A99-831089A5D0F1}");

        _mockRules.Setup(x => x.PostIsPresent(id)).Throws(new NotFoundException(Messages.PostIsNotPresentMessage(id)));

        //Assert
        Assert.Throws<NotFoundException>(() => _postService.Delete(id), Messages.PostIsNotPresentMessage(id));
    }

    


}
