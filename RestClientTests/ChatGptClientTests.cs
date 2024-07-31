using ChatGptRestClient.Clients;
using ChatGptRestClient.Models;
using ChatGptRestClient.Requests;

namespace RestClientTests;

public class ChatGptClientTests
{
    [SetUp]
    public void Setup()
    {
        ChatGptClient.Init("");
    }

    [Test]
    public async Task CreateChatCompletion()
    {
        var result = await ChatGptClient.Current.CreateChatCompletion(new CreateChatCompletionRequest
        {
            Model = AiModels.Turbo4oMini,
            Messages = new[]
            {
                new Message
                {
                    Role = "user",
                    Content = "Как можно перевести с японского языка: 先端"
                }
            }
        });

        if (result.Choices is null || result.Choices.Any() == false)
        {
            Assert.Fail();
        }

        Assert.Pass();
    }

    [Test]
    public async Task CreateImage()
    {
        var result = await ChatGptClient.Current.GenerateImage(new GenerateImageRequest
        {
            Model = AiModels.DallE2,
            N = 1,
            Prompt = "Some image to test",
            Size = AiModels.ImageSizesDallE2.First(),
        });

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Images);
        Assert.IsNotEmpty(result.Images);
    }
}