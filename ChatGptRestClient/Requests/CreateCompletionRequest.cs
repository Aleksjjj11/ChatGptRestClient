using Newtonsoft.Json;

namespace ChatGptRestClient.Requests;

public class CreateCompletionRequest
{
  [JsonProperty("model")]
  public string Model { get; set; }

  [JsonProperty("prompt")]
  public string Prompt { get; set; }

  [JsonProperty("max_tokens")]
  public int? MaxTokens { get; set; }

  [JsonProperty("temperature")]
  public int? Temperature { get; set; }

  [JsonProperty("top_p")]
  public int? TopP { get; set; }

  [JsonProperty("n")]
  public int? N { get; set; }

  [JsonProperty("stream")]
  public bool? IsStream { get; set; }

  [JsonProperty("logprobs")]
  public int? IsLogprobs { get; set; }

  [JsonProperty("stop")]
  public string StopCharacter { get; set; }
}