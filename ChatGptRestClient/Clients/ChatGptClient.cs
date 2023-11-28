using System.Net.Http.Headers;
using System.Net.Http.Json;
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

  public async Task<Chat> CreateChatCompletion(CreateChatCompletionRequest request)
  {
    using var httpClient = CreateHttpClient(BaseUrl, _chatGptApiKey);
    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "chat/completions");
    httpRequestMessage.Content = JsonContent.Create(request);
    httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    var response = await httpClient.SendAsync(httpRequestMessage);

    var stringContent = await response.Content.ReadAsStringAsync();
    var result = JsonConvert.DeserializeObject<Chat>(stringContent);

    if (result is null)
    {
      throw new Exception("Result from GPT is null");
    }

    return result;
  }

  public async Task<Completion> CreateCompletion(CreateCompletionDavinciRequest request)
  {
    using var httpClient = CreateHttpClient(BaseUrl, _chatGptApiKey);
    var requestContent = JsonContent.Create(request, new MediaTypeWithQualityHeaderValue("application/json"));
    var response = await httpClient.PostAsync("completions", requestContent);

    var stringContent = await response.Content.ReadAsStringAsync();
    var result = JsonConvert.DeserializeObject<Completion>(stringContent);

    if (result is null)
    {
      throw new Exception("Result from GPT is null");
    }

    return result;
  }

  public async Task<GenerateImageResponse> GenerateImage(GenerateImageRequest request)
  {
    using var httpClient = CreateHttpClient(BaseUrl, _chatGptApiKey);
    var requestContent = JsonContent.Create(request, new MediaTypeWithQualityHeaderValue("application/json"));
    var response = await httpClient.PostAsync("images/generations", requestContent);

    var stringContent = await response.Content.ReadAsStringAsync();
    var result = JsonConvert.DeserializeObject<GenerateImageResponse>(stringContent);

    if (result is null)
    {
      throw new Exception("Result from GPT is null");
    }

    return result;
  }

  public void Init(string chatGptApiKey)
  {
    _chatGptApiKey = chatGptApiKey;
  }

  private HttpClient CreateHttpClient(string baseUrl, string? apiKey)
  {
    if (string.IsNullOrWhiteSpace(apiKey))
    {
      throw new Exception("apiKey mustn't be null");
    }

    var httpClient = new HttpClient();
    httpClient.Timeout = TimeSpan.FromMinutes(5);
    httpClient.BaseAddress = new Uri(baseUrl);
    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    return httpClient;
  }
}