using ChatGptRestClient.Models;
using Newtonsoft.Json;

namespace ChatGptRestClient.Requests;

public class CreateChatCompletionRequest
{
  [JsonProperty("model")]
  public string Model { get; set; }

  [JsonProperty("messages")]
  public IEnumerable<Message> Messages { get; set; }
}