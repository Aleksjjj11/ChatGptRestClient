using ChatGptRestClient.Models;
using Newtonsoft.Json;

namespace ChatGptRestClient.Requests;

public class CreateChatCompletionLiveRequest
{
  [JsonProperty("action")]
  public string Action { get; set; }

  [JsonProperty("model")]
  public string Model { get; set; }

  [JsonProperty("parent_message_id")]
  public string ParentMessageId { get; set; }

  [JsonProperty("timezone_offset_min")]
  public int TimeZoneOffsetMin { get; set; }

  [JsonProperty("conversation_id")]
  public string ConversationId { get; set; }

  [JsonProperty("messages")]
  public IEnumerable<MessageLive> Messages { get; set; }
}