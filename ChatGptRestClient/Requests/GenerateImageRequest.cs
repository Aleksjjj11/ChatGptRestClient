using ChatGptRestClient.Models;
using Newtonsoft.Json;

namespace ChatGptRestClient.Requests;

public class GenerateImageRequest
{
    [JsonProperty("prompt")]
    public string Prompt { get; set; }

    [JsonProperty("n")]
    public int N { get; set; }

    [JsonProperty("model")]
    public string Model { get; set; }

    [JsonProperty("size")]
    public string Size { get; set; }

    [JsonProperty("quality")]
    public string Quality { get; set; } = "standard";

    [JsonProperty("response_format")]
    public string ResponseFormat { get; set; } = "url";

    [JsonProperty("style")]
    public string Style { get; set; } = "natural";

    /// <summary>
    /// Validates the GenerateImageRequest before executing the image generation.
    /// </summary>
    /// <remarks>
    /// This method checks if the specified model is supported for image generation
    /// and validates the input parameters based on the model requirements.
    /// </remarks>
    /// <exception cref="Exception">
    /// Thrown when the model is not supported for image generation,
    /// or when the prompt length exceeds the maximum allowed size for the specified model,
    /// or when the value of N exceeds the maximum allowed value for the specified model,
    /// or when the specified size is not supported by the specified model.
    /// </exception>
    public void Assert()
    {
        if (Model.Equals(AiModels.DallE3) == false
            && Model.Equals(AiModels.DallE2) == false)
        {
            throw new Exception("Not supported model to generate image");
        }

        if (Model.Equals(AiModels.DallE3, StringComparison.InvariantCultureIgnoreCase))
        {
            if (Prompt.Length > AiModels.MaxPromptSizeDallE3)
                throw new Exception($"Prompt's length exceeds {AiModels.MaxPromptSizeDallE3} symbols");

            if (N > AiModels.MaxNDallE3) throw new Exception($"N exceeds {AiModels.MaxNDallE3}");

            if (AiModels.ImageSizesDallE3.Any(x => x.Equals(Size)) == false)
                throw new Exception($"Not supported size: {Size}");
            return;
        }

        if (Prompt.Length > AiModels.MaxPromptSizeDallE2)
            throw new Exception($"Prompt's length exceeds {AiModels.MaxPromptSizeDallE2} symbols");

        if (N > AiModels.MaxNDallE2) throw new Exception($"N exceeds {AiModels.MaxNDallE2}");

        if (AiModels.ImageSizesDallE2.Any(x => x.Equals(Size)) == false)
            throw new Exception($"Not supported size: {Size}");
    }
}