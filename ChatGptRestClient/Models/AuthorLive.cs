using Newtonsoft.Json;

namespace ChatGptRestClient.Models;

public class AuthorLive
{
  [JsonProperty("role")]
  public string Role { get; set; }
}