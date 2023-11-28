using System.ComponentModel.DataAnnotations;
using ChatGptRestClient.Models;
using ChatGptRestClient.Requests;
using ChatGptRestClient.Responses;

namespace ChatGptRestClient.Clients;

public interface IChatGptClient
{
  static IChatGptClient Current { get; }
  Task<Chat> CreateChatCompletion([Required] CreateChatCompletionRequest request);
  Task<Completion> CreateCompletion([Required] CreateCompletionDavinciRequest request);
  Task<GenerateImageResponse> GenerateImage([Required] GenerateImageRequest request);
  void Init(string chatGptApiKey);
}