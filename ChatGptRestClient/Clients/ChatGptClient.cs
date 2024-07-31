using System.Text;
using ChatGptRestClient.Models;
using ChatGptRestClient.Requests;
using ChatGptRestClient.Responses;
using Newtonsoft.Json;

namespace ChatGptRestClient.Clients;

public class ChatGptClient : IChatGptClient
{
    private static IChatGptClient? _chatGptClient;
    private static string? _chatGptApiKey;

    private const string BaseUrl = "https://api.openai.com/v1/";

    public static IChatGptClient Current => _chatGptClient ??= new ChatGptClient();

    /// <summary>
    /// Initializes the ChatGptClient with the specified API key.
    /// Should be executed before using any other methods.
    /// </summary>
    /// <param name="chatGptApiKey">The API key to be used for authentication.</param>
    public static void Init(string chatGptApiKey)
    {
        _chatGptApiKey = chatGptApiKey;
    }

    /// <summary>
    /// Creates a chat completion using the specified request.
    /// </summary>
    /// <param name="request">The <see cref="CreateChatCompletionRequest"/> object that contains the model and messages for the chat completion.</param>
    /// <returns>The <see cref="Chat"/> object that represents the chat completion result.</returns>
    public async Task<Chat> CreateChatCompletion(CreateChatCompletionRequest request)
    {
        using var httpClient = CreateHttpClient(_chatGptApiKey);
        var jsonContent = JsonConvert.SerializeObject(request);
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "chat/completions");
        httpRequestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await httpClient.SendAsync(httpRequestMessage);

        var stringContent = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Chat>(stringContent);

        if (result is null)
        {
            throw new Exception("Result from GPT is null");
        }

        return result;
    }

    [Obsolete]
    public async Task<Completion> CreateCompletion(CreateCompletionDavinciRequest request)
    {
        using var httpClient = CreateHttpClient(_chatGptApiKey);
        var jsonContent = JsonConvert.SerializeObject(request);
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "completions");
        httpRequestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await httpClient.SendAsync(httpRequestMessage);

        var stringContent = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Completion>(stringContent);

        if (result is null)
        {
            throw new Exception("Result from GPT is null");
        }

        return result;
    }

    /// <summary>
    /// Generates an image using the specified request.
    /// </summary>
    /// <param name="request">
    /// The <see cref="GenerateImageRequest"/> object that contains the parameters for generating the image.
    /// </param>
    /// <returns>
    /// The <see cref="GenerateImageResponse"/> object that represents the generated image result.
    /// </returns>
    public async Task<GenerateImageResponse> GenerateImage(GenerateImageRequest request)
    {
        request.Assert();

        using var httpClient = CreateHttpClient(_chatGptApiKey);
        var jsonContent = JsonConvert.SerializeObject(request);
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, "images/generations");
        httpRequest.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await httpClient.SendAsync(httpRequest);
        var stringContent = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode == false)
        {
            throw new Exception(stringContent);
        }

        var result = JsonConvert.DeserializeObject<GenerateImageResponse>(stringContent);
        return result;
    }

    private HttpClient CreateHttpClient(string apiKey)
    {
        var httpClient = new HttpClient();
        httpClient.Timeout = TimeSpan.FromMinutes(2);
        httpClient.BaseAddress = new Uri(BaseUrl);
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        return httpClient;
    }
}