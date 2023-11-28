using Newtonsoft.Json;

namespace ChatGptRestClient.Models;

public class Message
{
  [JsonProperty("role")]
  public string Role { get; set; }

  [JsonProperty("content")]
  public string Content { get; set; }
}