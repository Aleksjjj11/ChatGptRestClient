using Newtonsoft.Json;

namespace ChatGptRestClient.Models;

public class ChatChoice
{
  [JsonProperty("index")]
  public int Index { get; set; }

  [JsonProperty("message")]
  public Message Message { get; set; }

  [JsonProperty("finish_reason")]
  public string FinishReason { get; set; }
}