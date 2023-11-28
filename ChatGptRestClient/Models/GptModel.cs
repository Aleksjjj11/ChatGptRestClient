using Newtonsoft.Json;

namespace ChatGptRestClient.Models;

public class GptModel
{
  [JsonProperty("id")]
  public string Id { get; set; }

  [JsonProperty("object")]
  public string Object { get; set; }

  [JsonProperty("owned_by")]
  public string OwnedBy { get; set; }

  [JsonProperty("permission")]
  public IEnumerable<string> Permissions { get; set; }
}