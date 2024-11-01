using AutoMapper;
using Moq;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Concretes;
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
        _mockRules = new Mock<PostBusinessRules>();

        _postService = new PostService(_mockRepository.Object,_mockMapper.Object,_mockRules.Object);
    }


    [Test]
    public async Task PostService_WhenPostAdded_ReturnSuccess()
    {
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
        // Arrange
        _mockMapper.Setup(x => x.Map<Post>(dto)).Returns(post);
        _mockRepository.Setup(x => x.Add(post)).Returns(post);
        _mockMapper.Setup(x => x.Map<PostResponseDto>(post)).Returns(response);

        // Act 

        var result =await _postService.Add(dto, "{AEF23537-D755-4B37-8A99-831089A5D0F1}");

        // Assert 
        Assert.IsTrue(result.Success);


    }
}
