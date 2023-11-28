using Newtonsoft.Json;

namespace ChatGptRestClient.Models;

public class EditChoice
{
  [JsonProperty("text")]
  public string Text { get; set; }

  [JsonProperty("index")]
  public int Index { get; set; }
}