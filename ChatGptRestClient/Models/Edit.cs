using Newtonsoft.Json;

namespace ChatGptRestClient.Models;

public class Edit
{
  [JsonProperty("object")]
  public string Object { get; set; }

  [JsonProperty("created")]
  public long CreatedDateInSeconds { get; set; }

  [JsonProperty("Choices")]
  public IEnumerable<EditChoice> Choice { get; set; }

  [JsonProperty("usage")]
  public Usage Usage { get; set; }
}