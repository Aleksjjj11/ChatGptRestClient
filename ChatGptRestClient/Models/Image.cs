using Newtonsoft.Json;

namespace ChatGptRestClient.Models;

public class Image
{
  [JsonProperty("url")]
  public string Url { get; set; }
}