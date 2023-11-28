using Newtonsoft.Json;

namespace ChatGptRestClient.Models;

public class CompletionChoice
{
  [JsonProperty("text")]
  public string Text { get; set; }

  [JsonProperty("index")]
  public int Index { get; set; }

  [JsonProperty("logprobs")]
  public int? Logprobs { get; set; }

  [JsonProperty("finish_reason")]
  public string FinishReason { get; set; }
}