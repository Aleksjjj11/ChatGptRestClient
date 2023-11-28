using Newtonsoft.Json;

namespace ChatGptRestClient.Requests;

public class GenerateImageRequest
{
  [JsonProperty("prompt")]
  public string Prompt { get; set; }

  [JsonProperty("n")]
  public int N { get; set; }
}