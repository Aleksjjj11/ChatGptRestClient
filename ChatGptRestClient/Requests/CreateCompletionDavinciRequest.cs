using Newtonsoft.Json;

namespace ChatGptRestClient.Requests;

public class CreateCompletionDavinciRequest
{
  [JsonProperty("model")]
  public string Model { get; set; }

  [JsonProperty("prompt")]
  public string Prompt { get; set; }

  [JsonProperty("max_tokens")]
  public string MaxTokens { get; set; }

  [JsonProperty("temperature")]
  public double Temperature { get; set; }

  public int? N { get; set; }
}