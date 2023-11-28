using Newtonsoft.Json;

namespace ChatGptRestClient.Models;

public class Completion
{
  [JsonProperty("id")]
  public string Id { get; set; }

  [JsonProperty("object")]
  public string Object { get; set; }

  [JsonProperty("created")]
  public long CreatedDateInSeconds { get; set; }

  [JsonProperty("model")]
  public string Model { get; set; }

  [JsonProperty("choices")]
  public IEnumerable<CompletionChoice> Choices { get; set; }

  [JsonProperty("usage")]
  public Usage Usage { get; set; }
}