using Newtonsoft.Json;

namespace ChatGptRestClient.Models;

public class MessageLive
{
  [JsonProperty("author")]
  public AuthorLive Author { get; set; }

  [JsonProperty("content")]
  public ContentLive Content { get; set; }

  [JsonProperty("id")]
  public string Id { get; set; }

  [JsonProperty("role")]
  public string Role { get; set; }
}