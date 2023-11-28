using Newtonsoft.Json;

namespace ChatGptRestClient.Models;

public class ContentLive
{
  [JsonProperty("content_type")]
  public string ContentType { get; set; }

  [JsonProperty("parts")]
  public IEnumerable<string> Parts { get; set; }
}