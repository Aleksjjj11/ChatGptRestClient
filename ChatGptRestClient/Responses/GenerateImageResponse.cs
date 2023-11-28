using ChatGptRestClient.Models;
using Newtonsoft.Json;

namespace ChatGptRestClient.Responses;

public class GenerateImageResponse
{
  [JsonProperty("created")]
  public long CreatedDateInMs { get; set; }

  [JsonProperty("data")]
  public IEnumerable<Image> Images { get; set; }
}